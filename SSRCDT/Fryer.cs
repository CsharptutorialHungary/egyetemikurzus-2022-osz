using System;
using System.Threading;
using System.Threading.Tasks;

namespace SSRCDT
{
    public class Fryer
    {
        public bool IsKentuckyType { get; }
        public bool IsFree { get; set; }
        public TimeSpan CookingTime { get; set; }
        public Meat meat { get; set; }

        public Fryer(bool isKentuckyType)
        {
            this.IsKentuckyType = isKentuckyType;
            IsFree = true;
            CookingTime = new TimeSpan(0, 0, 0);
            meat = null;
        }

        public async Task FryMeat(Meat meat, MeatHolder meatHolder)
        {
            try
            {
                this.meat = meat;
                this.IsFree = false;
                CookingTime = meat.CookingTime;
                Console.WriteLine(meat.amount + " db " + meat.GetType().Name + " bekerult a sutobe...");
                Task<Meat>.Delay(CookingTime).Wait();
                this.IsFree = true;
                Console.WriteLine(meat.amount + " db " + meat.GetType().Name + " Megsult! Taroloba helyezes...");
                meatHolder.AddToContainer(meat);
                Console.WriteLine("Behelyezve a taroloba!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void FreeFryer()
        {
            meat = null;
            CookingTime = new TimeSpan(0, 0, 0);
        }
    }
}