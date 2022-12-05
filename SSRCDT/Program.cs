using System;

namespace SSRCDT
{
    class Program
    {
        static void Main(string[] args)
        {
            MeatTypeLoader loader = new MeatTypeLoader();
            Console.WriteLine("hello");
            Fryer fryer1 = new Fryer(false);
            Fryer fryer2 = new Fryer(false);
            Fryer fryer3 = new Fryer(false);
            Fryer fryer_kent = new Fryer(true);
            MeatHolder meatHolder = new MeatHolder();

            string input = "";
            Console.WriteLine("Udv az appban!");
            while (input != "q")
            {
                Console.WriteLine("A segitsegert hasznald a '?' parancsot.");
                Console.WriteLine("Kilepes: 'q' parancs.");
                input = Console.ReadLine();
                switch (input)
                {
                    case "fry":
                        {
                            Console.WriteLine("Milyen húst szeretnél sütni? (pl. StripsMeat)");
                            string meatType = Console.ReadLine();
                            if (loader.Meats.Contains(meatType))
                            {
                                Console.WriteLine("Hány darabot sütsz? (pl. 30)");
                                bool isParsable = int.TryParse(Console.ReadLine(), out int meatCount);
                                if (isParsable)
                                {
                                    switch (meatType)
                                    {
                                        case "StripsMeat":
                                            {
                                                meatHolder.AddToContainer(new StripsMeat(meatCount));
                                                Console.WriteLine("Sikeresen hozzaadva.");
                                                break;
                                            }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Hiba: Nem számot adtál meg!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Hiba: Nem megfelelő hús típus!");
                            }
                            break;
                            
                        }
                    case "?":
                        {
                            Console.WriteLine("A suteshez hasznald a 'fry' parancsot.");
                            break;
                        }
                    default: { Console.WriteLine("Helytelen parancs!"); break; } ;
                }
            }

        }

    }
}
