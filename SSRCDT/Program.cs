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
            Kitchen kitchen = new Kitchen();
            //List<Fryer> normal_fryers = new List<Fryer> { new Fryer(false), new Fryer(false), new Fryer(false) };
            //List<Fryer> kentucky_fryers = new List<Fryer> { new Fryer(true) };
            MeatHolder meatHolder = new MeatHolder();
            //TODO record class ami tarolja a sutoket es a methodokat

            string input = "";
            Console.WriteLine("LFV Hússütöde");
            Console.WriteLine("Segítségért használd a '?' parancsot.");
            Console.WriteLine("Kilépés: 'q' parancs.");
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
                                bool isKentucky = meatType == "KentuckyMeat" ? true : false;
                                int index = kitchen.findFreeFryer(isKentucky);

                                if (index == -1) { Console.WriteLine("Nincs szabad sütő ehhez a húshoz!"); break; }

                                Console.WriteLine("Hány darabot sütsz? (pl. 30)");
                                bool isParsable = int.TryParse(Console.ReadLine(), out int meatCount);
                                if (isParsable)
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
                    case "printContainer":
                        {
                            meatHolder.PrintContainer();
                            break;
                        }
                    case "removeExpired":
                        {
                            meatHolder.RemoveExpired();
                            break;
                        }
                    case "?":
                        {
                            Console.WriteLine("A sütéshez használd a fry parancsot.");
                            Console.WriteLine("Lehetséges húsok: 'KentuckyMeat', 'StripsMeat', 'WingsMeat'");
                            Console.WriteLine("A tároló kiírata: printContainer");
                            Console.WriteLine("Romlott húsok kivétele a tárolóból: removeExpired");
                            break;
                        }
                    default: { if (input != "q") { Console.WriteLine("Helytelen parancs!"); } break; };
                }
            }

        }

    }
}
