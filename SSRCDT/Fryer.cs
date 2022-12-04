using System;
using Meat;

namespace SSRCDT
{
    public class Fryer
    {
        private readonly bool isKentuckyType;
        private bool isFree;
        private TimeSpan cookingTime;
        private Meat meat;

        public Fryer(bool isKentuckyType)
        {
            this.isKentuckyType = isKentuckyType;
            this.isFree = true;
            this.cookingTime = 0;
            this.meat = null;
        }

        public fryMeat(Meat meat)
        {
            this.meat = meat;
            this.cookingTime = meat.cookingTime;
            //TODO remaining time
        }

        public freeFryer()
        {
            this.meat = null;
            this.cookingTime = 0;
        }
    }
}