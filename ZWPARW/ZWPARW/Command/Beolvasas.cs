using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZWPARW.Object;

namespace ZWPARW.Command
{
    internal class Beolvasas : ICommand
    {
        public string Name => "Beolvasas";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Leltar));

            try
            {

                if (eleres == "Leltar.xml")
                {
                    using (var read = File.OpenRead(Path.Combine(AppContext.BaseDirectory, eleres)))
                    {
                        if (serializer.Deserialize(read) is Leltar leltar1)
                        {
                            leltar = leltar1;
                        }
                    }
                }
                else
                {
                    using (var read = File.OpenRead(eleres))
                    {
                        if (serializer.Deserialize(read) is Leltar leltar1)
                        {
                            leltar = leltar1;
                        }
                    }
                }
                SikeresBeolvasas.sikeresBeolvasas = true;
            }
            catch (IOException)
            {
                SikeresBeolvasas.sikeresBeolvasas = false;
                Console.WriteLine("Nem létezik a fájl.");
            }

            return leltar;
        }

        public void Help(string message)
        {
            throw new NotImplementedException();
        }
    }
}
