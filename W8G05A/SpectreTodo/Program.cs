// See https://aka.ms/new-console-template for more information
using BallerTODO.Views;
using Spectre.Console;

Console.WriteLine("Hello, World!");

string[] tasks = { "" };

//var panel = new Panel("Hello World\nIs this a problem?");
//panel.Header = new PanelHeader("Some text");
//panel.Border = BoxBorder.Rounded;
//AnsiConsole.Write(panel);

await TaskView.Draw();