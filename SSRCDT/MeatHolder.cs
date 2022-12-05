using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRCDT
{
    internal class MeatHolder
    {
        public List<Meat> Container;
        public MeatHolder()
        {
            this.Container = new List<Meat>();
        }

        public void AddToContainer(Meat meat)
        {
            this.Container.Append(meat);
        }
    }
}
