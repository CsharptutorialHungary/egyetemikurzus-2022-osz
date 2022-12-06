using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSRCDT
{
    class Program
    {
        static async Task Main(string[] args)
        {
            MeatTypeLoader loader = new MeatTypeLoader();
            Console.WriteLine("hello");
            Kitchen kitchen = new Kitchen();
            //List<Fryer> normal_fryers = new List<Fryer> { new Fryer(false), new Fryer(false), new Fryer(false) };
            //List<Fryer> kentucky_fryers = new List<Fryer> { new Fryer(true) };
            MeatHolder meatHolder = new MeatHolder();
            //TODO record class ami tarolja a sutoket es a methodokat

            string input = "";
            Console.WriteLine("Udv az appban!");
            Console.WriteLine("A segitsegert hasznald a '?' parancsot.");
            Console.WriteLine("Kilepes: 'q' parancs.");
            while (input != "q")
            {
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
                                    bool isKentucky = meatType == "KentuckyMeat" ? true : false;
                                    int index = kitchen.findFreeFryer(isKentucky);
                                    if (index != -1)
                                    {
                                        switch (meatType)  //Muszaj a switch. Elvileg az Activatorhoz tudnunk kene statikusan a tipust amire castolnank.
                                        {
                                            case "StripsMeat":
                                                {
                                                    _ = Task.Factory.StartNew(() => kitchen.NormalFryers[index].FryMeat(new StripsMeat(meatCount), meatHolder));
                                                    break;
                                                }
                                            case "WingsMeat":
                                                {
                                                    _ = Task.Factory.StartNew(() => kitchen.NormalFryers[index].FryMeat(new WingsMeat(meatCount), meatHolder));
                                                    break;
                                                }
                                            case "KentuckyMeat":
                                                {
                                                    _ = Task.Factory.StartNew(() => kitchen.KentuckyFryers[index].FryMeat(new KentuckyMeat(meatCount), meatHolder));
                                                    break;
                                                }
                                        }
                                    } else Console.WriteLine("Nincs szabad suto!");
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
                            Console.WriteLine("Lehetseges husok: 'KentuckyMeat', 'StripsMeat', 'WingsMeat'");
                            break;
                        }
                    default: { Console.WriteLine("Helytelen parancs!"); break; };
                }
            }

        }

    }
}
