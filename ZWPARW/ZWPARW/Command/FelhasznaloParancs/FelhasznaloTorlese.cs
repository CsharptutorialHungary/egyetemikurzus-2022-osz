using ZWPARW.Object;

namespace ZWPARW.Command.FelhasznaloParancs
{
    internal class FelhasznaloTorlese : IUser
    {
        public string Name => "FelhasznaloTorlese";

        public Users Execute(Users users)
        {
            UsersLoader usersLoader = new UsersLoader();
            usersLoader.UserCommands["FelhasznalokKiiratasa"].Execute(users);
            try
            {
                Console.WriteLine("Torolni kivant felhasznalo idja");
                int Id = int.Parse(Console.ReadLine());

                var user = users.Felhasznalok.Where(y => y.Id.Equals(Id));

                foreach (User item in user)
                {
                    if (!item.Id.Equals(Global.SikeresenBelepet.Id))
                    {
                        users.Felhasznalok.Remove(item);
                    }
                    else
                    {
                        Console.WriteLine("Sajat magadat nem torolheted");
                        return users;
                    }
                }

            }
            catch (Exception e) when (e is FormatException || e is NullReferenceException)
            {
                Console.WriteLine("Nem megfelelo formátumot adtál meg");
            }
            return users;
            throw new NotImplementedException();
        }

        public void Help()
        {
            Console.WriteLine("Felhesznalo Torlese");
        }
    }
}
