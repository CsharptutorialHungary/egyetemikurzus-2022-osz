using ZWPARW.Object;

namespace ZWPARW.Command
{
    internal class Lekerdezes : ICommand
    {
        public string Name => "Lekerdezes";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres)
        {
            LeltarAzonosito azonosito = leltar.azonosito.MinBy(y => y.JelenDarabszam);
            Console.WriteLine(azonosito.JelenDarabszam);

            return leltar;
        }

        public void Help(string message)
        {
            Console.WriteLine(message);
        }
    }
}
