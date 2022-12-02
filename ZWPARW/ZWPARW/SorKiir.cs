using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZWPARW.Object;

namespace ZWPARW
{
    internal record class SorKiir
    {
        public LeltarAzonosito leltarAzonosito { get; }

        public SorKiir(LeltarAzonosito leltarAzonosito)
        {
            this.leltarAzonosito = leltarAzonosito;
        }



        public static void fosor()
        {
            Console.WriteLine("Id\tTermek\tUtolso ellenorzes\tJelenlegi Darabszam\tKivant Darabszam\tBrutto ar\tSulya gramban");
        }

        public void adat()
        {
            Console.WriteLine($"{leltarAzonosito.id}\t{leltarAzonosito.Termek}\t{leltarAzonosito.UtolsoEllenorzes}\t{leltarAzonosito.JelenDarabszam}\t\t\t{leltarAzonosito.KivantDarabszam}\t\t\t{leltarAzonosito.BruttoAr}\t\t{leltarAzonosito.GramSulya}");
        }
    }
}
