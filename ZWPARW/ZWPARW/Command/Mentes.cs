using System.Xml.Serialization;
using ZWPARW.Object;

namespace ZWPARW.Command
{
    internal class Mentes : ICommand
    {
        public string Name => "Mentes";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Leltar));

            using (var read = File.Create(Path.Combine(AppContext.BaseDirectory, eleres)))
            {
                serializer.Serialize(read, leltar);
            }

            return leltar;

        }

        public void Help(string message)
        {
            Console.WriteLine("Elmenti az adatokat amelyekent épen dolgozva van.");
        }
    }
}
