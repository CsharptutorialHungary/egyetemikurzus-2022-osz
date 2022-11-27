using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace TUITodo.Views
{
    internal class EditorView : FrameView
    {

        TodoItem? editedItem;

        public void StartEditing(TodoItem item)
        {
            editedItem = item;
            titleTextField.Text = item.Text;
            descriptionTextView.Text = item.description;
        }

        TextField titleTextField = new()
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = 2
        };
        TextView descriptionTextView = new()
        {
            X = 0,
            Y = 3,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1,
        };

        StatusBar statusBar = new StatusBar(new StatusItem[]
        {
            new StatusItem(Key.Esc, "Exit", () => {
                Trace.WriteLine("Exit");
                Program.SwitchToView(Program.TaskListView); 
            })
        })
        {

        };
        public EditorView()
        {
            statusBar.Y = Pos.Bottom(descriptionTextView);
            Add(titleTextField, descriptionTextView, statusBar);
        }
    }
}
