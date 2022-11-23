using System.Xml.Serialization;
using ZWPARW.Object;

namespace ZWPARW.Command
{
    internal class Letrehoz : ICommand

    {
        public string Name => "Letrehoz";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres)
        {
            string filename = Path.Combine(AppContext.BaseDirectory, eleres);

            if (File.Exists(filename))
            {
                Console.WriteLine("A fájl már létezik nem kell ujat létrehozni");
                Sikeres.sikeresLetrehozva = true;
            }
            else
            {
                XmlSerializer serializer = new(typeof(Leltar));

                using (var create = File.Create(filename))
                {
                    serializer.Serialize(create, leltar);
                }
                Sikeres.sikeresLetrehozva = true;

            }

            return leltar;
        }

        public void Help(string message)
        {
            throw new NotImplementedException();
        }
    }
}
