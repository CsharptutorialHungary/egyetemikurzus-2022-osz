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


        public TaskTree(List<TodoItem>? items = null)
        {
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

        public void DeleteItem(TodoItem item)
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
