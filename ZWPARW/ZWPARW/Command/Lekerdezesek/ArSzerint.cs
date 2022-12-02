using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZWPARW.Object;

namespace ZWPARW.Command.Lekerdezesek
{
    internal class ArSzerint : ICommand
    {
        public string Name => "ArSzerint";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres = "Leltar.xml")
        {
            SorKiir.fosor();

            foreach (LeltarAzonosito item in leltar.azonosito.OrderBy(y => y.BruttoAr))
            {
                SorKiir sor = new SorKiir(item);
                sor.adat();
            }
            return leltar;
        }

        public void Help(string message = "")
        {
            Console.WriteLine("Ar szerint kiiratatja a leltar elemeit");
        }
    }
}
