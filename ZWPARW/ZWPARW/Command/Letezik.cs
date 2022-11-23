using ZWPARW.Object;

namespace ZWPARW.Command
{
    internal class Letezik : ICommand
    {
        public string Name => "Letezik";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres = "Leltar.xml")
        {
            if (File.Exists(Path.Combine(AppContext.BaseDirectory, "Leltar.xml")) && eleres == "Leltar.xml")
            {
                Console.WriteLine("A fájl már létezik");
                Sikeres.sikeresLetrehozva = true;
            }
            else
            {
                Console.WriteLine("A fájl nem látezik");
                Sikeres.sikeresLetrehozva = false;
            }
            if (File.Exists(eleres) && eleres != "Leltar.xml")
            {
                Console.WriteLine("A fájl már létezik");
            }
            else
            {
                Console.WriteLine("A fájl nem látezik");
            }
            return leltar;
        }

        public void Help(string message)
        {
            throw new NotImplementedException();
        }
    }
}
