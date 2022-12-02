using System.Xml.Serialization;
using ZWPARW.Object;

namespace ZWPARW.Command.FelhasznaloParancs
{
    internal class FelhasznalokMentese : IUser
    {
        public string Name => "FelhasznalokMentese";

        public Users Execute(Users users)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Users));

            using (var read = File.Create(Path.Combine(AppContext.BaseDirectory, "Users.xml")))
            {
                serializer.Serialize(read, users);
            }

            return users;
        }

        public void Help()
        {
            Console.WriteLine("Felhasznalokat elmenti");
        }
    }
}
