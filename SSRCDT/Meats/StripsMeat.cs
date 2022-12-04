using System;
using Meat;

namespace SSRCDT.Meats
{
    public sealed class StripsMeat : Meat
    {

        private TimeSpan cookingTime = new TimeSpan(0, 0, 30);

        public StripsMeat(int amount) : base(amount, this.cookingTime) { }
    }
}