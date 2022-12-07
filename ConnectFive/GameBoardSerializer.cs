using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ConnectFive
{
    public static class GameBoardJsonSerializer
    {
        static readonly string fileName = "board.json";
        public static async Task Serialize(GameBoard gameBoard)
        {
            string json = JsonConvert.SerializeObject(gameBoard);
            await File.WriteAllTextAsync(fileName, json);
        }

        public static async Task<GameBoard?> Deserialize()
        {
            string json = await File.ReadAllTextAsync(fileName);
            return JsonConvert.DeserializeObject<GameBoard>(json);
        }
        public static bool CanDeserialize()
        {
            return File.Exists(fileName);
        }
    }
}
