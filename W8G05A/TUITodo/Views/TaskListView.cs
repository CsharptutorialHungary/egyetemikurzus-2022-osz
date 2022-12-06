using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using TUITodo.Utils;

namespace TUITodo.Views
{
    internal class TaskListView : View
    {
        public TaskTree taskTree = new TaskTree
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        public StatusBar statusBar = new();
        TodoItem? selectedItem => (TodoItem)taskTree.SelectedObject;

        public TaskListView()
        {

            #region status bar items
            statusBar.Items = new StatusItem[]
            {
                //Vannak olyan keyek, amikre az életbe nem érzékel
                //Totál random hogy melyik működik
                //Ezért hülyeségek a gombválasztások
                new (Key.E, "~Shift + E~ Edit task", () => {
                    if (selectedItem != null) Program.EnterEditMode(selectedItem);
                }),
                new ((Key)'+', "~+~ New task", () => {
                    taskTree.AddItem(new TodoItem("New task"));
                }),
                new ((Key)'-', "~-~ New subtask", () => {
                    if (selectedItem != null)
                        taskTree.AddItem(new TodoItem("New subtask"), parent:selectedItem);
                }),
                new (Key.Space, "~Space~ Task complete", () => {
                    if (selectedItem != null){
                        selectedItem.ToggleDone();
                        taskTree.SetNeedsDisplay();
                        Program.SaveTasks();
                    }
                }),
                new (Key.D, "~Shift + D~ Delete", () => {
                    if (selectedItem != null){
                        if (MessageBox.Query("Delete task",
                            $"Are you sure you want to delete the task '{selectedItem.name}'?",
                            "Delete it", "Nevermind") == 0) taskTree.DeleteItem(selectedItem);
                    }
                })
            };

            #endregion

            Add(taskTree);
        }

        public async Task LoadSavedTasks()
        {
            List<TodoItem> savedTodos = await TodoItemSerializer.Deserialize() ?? new List<TodoItem>();
            savedTodos.ForEach(t => taskTree.AddItem(t));

            taskTree.ExpandAll();

            //AddItem az utolsóra rakja a fókuszt, szóval vissza az elejére
            taskTree.GoToFirst();
        }

        public async Task SaveTasks()
        {
            await TodoItemSerializer.Serialize(taskTree.Items);
        }
    }
}
