using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZCSVParser.DATATYPES;

namespace ZCSVParser.RECORDS
{
    public static class DataExporter
    {
        public static void ExportNapiAdagXML(List<RendelesInput> sorok)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<NapiAdag>));
            var adat = DataCollector.CollectDataForNapiAdag(sorok);
            using (var stream = File.Create(Path.Combine(GLOBALS.OutputPath, $"NapiAdag_osszesito_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm")}.xml")))
            {
                try
                {
                    xs.Serialize(stream, adat);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Hiba történt az XML szérializálásakor!");
                }
            }
        }

        public static void ExportNapiAdagPerEtkezesFajta(List<RendelesInput> sorok)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<NapiAdagPerEtkezesFajta>));
            var adat = DataCollector.CollectDataForNapiAdagPerEtkezesFajta(sorok);
            using (var stream = File.Create(Path.Combine(GLOBALS.OutputPath, $"NapiAdagPerEtkezesFajta_osszesito_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm")}.xml")))
            {
                try
                {
                    xs.Serialize(stream, adat);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Hiba történt az XML szérializálásakor!");
                }
            }
        }

        public static void ExportNapiAdagPerFogyasztoKod(List<RendelesInput> sorok)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<NapiAdagPerFogyasztoKod>));
            var adat = DataCollector.CollectDataForNapiAdagPerFogyasztoKod(sorok);
            using (var stream = File.Create(Path.Combine(GLOBALS.OutputPath, $"NapiAdagPerFogyasztoKod_osszesito_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm")}.xml")))
            {
                try
                {
                    xs.Serialize(stream, adat);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Hiba történt az XML szérializálásakor!");
                }
            }
        }

        public static void ExportAllXMLs(List<RendelesInput> sorok)
        {
            Console.WriteLine("A statisztikai adatok gyűjtése, és kiírása folyamatban...");
            var NapiAdagTask = Task.Run(() => ExportNapiAdagXML(sorok));
            var NapiAdagPerEtkezesFajtaTask = Task.Run(() => ExportNapiAdagPerEtkezesFajta(sorok));
            var NapiAdagPerFogyasztoKodTask = Task.Run(() => ExportNapiAdagPerFogyasztoKod(sorok));
            Task.WaitAll(NapiAdagTask, NapiAdagPerEtkezesFajtaTask, NapiAdagPerFogyasztoKodTask);
            Console.WriteLine("A statisztikai adatok gyűjtése és kiírása befejeződött.");
        }
    }
}
