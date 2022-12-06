using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRCDT
{
    public class MeatHolder
    {
        public List<Meat> Container;
        public MeatHolder()
        {
            this.Container = new List<Meat>();
        }

        public void AddToContainer(Meat meat)
        {
            Container.Add(meat);
        }

        public Meat RemoveFIFO()
        {
            if (Container.Count > 0)
            {
                return Container[0];
            }
            else throw new IndexOutOfRangeException("A tároló üres!");
        }

        public void RemoveExpired()
        {
            if (Container.Count > 0)
            {
                var query = Container.OrderBy(meat => meat.expirationDate);
                foreach(var meat in query)
                {
                    if (meat.expirationDate < DateTime.Now)
                    {
                        Container.Remove(meat);
                        Console.WriteLine("Eltávolítva: " + meat.amount + " db " + meat.GetType().Name);
                    }
                }
            }
            else Console.WriteLine("A tároló üres!");
        }

        public void PrintContainer()
        {
            if (Container.Count > 0)
            {
                foreach (Meat meat in Container)
                {
                    Console.WriteLine("Hús: " + meat.amount + " db " + meat.GetType().Name + " - Lejárati idő: " + meat.expirationDate);
                }
            }
            else Console.WriteLine("A tároló üres.");
        }
    }
}
