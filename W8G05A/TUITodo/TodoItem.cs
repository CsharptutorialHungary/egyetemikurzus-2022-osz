using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Terminal.Gui.Trees;

namespace TUITodo
{


    internal record class TodoItem : ITreeNode
    {
        private const string Unchecked = "O";
        private const string Checked = "X";

        bool _done;
        public bool Done
        {
            get { return _done; }
            set
            {
                _done = value;
                subtasks.ForEach(t => t.Done = value);
            }
        }
        public string name;
        string description;

        List<TodoItem> subtasks;

        public TodoItem(string name, string description = "") : this(name, description, new List<TodoItem>()) { }

        public TodoItem(string name, string description, List<TodoItem> subtasks)
        {
            this._done = false;
            this.name = name;
            this.description = description;

            this.subtasks = subtasks;

        }

        //public Markup GetMarkup(Style? style = null) => Markup.FromInterpolated($"{(Done ? Checked : Unchecked)} {name}", style);

        //internal List<TodoItem> Subtasks { get => subtasks; set => subtasks = value; }
        public string Text
        {
            get => $"{(Done ? Checked : Unchecked)} {name}"; set { name = value; }
        }

        public IList<ITreeNode> Children => subtasks.Cast<ITreeNode>().ToList();

        public object Tag
        {
            get => description; set { description = (string)value; }
        }

        public void ToggleDone()
        {
            Done = !Done;
        }
    }
}
