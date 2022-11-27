using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FMEQVW_Roulette
{
    internal static class WriteXml
    {
        public static void Write(Player player,string name)
        {
            string filename = String.Format("{0}.xml", name);
            XmlSerializer xs = new XmlSerializer(typeof(Player));
            using (var stream = File.Create(Path.Combine(AppContext.BaseDirectory, filename)))
            {
                xs.Serialize(stream, player);
            }
        }
        public static void Read(Player player, string name)
        {
            string filename = String.Format("{0}.xml", name);
            XmlSerializer xs = new XmlSerializer(typeof(Player));
            using (var readStream = File.OpenRead(Path.Combine(AppContext.BaseDirectory, filename)))
            {
                if (xs.Deserialize(readStream) is Player readed)
                {
                    player.Name = readed.Name;
                    player.currency = readed.currency;
                }
            }
        }
    }
}
