using ZWPARW;
using ZWPARW.Object;
internal class Program
{

    static void Main(string[] args)
    {
        try
        {
            Leltar leltar = new Leltar();

            Users users = new Users();

            CommandLoader loader = new CommandLoader();

            UsersLoader usersLoader = new UsersLoader();

            leltar = loader.Commands["Beolvasas"].Execute(leltar);

            users = usersLoader.UserCommands["FelhasznalokBeolvasasa"].Execute(users);

            if (Sikeres.sikeresBeolvasas)
            {
                Task t = new Task(async () => loader.Commands["BiztonsagiMentes"].Execute(leltar));

                t.Start();
            }
        Belepes:
            Console.Write("Felhasznalonev: ");
            string username = Console.ReadLine();
            Console.Write("Jelszo: ");
            string password = Console.ReadLine();

            var user = users.Felhasznalok.Where(y => y.Name.Equals(username) && y.Password.Equals(password));
            if (user.Count() != 0)
            {
                foreach (User item in user)
                {
                    Sikeres.SikeresenBelepet = item;
                }
                while (true)
                {
                    Console.WriteLine("Add meg a parancsot:  ");
                    string command = Console.ReadLine();

                    if (!string.IsNullOrEmpty(command))
                    {
                        string[] commands = command.Split(" ");
                        if (commands[0] == "User")
                        {
                            if (Sikeres.SikeresenBelepet.Rank.Equals("Admin"))
                            {
                                if (commands.Length >=2 && usersLoader.UserCommands.ContainsKey(commands[1]))
                                {
                                    if (commands.Length >= 3 && commands[2].ToLower().Equals("help"))
                                    {
                                        usersLoader.UserCommands[commands[1]].Help();
                                    }
                                    else
                                    {
                                        users = usersLoader.UserCommands[commands[1]].Execute(users);
                                    }
                                }
                                else
                                {
                                    usersLoader.UserCommands["UserHelp"].Execute(users);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nincs admin Joga");
                                continue;
                            }
                        }
                        else if (commands[0] == "Leltar")
                        {
                            if (commands.Length >= 3 && commands[2].ToLower().Equals("help"))
                            {
                                loader.Commands[commands[1]].Help();
                            }
                            else
                            {
                                leltar = loader.Commands[commands[1]].Execute(leltar);
                            }
                        }
                        else
                        {
                            usersLoader.UserCommands["UserHelp"].Execute(users);
                            loader.Commands["Help"].Execute(leltar);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ures parancs lett megadva");
                    }


                }

            }
            else
            {
                Console.WriteLine("Nem jo a felhasznalonev vagy a jelszo probalf ujra");
                goto Belepes;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba: {ex.Message}");
        }
    }
}