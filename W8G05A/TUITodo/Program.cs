using Terminal.Gui;
using Terminal.Gui.Trees;
using TUITodo.Views;

namespace TUITodo
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Application.Init();

            #region Color scheme
            Colors.Base.Normal = Application.Driver.MakeAttribute(Color.Green, Color.Black);
            Colors.Base.HotNormal = Application.Driver.MakeAttribute(Color.Brown, Color.Black);
            #endregion

            #region MenuBar

            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_Quit", "", () => {
                        Application.RequestStop ();
                    })
                }),
            });

            #endregion



            var win = new Window("Task list")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 1
            };


            var micsin = new TodoItem("subtask", "asd", new List<TodoItem> { new TodoItem("micsin", "asd"), new TodoItem("nenen") });
            TodoItem t = new TodoItem("Feladatka", "Ez egy taszk", new List<TodoItem> { micsin, new TodoItem("kettes") });

            var tasklist = new TaskListView(new List<TodoItem> { t })
            {
                X = 1,
                Y = 1,
                Width = 40,
                Height = Dim.Percent(60)
            };
            win.Add(tasklist);

            tasklist.ExpandAll();


            Application.Top.Add(menu, win);
            Application.Run();
            Application.Shutdown();
        }
    }
}