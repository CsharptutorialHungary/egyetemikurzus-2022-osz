using System.Xml.Serialization;
using ZWPARW.Object;

namespace ZWPARW.Command.FelhasznaloParancs
{
    internal class FelhasznalokBeolvasasa : IUser
    {
        public string Name => "FelhasznalokBeolvasasa";

        public Users Execute(Users users)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Leltar));

            try
            {
                using (var read = File.OpenRead(Path.Combine(AppContext.BaseDirectory, "Users.xml")))
                {
                    if (serializer.Deserialize(read) is Users users1)
                    {
                        users = users1;
                    }
                }
                Sikeres.FelhasznalokBeolvas = true;
                return users;
            }
            catch (IOException)
            {
                Sikeres.FelhasznalokBeolvas = false;
                Console.WriteLine("Nem létezik a Users.xml fájl.");
            }

            if (Sikeres.FelhasznalokBeolvas == false)
            {
                Console.WriteLine("Alapertelmezet felhasznalo letrehozva");
                Console.WriteLine("Name: Admin");
                Console.WriteLine("Password: Admin");
                Console.WriteLine("Jogosultsaga: Admin");

                User user = new User(0, "Admin", "Admin", "Admin");
                users.Felhasznalok.Add(user);
            }
            return users;

        }

        public void Help()
        {
            Console.WriteLine("Beolvasa a felhasznalokat ha nem talalja a fajlt akkor letrehoz egz alapertelmezet felhasznalot");
        }
    }
}
