using ZWPARW.Object;

namespace ZWPARW.Command.FelhasznaloParancs
{
    internal class FelhasznalokKiiratasa : IUser
    {
        public string Name => "FelhasznalokKiiratasa";

        public Users Execute(Users users)
        {
            Console.WriteLine("Id\tFelhasznalonev\tJelszo\tRangja");
            foreach (var item in users.Felhasznalok)
            {
                Console.WriteLine($"{item.Id}\t{item.Name}\t\t{item.Password}\t{item.Rank}");
            }
            return users;
        }

        public void Help()
        {
            Console.WriteLine("Kiirja a felhasznalokat");
        }
    }
}
