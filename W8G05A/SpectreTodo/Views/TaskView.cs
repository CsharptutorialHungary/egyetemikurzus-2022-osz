using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BallerTODO.Views
{
    static internal class TaskView
    {
        public static async Task Draw()
        {
            var micsin = new TodoItem("subtask", "asd", new List<TodoItem> { new TodoItem("micsin", "asd"), new TodoItem("nenen") });
            TodoItem t = new TodoItem("Feladatka", "Ez egy taszk", new List<TodoItem> { micsin, new TodoItem("kettes") });

            List<TodoItem> tasks = new List<TodoItem> { t, new TodoItem("Modernc#") };


            t.Done = true;
            micsin.toggleDone();

            var tree = GetTaskTree(new List<TodoItem> { t }, micsin);

            var table = new Table().Centered();



            AnsiConsole.Write(tree);
        }

        public static Tree GetTaskTree(List<TodoItem> tasks, TodoItem? selected = null)
        {
            Style selected_style = Style.Parse("bold red");

            TreeNode taskToNode(TodoItem t) {
                var node = new TreeNode(t.GetMarkup(t == selected ? selected_style : null ));
                node.AddNodes(t.Subtasks.Select(sub => taskToNode(sub)));
                return node;
            }

            var root = new Tree("Tasks");
            root.AddNodes(tasks.Select(t => taskToNode(t)));
            return root;
        }
    }
}
