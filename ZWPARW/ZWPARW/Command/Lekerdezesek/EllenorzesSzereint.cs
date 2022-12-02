using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZWPARW.Object;

namespace ZWPARW.Command.Lekerdezesek
{
    internal class EllenorzesSzereint : ICommand
    {
        public string Name => "EllenorzesSzereint";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres = "Leltar.xml")
        {
            SorKiir.fosor();

            foreach (LeltarAzonosito item in leltar.azonosito.OrderBy(y=>y.UtolsoEllenorzes))
            {
                SorKiir sor = new SorKiir(item);
                sor.adat();
            }
            return leltar;

        }

        public void Help(string message = "")
        {
            Console.WriteLine("Utolso ellenorzes szerint kiiratatja a leltar elemeit");
        }
    }
}
