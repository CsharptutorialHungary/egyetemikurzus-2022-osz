using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFive
{
    internal class Input
    {
        public static int ColInput(int min, int max)
        {
            bool wrongInput = true;
            while (wrongInput)
            {
                Console.Write($"Adjon meg egy oszlopotd [{min}-{max}]: ");
                string input = Console.ReadLine() ?? "";
                try
                {
                    int col = int.Parse(input);
                    if (col >= min && col <= max)
                    {
                        wrongInput = false;
                        return col - 1;
                    }
                    else
                    {
                        AnsiConsole.Write(new Markup("[red] Rossz érték [/]"));
                        AnsiConsole.Cursor.MoveUp(1);
                        AnsiConsole.Cursor.MoveLeft(200);
                    }

                }
                catch (ArgumentNullException)
                {
                    AnsiConsole.Write(new Markup("[red]????[/]"));
                    AnsiConsole.Cursor.MoveUp(1);
                    AnsiConsole.Cursor.MoveLeft(200);
                }
                catch (FormatException)
                {
                    if (input.ToLower() == "save")
                        AnsiConsole.Write(new Markup("[red]Rossz oszlop[/]"));
                    AnsiConsole.Cursor.MoveUp(1);
                    AnsiConsole.Cursor.MoveLeft(200);
                }
            }
            return -1;
        }
    }
}
