using ZWPARW.Object;

namespace ZWPARW
{
    internal interface ICommand
    {
        public string Name { get; }
        public string Description { get; }

        Leltar Execute(Leltar leltar, string eleres = "Leltar.xml");

        void Help(string message = "");


    }
}
