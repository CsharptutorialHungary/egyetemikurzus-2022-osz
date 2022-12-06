using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRCDT
{
    public record Kitchen
    {
        public List<Fryer> NormalFryers { get; init; }
        public List<Fryer> KentuckyFryers { get; init; }
        public Kitchen(List<Fryer> Normal, List<Fryer> Kentucky) {
            this.NormalFryers= Normal;
            this.KentuckyFryers= Kentucky;
        }

        public Kitchen()
        {
            this.NormalFryers= new List<Fryer> { new Fryer(false), new Fryer(false), new Fryer(false) };
            this.KentuckyFryers = new List<Fryer> { new Fryer(true) };
        }
        
        public int findFreeFryer(bool isKentucky)
        {
            if (isKentucky)
            {
                for (int i = 0; i < KentuckyFryers.Count; i++)
                {
                    if (KentuckyFryers[i].IsFree) { return i; }
                }
            }
            else if (!isKentucky)
            {
                for (int i = 0; i < NormalFryers.Count; i++)
                {
                    if (NormalFryers[i].IsFree) { return i; }
                }
            }
            else throw new ArgumentException("Rossz paraméter! Elvárt: bool");
            return -1;
        }

    }
}
