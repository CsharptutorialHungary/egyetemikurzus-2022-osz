using System;

namespace SSRCDT
{
    public class Meat
    {
        public DateTime expirationDate { get; }
        public int amount { get; }
        public TimeSpan CookingTime { get; internal set; }

        public Meat () { } // Kell default konstruktor, foleg a Loaderhez

        public Meat(int amount, TimeSpan cookingTime)
        {
            this.amount = amount;
            expirationDate = DateTime.Now.AddMinutes(60);
            CookingTime = cookingTime;
        }

    }
}