using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace OQQA67
{
    internal static class PlayerLoaderSaver
    {
        private static JsonSerializerOptions Options()
        {
            return new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            };
        }

        public static List<Player>? LoadUsers()
        {
            List<Player>? players = new();

            try
            {
                string playersJsonDate = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "players.json"));
                players = JsonSerializer.Deserialize<List<Player>>(playersJsonDate, Options());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return players;
        }

        public static async Task<bool> SaveUsers(List<Player> players)
        {

            var serializedData = JsonSerializer.Serialize<List<Player>>(players, Options());

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
