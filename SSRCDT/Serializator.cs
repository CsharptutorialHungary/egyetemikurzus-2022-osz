using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SSRCDT
{
    public class Serializator
    {
        public void serializeKitchen()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Kitchen));

                var writer = new StreamWriter(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/XMLs/kitchen.xml");

                Kitchen kitchen = new Kitchen();

                // Serializes the object.  
                serializer.Serialize(writer, kitchen);
                writer.Close();
                Console.WriteLine("Konyha szerializálva!");
            }
            catch (UnauthorizedAccessException) { Console.WriteLine("Jogosultsági hiba! Próbáld meg adminisztrátorként futtantni."); }
            catch (IOException) { Console.WriteLine("Fájlkezelési hiba! Ellenőrizd a mentési hely helyességét."); }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

        }

        public void serializeMeatHolder(MeatHolder meatHolder)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MeatHolder));

                var writer = new StreamWriter(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/XMLs/meatholder.xml");

                MeatHolder newMeatHolder = new MeatHolder() {
                    Container = meatHolder.Container
                };

        /*        foreach(var meat in meatHolder.Container)
                {
                    switch(meat.GetType().Name)
                    {
                        case "StripsMeat":
                            {
                                newMeatHolder.AddToContainer(new StripsMeat() { amount = meat.amount });
                                break;
                            }
                    }
                } */

                // Serializes the object.  
                serializer.Serialize(writer, newMeatHolder);
                writer.Close();
                Console.WriteLine("Hústároló szerializálva!");
            }
            catch (UnauthorizedAccessException) { Console.WriteLine("Jogosultsági hiba! Próbáld meg adminisztrátorként futtantni."); }
            catch (IOException) { Console.WriteLine("Fájlkezelési hiba! Ellenőrizd a mentési hely helyességét."); }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

        }

    }
}
