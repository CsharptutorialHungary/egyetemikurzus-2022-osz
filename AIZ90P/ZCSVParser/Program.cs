using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;
using ZCSVParser.DATATYPES;
using ZCSVParser.RECORDS;
using ZCSVParser.VALIDATION;

namespace ZCSVParser
{
    class Program
    {
        static void Help()
        {
            Console.WriteLine($"Használat: ./{System.AppDomain.CurrentDomain.FriendlyName} /utvonal/a/bemenethez /utvonal/a/kimenethez");
        }

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Pontosan kettő paramétert kell megadj: A mappát, ahonnan olvasok, és egy másikat, ahova exportálok.");
                Help();
                Environment.Exit(-2);
            }
            if (!PathValidator.CanWorkWithPath(args[0], args[1]))
            {
                Console.WriteLine("Erről az útvonalról/útvonalra nem tudok dolgozni! Kérlek válassz másikat!");
                Console.WriteLine($"Feltételezett INPUT: {args[0]}");
                Console.WriteLine($"Feltételezett OUTPUT: {args[1]}");
                Environment.Exit(-1);
            }
            var lines = new BlockingCollection<string>();
            Console.WriteLine("Elkezdődik a fájlok beolvasása és feldolgozása.");
            var readStage = Task.Run(() =>
            {
                try
                {
                    foreach (var filePath in GLOBALS.InputFiles)
                    {
                        using (var reader = new StreamReader(filePath))
                        {
                            string line;
                            reader.ReadLine();
                            while ((line = reader.ReadLine()) != null)
                            {
                                lines.Add(line);
                                //Console.WriteLine(line);
                            }
                        }
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("IO Hiba!");
                }
                finally
                {
                    lines.CompleteAdding();
                }
            });

            var processStage = Task.Run(() =>
            {
                var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
                Parallel.ForEach(lines.GetConsumingEnumerable(), parallelOptions, line =>
                {
                    string[] splittedLine = line.Split(';');
                    DateTime datum;
                    DateTime.TryParse(splittedLine[0], out datum);
                    string FogyasztoKod = splittedLine[1];
                    string FogyasztoTipusKod = splittedLine[2];
                    string EtkezesTipusKod = splittedLine[3];
                    string EtkezesFajtaKod = splittedLine[4];
                    int Adag;
                    int.TryParse(splittedLine[5], out Adag);
                    RendelesInput rendelesInput = new RendelesInput(datum,
                                                                    FogyasztoKod,
                                                                    FogyasztoTipusKod,
                                                                    EtkezesTipusKod,
                                                                    EtkezesFajtaKod,
                                                                    Adag);
                    lock (GLOBALS.filesorok)
                    {
                        GLOBALS.filesorok.Add(rendelesInput);
                    }
                }
                );
            });
            Task.WaitAll(readStage, processStage);
            Console.WriteLine("A fájlok beolvasása és feldolgozása befejeződött!");
            Console.WriteLine("Kinyerem a statisztikai adatokat, majd kiírom őket a megfelelő mappába.");
            DataExporter.ExportAllXMLs(GLOBALS.filesorok);
            Console.WriteLine($"A program végrehajtása befejeződött!\nA kész XML fájlokat a {Path.GetFullPath(args[1])} mappában találod.");
            Console.Write("A kilépéshez nyomj egy entert...");
            Console.ReadLine();
        }
    }
}
