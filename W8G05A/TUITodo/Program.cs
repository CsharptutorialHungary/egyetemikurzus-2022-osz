using System.Linq.Expressions;
using System.Text;
using Terminal.Gui;
using Terminal.Gui.Trees;
using TUITodo.Utils;
using TUITodo.Views;

namespace TUITodo
{
    internal class Program
    {
        #region Views
        public static View MainWindow { get; } = new Window("Task list")
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 3
        };

        public static TaskListView TaskListView { get; } = new()
        {
            X = 1,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 2
        };

        public static EditorView EditorView { get; } = new()
        {
            X = 1,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 2
        };


        public static Label statusBarMessage { get; } = new()
        {
            X = 1,
            Y = Pos.Bottom(MainWindow),
            Width = Dim.Fill(),
            Height = 2,
        };

        #endregion

        private static async void DisplayStatusNotification(string message, int expireSeconds = 2)
        {
            statusBarMessage.Text = message;
            await Task.Delay(TimeSpan.FromSeconds(expireSeconds));
            statusBarMessage.Text = "";
        }

        private static void SwitchToView(View view)
        {
            MainWindow.RemoveAll();
            Application.Top.Add(MainWindow);
            MainWindow.Add(view);
        }

        public static void EnterEditMode(TodoItem editedItem)
        {
            Application.Top.RemoveAll();
            SwitchToView(EditorView);
            Application.Top.Add(EditorView.statusBar);
            EditorView.StartEditing(editedItem);
        }

        public static void ShowTaskListView()
        {
            Application.Top.RemoveAll();
            Application.Top.Add(TaskListView.statusBar);
            SwitchToView(TaskListView);
        }

        static async Task Main(string[] args)
        {

            List<TodoItem> savedTodos = await TodoItemSerializer.ReadFromJSON() ?? new List<TodoItem>();

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

            savedTodos.ForEach(t => TaskListView.AddItem(t));
            ShowTaskListView();

            TaskListView.ExpandAll();

            DisplayStatusNotification("HAO", 5);

            //AddItem focuses the last item, let's go back to the top
            TaskListView.GoToFirst();

            Application.Top.Add(menu, MainWindow, statusBarMessage);

            Application.Driver.SetCursorVisibility(CursorVisibility.Invisible);
            Application.Run();
            Application.Shutdown();
        }
    }
}