using System.Text.Json;

namespace TicTacToe {
    class ScoreboardSerializer {
        private static string filepath = "scoreboard.json";
        public static async Task Serialize(params Player[] players) {
            try {
                using FileStream stream = File.Create(filepath);
                await JsonSerializer.SerializeAsync(stream, players);
                await stream.DisposeAsync();
            } catch (Exception e) {
                GameController.renderer.DrawError($"Couldn't write scoreboard! Error: {e}");
            }
        }

        public static async Task<List<Player>> Deserialize() {
            List<Player> result = new();
            try {
                using FileStream stream = File.OpenRead(filepath);
                result = (await JsonSerializer.DeserializeAsync<Player[]>(stream))?.ToList() ?? result;
                await stream.DisposeAsync();
            } catch (Exception e) {
                GameController.renderer.DrawError($"Couldn't read scoreboard! Error: {e}");
            }

            return result;
        }
    }
}
