using Microsoft.VisualStudio.TestTools.UnitTesting;
using KA2KWE_LNE7I2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA2KWE_LNE7I2.Tests
{
    [TestClass()]
    public class KutyaTests
    {
        [TestMethod()]
        public void KutyaTest()
        {
            Kutya Dinnye = new Kutya(1, "Dinnye", true);

            Assert.AreEqual(1, Dinnye.Kor);
        }

        [TestMethod()]
        public void EtetTest()
        {
            Kutya Dinnye = new Kutya(1, "Dinnye", true);
            Dinnye = Dinnye.Etet();
            Assert.IsFalse( Dinnye.Ehes);
        }

        [TestMethod()]
        public void MegehezTest()
        {
            Kutya Dinnye = new Kutya(1, "Dinnye", false);
            Dinnye = Dinnye.Megehez();
            Assert.IsTrue(Dinnye.Ehes);
        }

        [TestMethod()]
        public void OregedesTest()
        {
            Kutya Dinnye = new Kutya(1, "Dinnye", true);
            Dinnye= Dinnye.Oregedes();
            Assert.AreEqual(2,Dinnye.Kor);
        }

        [TestMethod()]
        public void EvszamkonvertalasTest()
        {
            Kutya Dinnye = new Kutya(1, "Dinnye", true);
            int kutyaevben = Dinnye.Evszamkonvertalas();
            Assert.AreEqual(Dinnye.Kor*7,kutyaevben);
        }
    }
}