using System;

namespace SSRCDT.Meats
{
    public class Meat
    {
        private DateTime expirationDate;
        private int amount;
        private TimeSpan cookingTime;

        public Meat(int amount, DateTime cookingTime)
        {
            this.amount = amount;
            this.expirationDate = DateTime.Now.AddMinutes(60);
            this.cookingTime = cookingTime;
        }
    }
}