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
        public static int ColInput(int min, int max) {
            bool wrongInput = true;
            //AnsiConsole.Clear();
            while (wrongInput)
            {
                try
                {
                    Console.Write($"Adjon meg egy oszlopotd [{min}-{max}]: ");
                    int col = int.Parse(Console.ReadLine());
                    if (col >= min && col <= max)
                    {
                        wrongInput = false;
                        return col-1;
                    }
                    else AnsiConsole.WriteLine("[red]Rossz érték[/]");

                }
                catch (ArgumentNullException)
                {
                    AnsiConsole.WriteLine("[red]Rossz oszlop[/]");
                }
                catch (FormatException ex)
                {
                    AnsiConsole.WriteLine("[red]Rossz oszlop[/]");
                }
            }
            return -1;
        }
    }
}
