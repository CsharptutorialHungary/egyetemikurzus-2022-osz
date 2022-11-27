using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Terminal.Gui.Trees;

namespace TUITodo.Views
{
    internal class TaskListView : TreeView
    {
        private List<TodoItem> items = new();

        public List<TodoItem> Items
        {
            get => items;
            protected set
            {
                items = value;
                base.ClearObjects();
                AddObjects(value);
            }
        }

        public StatusBar statusBar = new();

        public TaskListView(List<TodoItem>? items = null)
        {
            statusBar.Items = new StatusItem[]
            {
                new StatusItem(Key.E, "~Shift + E~ Edit task", () => {
                    if (SelectedObject is TodoItem selected) Program.EnterEditMode(selected);
                }),
                new StatusItem((Key)'+', "~+~ New task", () => {
                    AddItem(new TodoItem("New task"));
                }),
                new StatusItem((Key)'-', "~-~ New subtask", () => {
                    if (SelectedObject is TodoItem selected)
                        AddItem(new TodoItem("New subtask"), parent:selected);
                }),
                new StatusItem(Key.Space, "~Space~ Task complete", () => {
                    if (SelectedObject is TodoItem selected){
                        selected.ToggleDone();
                        SetNeedsDisplay(); 
                    }
                })
            };

            Items = items ?? new List<TodoItem>();


        }

        public void AddItem(TodoItem item, TodoItem? parent = null)
        {
            parent ??= ((TodoItem)SelectedObject)?.parentTask;

            if (parent == null) //add to root level
            {
                Items.Add(item);
                AddObject(item);
            }
            else //add as sibling
            {
                parent.AddSubtask(item);
                RefreshObject(parent);
            }

            this.Expand();
            this.GoTo(item);
        }


    }
}
