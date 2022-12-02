using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Controllers
{
    internal static class WeatherIO
    {
        private static string path = Path.Combine(AppContext.BaseDirectory, "weather_data.json");

        public static async Task<bool> WriteOut(string message)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    await sw.WriteLineAsync(message);
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
                return false;
            }
            return true;
        }

        public static async Task<string> ReadIn()
        {
            string data = string.Empty;
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    data = await sr.ReadToEndAsync();
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine($"Couldn't find file at: {path}. TRY RUNNING 'refresh'!");
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            return data;
        }
    }
}
