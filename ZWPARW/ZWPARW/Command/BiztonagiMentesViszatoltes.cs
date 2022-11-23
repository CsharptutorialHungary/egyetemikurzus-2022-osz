using ZWPARW.Object;

namespace ZWPARW.Command
{
    internal class BiztonagiMentesViszatoltes : ICommand
    {
        public string Name => "BiztonagiMentesViszatoltes";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres)
        {
            string directory = Path.Combine(AppContext.BaseDirectory, "BackUp");

            var elemek = Directory.GetFiles(directory);

            for (int i = 0; i < elemek.Length; i++)
            {
                Console.WriteLine(i + ". " + elemek[i].Split("\\").Last());
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Add meg a viszaálitani kivánt fájl számát");
                    string i = Console.ReadLine();
                    int szam = int.Parse(i);

                    CommandLoader commandLoader = new CommandLoader();

                    leltar = commandLoader.Commands["Beolvasas"].Execute(leltar, elemek[szam]);

                }
                catch (Exception e) when (e is FormatException || e is NullReferenceException)
                {
                    Console.WriteLine("Nem számot adtál meg.");
                    break;
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("Tull nagy számot adtál meg.");
                    break;

                }
            }
            return leltar;
        }

        public void Help(string message)
        {
            throw new NotImplementedException();
        }
    }
}
