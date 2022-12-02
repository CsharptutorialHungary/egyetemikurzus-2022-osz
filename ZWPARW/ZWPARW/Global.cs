using ZWPARW.Command.FajlSzerkesztes;
using ZWPARW.Object;

namespace ZWPARW
{
    static public class Global
    {
        public static bool sikeresBeolvasas = false;

        public static bool sikeresLetrehozva = false;

        public static bool FelhasznalokBeolvas = false;

        public static User? SikeresenBelepet;

        public static async Task BMentes(Leltar leltar)
        {
            BiztonsagiMentes biztonsagiMentes = new BiztonsagiMentes();
            Leltar leltar1 = leltar;
            var UserSetting = await Task.Run(() =>
            {
                return Task.FromResult(biztonsagiMentes.Execute(leltar1, ""));
            });

        }
        public static async Task Mentes(Leltar leltar)
        {
            if (!sikeresBeolvasas)
            {
                Mentes mentes = new Mentes();
                Leltar leltar1 = leltar;
                var UserSetting = await Task.Run(() =>
                {
                    return Task.FromResult(mentes.Execute(leltar1, ""));
                });
            }
        }
    }
}
