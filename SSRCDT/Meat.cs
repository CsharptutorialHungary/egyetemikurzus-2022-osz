using System;
using System.Xml.Serialization;

namespace SSRCDT
{
    public class Meat
    {
        public DateTime expirationDate { get; set; }
        public int amount { get; set; }
        public TimeSpan CookingTime { get; set; }

        public Meat () { } // Kell default konstruktor, foleg a Loaderhez

        public Meat(int amount, TimeSpan cookingTime)
        {
            this.amount = amount;
            expirationDate = DateTime.Now.AddMinutes(60);
            CookingTime = cookingTime;
        }

    }
}