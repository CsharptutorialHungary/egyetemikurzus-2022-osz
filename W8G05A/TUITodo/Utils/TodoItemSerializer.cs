using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace TUITodo.Utils
{
    internal static class TodoItemSerializer
    {
        static  JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };

        public static async Task Serialize(IList<TodoItem> items, string path = "todos.json")
        {
            string json = JsonSerializer.Serialize(items, options);
            //Trace.WriteLine(json);
            using (StreamWriter writer = File.CreateText(path))
            {
                await writer.WriteAsync(json);
                Program.DisplayStatusNotification($"Saved");
            }
        }

        public async static Task<List<TodoItem>?> Deserialize(string path = "todos.json")
        {
            if (!File.Exists(path)) return null;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string json =  await sr.ReadToEndAsync();
                
                    return JsonSerializer.Deserialize<List<TodoItem>>(json, options);
                
                }
            }
            catch (Exception e)
            {
                Program.DisplayStatusNotification($"Could not deserialize: {e}");
                return null;
            }

        }

    }
}
