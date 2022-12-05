using System;

namespace SSRCDT
{
    public sealed class StripsMeat : Meat
    {
        public TimeSpan GetCookingTime()
        {
            return CookingTime;
        }

        public StripsMeat(int amount) : base(amount, new TimeSpan(0, 0, 30)) { }
    }
}