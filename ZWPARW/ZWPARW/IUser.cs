using ZWPARW.Object;

namespace ZWPARW
{
    internal interface IUser
    {
        string Name { get; }

        Users Execute(Users users);

        void Help();
    }
}
