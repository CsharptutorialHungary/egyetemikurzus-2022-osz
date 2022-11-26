using ZWPARW.Object;

namespace ZWPARW.Command
{
    internal class Lekerdezes : ICommand
    {
        public string Name => "Lekerdezes";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres)
        {
            Console.WriteLine("Termek\tUtolso ellenorzes\tJelenlegi Darabszam\tKivant Darabszam\tBrutto ar\tSulya gramban");

            foreach (var elem in leltar.azonosito)
            {
                Console.WriteLine($"{elem.Termek}\t{elem.UtolsoEllenorzes}\t{elem.JelenDarabszam}\t\t\t{elem.KivantDarabszam}\t\t\t{elem.BruttoAr}\t\t{elem.GramSulya}");
            }

            return leltar;
        }

        public void Help(string message)
        {
            Console.WriteLine("Kiirja a képernyőre ay ép aktuális adatokat");
        }
    }
}
