using ZWPARW.Object;

namespace ZWPARW.Command.Lekerdezesek
{
    internal class Lekerdezes : ICommand
    {
        public string Name => "Lekerdezes";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres)
        {
            SorKiir.fosor();

            foreach (var elem in leltar.azonosito)
            {
                SorKiir sor = new SorKiir(elem);
                sor.adat();
            }

            return leltar;
        }

        public void Help(string message)
        {
            Console.WriteLine("Kiirja a képernyőre ay ép aktuális adatokat");
        }
    }
}
