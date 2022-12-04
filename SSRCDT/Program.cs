using System;

namespace SSRCDT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello");
            System.Threading.Thread.Sleep(1000);
            Fryer fryer1 = new Fryer(false);
            Fryer fryer2 = new Fryer(false);
            Fryer fryer3 = new Fryer(false);
            Fryer fryer_kent = new Fryer(true);

            string input = "";

            while(input != "q")
            {
                Console.WriteLine("A kilepeshez nyomj q-t");
                input = Console.ReadLine();
                switch (input)
                {
                    case "fry":
                        {
                            Console.WriteLine("Milyen húst szeretnél sütni? (StripsMeat)");
                            string meatType = Console.ReadLine();
                            Console.WriteLine("Hány darabot sütsz? (szám)");
                            bool isParsable = int.TryParse(Console.ReadLine(), out int meatCount);
                            if (isParsable)
                            {
                                Console.WriteLine(meatType);
                                Console.WriteLine(meatCount);
                            }
                            else
                            {
                                Console.WriteLine("Hiba: Nem számot adtál meg!");
                            }
                            break;
                        }
                    default: break;
                }
            }

        }

    }
}
