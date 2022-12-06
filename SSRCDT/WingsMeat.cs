using System;

namespace SSRCDT
{
    public sealed class WingsMeat : Meat
    {
        public TimeSpan GetCookingTime()
        {
            return CookingTime;
        }
        public WingsMeat(int amount) : base(amount, new TimeSpan(0, 0, 20)) { }
        public WingsMeat() : base() { }
    }
}
