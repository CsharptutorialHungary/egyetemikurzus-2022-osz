using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace ConnectFive
{
    static internal class Renderer
    {
        static Table table = new Table().Centered().RoundedBorder();
        static LiveDisplay tableDisplay = AnsiConsole.Live(table);

        public static void DrawTable(GameBoard board)
        {
            for (int i = 1; i <= board.width; i++)
            {
                table.AddColumn($"{i}");
                table.Columns[i - 1].Width(2);
                table.Columns[i - 1].Centered();

            }
            for (int i = 0; i < board.height-1; i++)
            {
                table.AddRow(Enumerable.Repeat("O", board.width).ToArray<string>()).Alignment(Justify.Center);
            }
            AnsiConsole.Write(table);
        }
        public static void DrawCell(int x, int y, string text)
        {
            AnsiConsole.Clear();
            tableDisplay.Start(ctx =>
            {
                table.Rows.Update(x, y, new Markup(text));
                ctx.Refresh();
            });
        }

    }
}
