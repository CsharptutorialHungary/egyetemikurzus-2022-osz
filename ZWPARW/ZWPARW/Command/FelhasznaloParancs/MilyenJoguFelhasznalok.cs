using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZWPARW.Object;

namespace ZWPARW.Command.FelhasznaloParancs
{
    internal class MilyenJoguFelhasznalok : IUser
    {
        public string Name => "MilyenJoguFelhasznalok";

        public Users Execute(Users users)
        {
            var felh = users.Felhasznalok.GroupBy(x => x.Rank);

            foreach (var fel in felh)
            {
                Console.WriteLine($"{fel.Key}  Db:{felh.Count()}");
                foreach(User user in fel)
                {
                    Console.WriteLine($"\t{user.Name}");
                }
            }
            return users;
        }

        public void Help()
        {
            Console.WriteLine("Felhaszalo jogok");
        }
    }
}
