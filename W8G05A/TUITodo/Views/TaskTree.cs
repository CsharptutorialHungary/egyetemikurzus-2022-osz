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
    internal class TaskTree : TreeView
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

        public TaskTree(List<TodoItem>? items = null)
        {
            #region status bar items
            statusBar.Items = new StatusItem[]
            {
                //Vannak olyan keyek, amikre az életbe nem érzékel
                //Totál random hogy melyik működik
                //Ezért hülyeségek a gombválasztások
                new (Key.E, "~Shift + E~ Edit task", () => {
                    if (SelectedObject is TodoItem selected) Program.EnterEditMode(selected);
                }),
                new ((Key)'+', "~+~ New task", () => {
                    AddItem(new TodoItem("New task"));
                }),
                new ((Key)'-', "~-~ New subtask", () => {
                    if (SelectedObject is TodoItem selected)
                        AddItem(new TodoItem("New subtask"), parent:selected);
                }),
                new (Key.Space, "~Space~ Task complete", () => {
                    if (SelectedObject is TodoItem selected){
                        selected.ToggleDone();
                        SetNeedsDisplay();
                        Program.SaveTasks();
                    }
                }),
                new (Key.D, "~Shift + D~ Delete", () => {
                    if (SelectedObject is TodoItem selected){
                        if (MessageBox.Query("Delete task", 
                            $"Are you sure you want to delete the task '{selected.name}'?",
                            "Delete it", "Nevermind") == 0) DeleteItem(selected);
                    }
                })
            };

            #endregion

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

        void DeleteItem(TodoItem item)
        {
            //Remove(item);
            items.Remove(item);
            var parent = item.parentTask;
            if(parent != null)
                parent.RemoveSubtask(item);

            RebuildTreeFromScratch();
            this.GoTo(parent);

            Program.SaveTasks();
        }
        //apparently RebuildTree() and RefreshObject do not work to get rid of a removed item,
        //so we'll rebuild tree for real ourselves
        void RebuildTreeFromScratch()
        {
            base.ClearObjects();
            AddObjects(items);
            ExpandAll();
        }


    }
}
