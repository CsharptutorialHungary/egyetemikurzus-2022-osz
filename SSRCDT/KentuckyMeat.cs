using System;

namespace SSRCDT
{
    public sealed class KentuckyMeat : Meat 
    {
        public TimeSpan GetCookingTime()
        {
            return CookingTime;
        }
        public KentuckyMeat(int amount) : base(amount, new TimeSpan(0, 0, 25)) { }

    }
}
