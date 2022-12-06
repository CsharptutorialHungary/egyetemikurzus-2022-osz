using NStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Terminal.Gui.Trees;
using TUITodo.Utils;

namespace TUITodo.Views
{
    internal class TaskListView : View
    {
        TaskTree taskTree;
        TextField searchField;
        Label searchLabel;
        Label description;

        public StatusBar statusBar = new();
        TodoItem? selectedItem => (TodoItem)taskTree.SelectedObject;
        List<TodoItem> todos = new();

        public TaskListView()
        {
            taskTree = new()
            {
                X = 0,
                Y = 1,
                Width = Dim.Percent(70),
                Height = Dim.Fill()
            };
            searchLabel = new()
            {
                X = Pos.Right(taskTree) + 2,
                Y = 0,
                Width = Dim.Fill(),
                Height = 1,
                Text = "Search"
            };
            searchField = new()
            {
                X = Pos.Right(taskTree) + 2,
                Y = Pos.Bottom(searchLabel),
                Width = Dim.Fill(),
                Height = 2,
            };
            description = new()
            {
                X = Pos.Right(taskTree) + 2,
                Y = Pos.Bottom(searchField),
                Width = Dim.Fill(),
                Height = 10,
            };


            #region status bar items
            statusBar.Items = new StatusItem[]
            {
                //Vannak olyan keyek, amiket az életbe nem érzékel
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
                }),
                new (Key.F, "~Shift + F~ Search", () => {
                    searchField.SetFocus();
                })
            };

            #endregion

            Add(taskTree, searchField, searchLabel, description);

            searchField.TextChanged += (ustring searchText) => {
                //a searchText valamiért le van maradva itt eggyel szóval nem azt használjuk
                taskTree.Items = FilterTree((string)searchField.Text);
                taskTree.ExpandAll();
            };

            taskTree.SelectionChanged += (object? sender, SelectionChangedEventArgs<ITreeNode> e) =>
            {
                if (selectedItem != null) description.Text = selectedItem.description;
            };

            
        }

        public async Task LoadSavedTasks()
        {
            todos = await TodoItemSerializer.Deserialize() ?? new List<TodoItem>();

            todos.ForEach(t => taskTree.AddItem(t));

            taskTree.ExpandAll();

            //AddItem az utolsóra rakja a fókuszt, szóval vissza az elejére
            taskTree.GoToFirst();
        }

        public async Task SaveTasks()
        {
            await TodoItemSerializer.Serialize(taskTree.Items);
        }

        List<TodoItem> FilterTree(string query)
        {
            query = query.Trim().ToLower();

            if (query == "") return todos;

            return todos.Where(t => MatchesQuery(t,query) || t.Subtasks.Any(t => MatchesQuery(t, query))).ToList();
        }

        bool MatchesQuery(TodoItem item, string query)
        {
            return item.name.ToLower().Contains(query) || item.description.Contains(query);
        }
    }
}
