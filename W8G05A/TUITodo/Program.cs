using System.Text;
using Terminal.Gui;
using Terminal.Gui.Trees;
using TUITodo.Views;

namespace TUITodo
{
    internal class Program
    {
        #region Views
        public static View MainWindow { get; protected set; } = new Window("Task list")
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1
        };

        public static TaskListView TaskListView { get; protected set; } = new()
        {
            X = 1,
            Y = 1,
            Width = 40,
            Height = Dim.Percent(60)
        };

        public static EditorView EditorView { get; protected set; } = new()
        {
            X = 1,
            Y = 1,
            Width = 40,
            Height = Dim.Percent(60)
        };

        #endregion

        public static void SwitchToView(View view)
        {
            MainWindow.RemoveAll();
            MainWindow.Add(view);
            if(view == EditorView)
            {
                MainWindow.Add(EditorView.statusBar);
            }
        }

        static void Main(string[] args)
        {
            Application.Init();

            #region Color scheme, style setup
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


            var micsin = new TodoItem("subtask", "asd", new List<TodoItem> { new TodoItem("micsin", "asd"), new TodoItem("nenen") });
            TodoItem t = new TodoItem("Feladatka", "Ez egy taszk", new List<TodoItem> { micsin, new TodoItem("kettes") });

            TaskListView.AddItem(t);

            SwitchToView(TaskListView);

            TaskListView.ExpandAll();

            Application.Top.Add(menu, MainWindow);

            Application.Driver.SetCursorVisibility(CursorVisibility.Invisible);
            Application.Run();
            Application.Shutdown();
        }
    }
}