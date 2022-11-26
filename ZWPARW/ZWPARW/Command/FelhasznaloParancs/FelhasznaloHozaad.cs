using ZWPARW.Object;

namespace ZWPARW.Command.FelhasznaloParancs
{
    internal class FelhasznaloHozaad : IUser
    {
        public string Name => "FelhasznaloHozzaad";

        public Users Execute(Users users)
        {
        start:
            Console.WriteLine("Username");
            string name = Console.ReadLine();

            Console.WriteLine("Password");
            string pass = Console.ReadLine();

            Console.WriteLine("Rang");
            string rank = Console.ReadLine();

            var foglalat = users.Felhasznalok.Where(y => y.Name.Equals(name));
            if (foglalat.Any()) { Console.WriteLine("Foglalt a felhasznalo"); goto start; }
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(rank)) { Console.WriteLine("Ures maradt valamelyik mezo"); return users ; }

            int id = users.Felhasznalok.Max(y=>y.Id);
            id++;

            User user = new User(id, name, pass, rank);

            users.Felhasznalok.Add(user);

            Console.WriteLine("Felhasznalo Hozaadva a rendszerhez");

            return users;
        }

        public void Help()
        {
            Console.WriteLine("Ha megfeleo jogosultsagal vagz belepve felhasznalot addhatsz hozza a rendszerhez");
        }
    }
}
