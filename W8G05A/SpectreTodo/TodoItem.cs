using Spectre.Console;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallerTODO
{


    internal record class TodoItem
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
                Subtasks.ForEach(t => t.Done = value);
            }
        }
        string name;
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

        public Markup GetMarkup(Style? style = null) => Markup.FromInterpolated($"{(Done ? Checked : Unchecked)} {name}", style);

        internal List<TodoItem> Subtasks { get => subtasks; set => subtasks = value; }

        public void toggleDone()
        {
            Done = !Done;
        }
    }
}
