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

        public TaskListView(List<TodoItem> items)
        {
            Items = items;
            KeyDown += e =>
            {
                Key k = e.KeyEvent.Key;

                if (k == Key.Space && SelectedObject is TodoItem t)
                {        
                    Application.MainLoop.Invoke(() =>
                    {
                        t.ToggleDone();

                        // Tell view to redraw
                        SetNeedsDisplay();
                    });
                }
                if (k == (Key)'+')
                {
                    Application.MainLoop.Invoke(() =>
                    {
                        AddItem(new TodoItem("HAO"));

                        SetNeedsDisplay();
                    });
                }

            };

            
        }

        public void AddItem(TodoItem item)
        {
            Items.Add(item);
            AddObject(item);
        }

        
    }
}
