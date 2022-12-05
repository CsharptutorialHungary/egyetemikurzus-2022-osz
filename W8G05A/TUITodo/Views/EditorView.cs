using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using TUITodo.Utils;

namespace TUITodo.Views
{
    internal class EditorView : FrameView
    {

        TodoItem? editedItem;

        public void StartEditing(TodoItem item)
        {
            editedItem = item;
            titleTextField.Text = item.name;
            descriptionTextView.Text = item.description;
            titleTextField.SelectAll();
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

        public StatusBar statusBar { get; } = new();

        void Save()
        {
            if (editedItem == null) return;

            editedItem.name = (string)titleTextField.Text;
            editedItem.description = (string)descriptionTextView.Text;

            Program.SaveTasks();
        }

        //Check for actual changes. TextField and TextView have an isDirty field,
        //but it seems they are set to true even when we only just entered them and haven't made any edits
        bool isDirty()
        {
            return editedItem?.name != titleTextField.Text ||
                editedItem?.description != descriptionTextView.Text;
        }

        void Exit()
        {
            if (isDirty())
            {
                int buttonIndex = MessageBox.Query(
                    "Unsaved changes", "Would you like to save?", 
                    "Save and exit", "Discard changes", "Stay editing");

                if (buttonIndex == 0) Save();
                if (buttonIndex == -1 || buttonIndex == 2) return;
            }

            Program.ShowTaskListView();
        }

        void SaveAndExit()
        {
            Save();
            Exit();
        }

        public EditorView()
        {
            statusBar.Items = new StatusItem[]
            {
                new StatusItem(Key.Esc, "~Esc Exit", Exit),
            };
            Add(titleTextField, descriptionTextView);
            statusBar.Y = Pos.Bottom(descriptionTextView);

            titleTextField.KeyDown += e =>
            {
                Key k = e.KeyEvent.Key;

                if (k == Key.Enter)
                {
                    Application.MainLoop.Invoke(() =>
                    {
                        Program.EditorView.FocusNext();
                    });
                }
            };
        }
    }
}
