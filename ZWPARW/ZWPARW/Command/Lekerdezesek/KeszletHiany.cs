using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZWPARW.Object;

namespace ZWPARW.Command.Lekerdezesek
{
    internal class KeszletHiany : ICommand
    {
        public string Name => "KeszletHiany";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres = "Leltar.xml")
        {
            SorKiir.fosor();

            foreach (LeltarAzonosito item in leltar.azonosito.Where(y => y.KivantDarabszam >= y.JelenDarabszam).OrderBy(y => y.KivantDarabszam - y.JelenDarabszam))
            {
                SorKiir sor = new SorKiir(item);
                sor.adat();
            }
            return leltar;
        }

        public void Help(string message = "")
        {
            Console.WriteLine("Keszlethianz szerint kiiratatja a leltar elemeit");
        }
    }
}
