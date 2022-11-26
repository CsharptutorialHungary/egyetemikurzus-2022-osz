using System.Xml.Serialization;
using ZWPARW.Object;

namespace ZWPARW.Command.FajlSzerkesztes
{
    internal class BiztonsagiMentes : ICommand
    {
        public string Name => "BiztonsagiMentes";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Leltar));

            string filename = $"BackUp_Leltar_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}_[{DateTime.Now.Hour}Hour_{DateTime.Now.Minute}Min].xml";

            string directory = Path.Combine(AppContext.BaseDirectory, "BackUp");

            if (!Directory.Exists(Path.Combine(AppContext.BaseDirectory, "BackUp")))
                Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, "BackUp"));


            using (var read = File.Create(Path.Combine(directory, filename)))
            {
                serializer.Serialize(read, leltar);
            }
            return leltar;
        }

        public void Help(string message)
        {
            Console.WriteLine("Biztonsági mentést csinál az adatokrol");
        }
    }
}
