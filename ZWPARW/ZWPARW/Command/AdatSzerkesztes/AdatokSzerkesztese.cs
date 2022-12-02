using ZWPARW.Object;

namespace ZWPARW.Command.AdatSzerkesztes
{
    internal class AdatokSzerkesztese : ICommand
    {
        private uint Id;
        private string name;

        public string Name => "AdatokSzerkesztese";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres = "Leltar.xml")
        {
        Hiba:
            try
            {
                CommandLoader loadere = new CommandLoader();
                loadere.Commands["Lekerdezes"].Execute(leltar);

                Console.WriteLine("Add meg az ID:");
                Id = uint.Parse(Console.ReadLine());
                var elem = leltar.azonosito.Where(y => y.id.Equals(Id));

                if (elem.Count() == 0) { throw new ArgumentOutOfRangeException(); }

                foreach (var item in elem)
                {
                    name = item.Termek;
                }
            }
            catch (Exception e) when (e is FormatException || e is NullReferenceException)
            {
                Console.WriteLine("Nem megfelelo formátumot adtál meg");
                return leltar;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Nem megfelelo szamot adtál meg");
                goto Hiba;
            }

            LeltarAzonosito uj = new LeltarAzonosito();

        termek:
            Console.WriteLine("Termék Neve:");
            uj.Termek = Console.ReadLine();
            if (uj.Termek != null)
            {
            Problem:
                var termek = leltar.azonosito.Where(z => z.Termek.Contains(uj.Termek));

                string namet = "";

                foreach (var item in termek)
                {
                    namet = item.Termek;
                }

                if (namet == name || termek.Count() == 0)
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
                        goto Problem;
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
            foreach (LeltarAzonosito leltarAzonosito in leltar.azonosito.Where(y => y.id.Equals(Id)))
            {
                uj.id = leltarAzonosito.id;
                leltar.azonosito.Remove(leltarAzonosito);
            }

            leltar.azonosito.Add(uj);

            Ment(leltar);
            NincsMentes(leltar);

            return leltar;

        }

        private async void Ment(Leltar leltar)
        {
            await Global.BMentes(leltar);
        }
        private async void NincsMentes(Leltar leltar)
        {
            await Global.Mentes(leltar);
        }

        public void Help(string message = "")
        {
            Console.WriteLine("Az azonositp alapjan lehet szerkeszteni adot termeket ");
        }
    }
}
