using ZWPARW.Object;

namespace ZWPARW.Command.AdatSzerkesztes
{
    internal class AdatFelvitel : ICommand
    {
        public string Name => "AdatFelvitel";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres = "Leltar.xml")
        {
            LeltarAzonosito uj = new LeltarAzonosito();

        termek:
            Console.WriteLine("Termék Neve:");
            uj.Termek = Console.ReadLine();
            if (uj.Termek != null)
            {
            Hiba:
                var termek = leltar.azonosito.Where(z => z.Termek.Contains(uj.Termek));
                if (termek.Count() == 0)
                {
                    try
                    {
                        Console.Write("Utolso Ellemorzes:\n \t Év: (formátum: 2000)\n\t");
                        int ev = int.Parse(Console.ReadLine());

                        Console.Write("\n\tHonap: (fomátuma:01)\n\t");
                        int honap = int.Parse(Console.ReadLine());

                        Console.Write("\n\tNap: (fomátuma:01)\n\t");
                        int nap = int.Parse(Console.ReadLine());

                        DateTime UtolsoEllenorzes = new DateTime(ev, honap, nap);
                        if (UtolsoEllenorzes > DateTime.Now)
                        {
                            Console.WriteLine("A mai dátumnál nem lehet nagyobb az utolso ellenörzés");
                            goto Hiba;
                        }
                        else
                        {
                            uj.UtolsoEllenorzes = UtolsoEllenorzes;
                        }

                    }
                    catch (Exception e) when (e is FormatException || e is NullReferenceException)
                    {
                        Console.WriteLine("Nem megfelelo formátumot adtál meg");
                        return leltar;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Nem megfelelo datumod adtál meg");
                        goto Hiba;
                    }
                }
                else
                {
                    Console.WriteLine("A termék már jelen van az adatbázisban");
                    goto termek;

                }
            }
            else
            {
                Console.WriteLine("Nem let megadva termeknév");
                goto termek;
            }
        darab:
            try
            {
                Console.WriteLine("A termék Jelen darabszáma");
                uj.JelenDarabszam = int.Parse(Console.ReadLine());

                Console.WriteLine("A termék kivánt darabszáma");
                uj.KivantDarabszam = int.Parse(Console.ReadLine());

                Console.WriteLine("A termék jelenlegi ára");
                uj.BruttoAr = int.Parse(Console.ReadLine());

                Console.WriteLine("A termék sulya gramban");
                uj.GramSulya = int.Parse(Console.ReadLine());
            }
            catch (Exception e) when (e is FormatException || e is NullReferenceException)
            {
                Console.WriteLine("Nem számot adtál meg");
                goto darab;
            }
            uj.id = (uint)leltar.azonosito.Count();

            leltar.azonosito.Add(uj);


            CommandLoader loader = new CommandLoader();
            Task t = new Task(async () => loader.Commands["BiztonsagiMentes"].Execute(leltar));

            t.Start();


            return leltar;

        }

        public void Help(string message)
        {
            Console.WriteLine("Egy uj terméket lehet felvini az adatbáyisba ha még nem az nem létezik");
        }
    }
}
