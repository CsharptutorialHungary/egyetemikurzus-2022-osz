using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace OQQA67
{
    internal static class PlayerLoaderSaver
    {
        public static List<Player>? LoadUsers()
        {
            List<Player>? players = new();

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            };

            try
            {
                string playersJsonDate = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "players.json"));
                players = JsonSerializer.Deserialize<List<Player>>(playersJsonDate, options);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            return players;
        }

        public static bool SaveUsers(List<Player> players)
        {
            
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            };

            var serializedData = JsonSerializer.Serialize<List<Player>>(players, options);

            try
            {
                File.WriteAllText(Path.Combine(AppContext.BaseDirectory, "players.json"), serializedData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

    }
}
