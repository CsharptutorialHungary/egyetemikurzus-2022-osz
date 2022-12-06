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
            this.meat = meat;
            this.IsFree = false;
            CookingTime = meat.CookingTime;
            Console.WriteLine("Cooking " + meat.amount + " db " + meat.GetType().Name);
            Task<Meat>.Delay(CookingTime).Wait();
            Console.WriteLine(meat.amount + " db " + meat.GetType().Name +  " Cooked! Placing in container...");
            meatHolder.AddToContainer(meat);
            Console.WriteLine("Added to container!");
        }

        public void FreeFryer()
        {
            meat = null;
            CookingTime = new TimeSpan(0, 0, 0);
        }
    }
}