using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using Terminal.Gui.Trees;

namespace TUITodo
{


    internal record class TodoItem : ITreeNode
    {
        private const string Unchecked = "O";
        private const string Checked = "X";

        public TodoItem? parentTask { get; protected set; }

        public bool Done { get; protected set; }
        [JsonInclude]
        public string name;
        [JsonInclude]
        public string description;

        public List<TodoItem> Subtasks { get; set; }
        public TodoItem(string name, string description = "") : this(name, description, new List<TodoItem>()) { }

        public TodoItem(string name, string description, List<TodoItem> subtasks)
        {
            this.Done = false;
            this.name = name;
            this.description = description;

            this.Subtasks = new();
            subtasks.ForEach(AddSubtask);

        }

        [JsonConstructor]
        public TodoItem()
        {
            Done = false; ;
            this.name = "";
            this.description = "";
            Subtasks = new List<TodoItem>();
        }

        [JsonIgnore]
        public string Text
        {
            get => $"{(Done ? Checked : Unchecked)} {name}"; set { name = value; }
        }

        [JsonIgnore]
        public IList<ITreeNode> Children => Subtasks.Cast<ITreeNode>().ToList();

        [JsonIgnore]
        public object Tag
        {
            get => name; set { name = (string)value; }
        }

        /// <param name="chainToSubtasks"> Make every subtask recursively inherit the done value</param>
        public void ToggleDone(bool chainToSubtasks = true)
        {
            SetDone(!Done, chainToSubtasks);
        }

        /// <param name="chainToSubtasks"> Make every subtask recursively inherit the done value</param>
        public void SetDone(bool value, bool chainToSubtasks = true)
        {
            Done = value;
            if (chainToSubtasks)
                Subtasks.ForEach(t => t.SetDone(value, chainToSubtasks));

            //complete parent task if all of its subtasks are done
            if (parentTask != null)
                parentTask.SetDone(parentTask.Subtasks.All(t => t.Done), chainToSubtasks:false);

        }

        public void AddSubtask(TodoItem task)
        {
            Subtasks.Add(task);
            task.parentTask = this;
        }

        public void RemoveSubtask(TodoItem task)
        {
            task.parentTask = null;
            Subtasks.Remove(task);
        }
    }
}
