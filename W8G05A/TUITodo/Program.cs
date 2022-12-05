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
            Height = Dim.Fill(2) - 2
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


        public static async void DisplayStatusNotification(string message, int expireSeconds = 2)
        {
            statusBarMessage.Text = message;
            if(expireSeconds > 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(expireSeconds));
                statusBarMessage.Text = "";
            }

        }

        static StatusBar? activeStatusbar;
        static void SetStatusBar(StatusBar statusBar)
        {
            Application.Top.Remove(activeStatusbar);
            activeStatusbar = statusBar;
            Application.Top.Add(activeStatusbar);
        }


        private static void SwitchToView(View view)
        {
            MainWindow.RemoveAll();
            MainWindow.Add(view);
        }

        public static void EnterEditMode(TodoItem editedItem)
        {
            SwitchToView(EditorView);
            SetStatusBar(EditorView.statusBar);
            EditorView.StartEditing(editedItem);
        }

        public static void ShowTaskListView()
        {
            SetStatusBar(TaskListView.statusBar);
            SwitchToView(TaskListView);
        }

        static async Task Main()
        {

            List<TodoItem> savedTodos = await TodoItemSerializer.Deserialize() ?? new List<TodoItem>();

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

            //AddItem focuses the last item, let's go back to the top
            TaskListView.GoToFirst();

            Application.Top.Add(menu, MainWindow, statusBarMessage);

            Application.Driver.SetCursorVisibility(CursorVisibility.Invisible);
            Application.Run();
            Application.Shutdown();
        }

        public static void SaveTasks()
        {
            DisplayStatusNotification("Saving...", 0);
            Task.Run(async () => {
                await TodoItemSerializer.Serialize(TaskListView.Items);
                DisplayStatusNotification("Saved");
            });
        }
    }
}