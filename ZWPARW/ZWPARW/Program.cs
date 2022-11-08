using System.Buffers;
using System.Xml.Serialization;
using ZWPARW;
using ZWPARW.Object;

try
{
    XmlSerializer serializer = new XmlSerializer(typeof(Leltar));

    Leltar leltar = new Leltar();

    using (var read = File.OpenRead(Path.Combine(AppContext.BaseDirectory, "Leltar.xml")))
    {
        if (serializer.Deserialize(read) is Leltar leltar1)
        {
            leltar = leltar1;
        }
    }

    CommandLoader loader = new CommandLoader();

    while (true)
    {
        Console.WriteLine("Type Command:  ");
        string command = Console.ReadLine();
        string[] commands = command.Split(" ");
        if (!string.IsNullOrEmpty(commands[0]) && loader.Commands.ContainsKey(commands[0]))
        {
            if (commands.Length >= 2 &&!string.IsNullOrEmpty(commands[1]) && commands[1].ToLower().Equals("help"))
            {
                loader.Commands[commands[0]].Help("Itt kivanak irva az adatok amik szerepelnek a leltárban");

            }
            else
            {
                leltar = loader.Commands[commands[0]].Execute(leltar);
            }
        }
        else
        {
            Console.WriteLine("Samting went wrong");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Hiba: {ex.Message}");
}
