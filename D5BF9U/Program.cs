﻿using System.Text;
using System.Text.Json;
using System.Xml.Schema;
using D5BF9U;
using D5BF9U.AutoTasks;
using D5BF9U.Handlers;
using Spectre.Console;

/*
Table valami = new Table();
int x = 0;
BarChart chart = new BarChart().Width(60)
    .Label("[green bold underline]Number of fruits[/]")
    .CenterLabel()
    .AddItem("Apple", x, Color.Yellow)
    .AddItem("Orange", 54, Color.Green)
    .AddItem("Banana", 33, Color.Red);


valami.AddColumn("foo");
valami.AddRow(chart);

AnsiConsole.Live(valami)
    .Start(ctx => 
    {
        ctx.Refresh();
        for (int i = 0; i < 80; i++)
        {
            x = i;
            ctx.UpdateTarget(valami);
            Thread.Sleep(30);
        }
        
        
        ctx.Refresh();
        Thread.Sleep(1000);
    });
    */ //todo test later on stable release, tho supposed to work

string[] nem = new[] { "ceh", "nem", "igen", "minek" };

Table root = new Table();
root.AddColumn("").Width(40);
/*root.AddColumn("");
root.AddColumn("npc.Name"); ;
Panel vala = new Panel("player \nsmlaks\nlehulelel");
vala.Header = new PanelHeader("info log");
root.Caption = new TableTitle("alulvonás");*/
string valak = "mivan???";
//root.AddRow(,new Markup("csa"),new Markup("ha"));
BarChart fave = new BarChart().Width(50).AddItem(valak, 20, color: Color.Green);
//root.AddRow(new BarChart().Width(20).AddItem("health",20,color: Color.Green));
double i = 0;
root.AddRow(fave);
var grid = new Grid();

grid.AddColumn();
grid.AddColumn();
grid.AddColumn();

// Add header row 
grid.AddRow(new Markup[]
{
    new Markup("[red]Header 1[/]").LeftAligned(),
    new Markup("Header 2", new Style(Color.Green, Color.Black)).Centered(),
    new Markup("Header 3", new Style(Color.Blue, Color.Black)).RightAligned()
});
grid.AddRow("sss", "mesélj", "mizu");

AnsiConsole.Write(new Markup(UIOperator.ColoredStringBuilder("[red]","Congratulations!")));
AnsiConsole.Write(new Markup(UIOperator.ColoredStringBuilder("[red]","Congratulations!")));
root.AddRow(grid);
root.AddRow(new Panel("vhali\njli\nknuuk\nlsks ksks").Header("log"));
root.HideHeaders();
StringBuilder stringBuilder = new StringBuilder();
stringBuilder.Append("valamiiiiiiiiii");
Console.WriteLine(stringBuilder.ToString());
stringBuilder.Append("ááááááááááááááááááááááá");
Console.WriteLine(stringBuilder.ToString());

string valami = "";
byte[] tmp= {0x79,0x6F,0x75,0x27,0x76,0x65,0x20,0x6A,0x75,0x73,0x74,0x20,0x61,0x63,0x71,0x75,0x69,0x72,0x65,0x64,0x20,0x61,0x20,0x6E,0x65,0x77,0x20,0x73,0x65,0x78,0x20,0x6F,0x62,0x6A,0x65,0x63,0x74,0x21};
//root.UpdateCell(0,2,)
Console.WriteLine(Encoding.ASCII.GetString(tmp));
AnsiConsole.Live(root).Start(ui =>
{
    while (true)
    {
        //root.UpdateCell(0,2,)
        ui.Refresh();
        
        i = (i +0.1) % 40;
        //TODO WITH MAX VALUE!!!! damn it took 2 and a half hours just finding it and in the end i found a description in the github issues
        //https://github.com/spectreconsole/spectre.console/pull/545
        valak = "heeeeee?";
        int nemka = 0;
        ConsoleKeyInfo keyInfo =  Console.ReadKey(true);
        if (char.IsDigit(keyInfo.KeyChar))
        {
            nemka = int.Parse(keyInfo.KeyChar.ToString());
        }
        root.UpdateCell(0,0,new BarChart().Width(40).AddItem(keyInfo.KeyChar.ToString()+$"{nemka==4}", Math.Round(i,1), Color.Green).WithMaxValue(40));
        
        // fave.Data[0] = new BarChartItem("health", i, Color.Green);
        ui.UpdateTarget(root);
        ui.Refresh();
        Thread.Sleep(14);
       // Console.ReadKey();
        
            /*root.Rows.Update(0,0,
    ui.UpdateTarget(root.UpdateCell(0));*/ ;
    }
});

/*string valami = "hello";
string tmp = valami;*/
string v2 = "world";
//okay it works, but had to update to dotnet 7
//Console.WriteLine(Interlocked.CompareExchange(ref valami,v2,valami));
Console.WriteLine(valami);
//i see now ahaaa

Console.ReadKey();
var g1 =Game.GameOn();
Task.WaitAll(g1);