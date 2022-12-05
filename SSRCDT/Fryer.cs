using System;

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

        public void FryMeat(Meat meat)
        {
            this.meat = meat;
            this.IsFree = false;
            CookingTime = meat.CookingTime;
            Console.WriteLine("Cooking...");
            //TODO remaining time
        }

        public void FreeFryer()
        {
            meat = null;
            CookingTime = new TimeSpan(0, 0, 0);
        }
    }
}