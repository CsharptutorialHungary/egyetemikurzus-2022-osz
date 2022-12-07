
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using KA2KWE_LNE7I2;

[Serializable()]
public class Program : ISerializable
{
    public static List<int> adatbekeres()
    {

        Console.WriteLine("adj meg 10 szamot");
        int[] szamtomb = new int[10];
        for (int i = 0; i < 10; i++)
        {
            int beolvasott;
            beolvasott = Convert.ToInt32(Console.ReadLine());
            szamtomb[i] = beolvasott;
        }
        List<int> szamoklistaja = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            szamoklistaja.Add(szamtomb[i]);
        }
        try
        {
            using (Stream fs = new FileStream(@"E:\\mukodj\szamok.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serilaizer = new XmlSerializer(typeof(List<int>));
                serilaizer.Serialize(fs, szamoklistaja);
            }
            szamoklistaja = null;
            XmlSerializer serializer1 = new XmlSerializer(typeof(List<int>));
            using (FileStream fs2 = File.OpenRead(@"E:\\mukodj\szamok.xml"))
            {
                szamoklistaja = (List<int>)serializer1.Deserialize(fs2);

            }
            Console.WriteLine("Az elmentet szamok:");
            foreach (int i in szamoklistaja)
            {
                Console.WriteLine(i);
            }
            return szamoklistaja;

        }
        catch (IOException e) { Console.WriteLine("IOexception kelettkezett"); return null; }
        catch (Exception e) { throw; return null; }
    }
    public static void minimumvagymaximum(List<int> szamoklistaja)
    {
        int valasz = 0;

        while (true)
        {

            Console.WriteLine("Irjon 1-et ha a szamok kozul a minimumot szeretne megnezni, 2-ot ha a szamok maximumat.");
            valasz = Convert.ToInt32(Console.ReadLine());
            if (valasz == 1)
            {
                int minimum = szamoklistaja.AsQueryable().Min();
                Console.WriteLine("A megadott szamok minimuma:\n");
                vegrehajt();
                Thread.Sleep(3200);
                Console.WriteLine(minimum);
                break;
            }
            else if (valasz == 2)
            {
                int max = szamoklistaja.AsQueryable().Max();
                Console.WriteLine("A megadott szamok maximuma:\n");
                vegrehajt();
                Thread.Sleep(3200);
                Console.WriteLine(max);
                break;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Error.WriteLine("Nem megfelelo valasz, kerlek 1 vagy 2 irj be.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new NotImplementedException();
    }
    public static async void vegrehajt()
    {
        Console.WriteLine("Szamolas!");
        await hosszuszamolas();
        
        Console.WriteLine("Szamolas befejezodott!");
    }
    private static async Task hosszuszamolas()
    {
        await Task.Run(() =>
        {

            Console.WriteLine("Szamol...");
            Thread.Sleep(3000);
        });

    }
    static void Main(string[] args)
    {

        List<int> szamoklistaja = new List<int>();
        szamoklistaja = adatbekeres();
        minimumvagymaximum(szamoklistaja);

    //-------------------- Kutya
        Console.WriteLine("\n \n Kutyas resz:");
        Kutya Zsebi=new Kutya(4,"Zsebi",true);
        Console.WriteLine("A kutya adatai:");
        Console.WriteLine("Kutya kora:{0},Kutya neve:{1},Kutya ehes-e?:{2}", Zsebi.Kor, Zsebi.Nev, Zsebi.Ehes);
        Console.WriteLine("Oregedik a kutya");
        Zsebi=Zsebi.Oregedes();
        Console.WriteLine("Kutya kora:{0},Kutya neve:{1},Kutya ehes-e?:{2}", Zsebi.Kor, Zsebi.Nev, Zsebi.Ehes);
        Console.WriteLine("Megetetjuk Zsebit");
        Zsebi=Zsebi.Etet();
        Console.WriteLine("Kutya kora:{0},Kutya neve:{1},Kutya ehes-e?:{2}", Zsebi.Kor, Zsebi.Nev, Zsebi.Ehes);
        int emberievekben=new int();
        emberievekben=Zsebi.Evszamkonvertalas();
        Console.WriteLine("Kutya eletkora kutya evekbe konvertalva:{0}", emberievekben);
        Console.WriteLine("Zsebi mindig tudna enni ezert megint megehezett");
        Zsebi=Zsebi.Megehez();
        Console.WriteLine("Kutya kora:{0},Kutya neve:{1},Kutya ehes-e?:{2}", Zsebi.Kor, Zsebi.Nev, Zsebi.Ehes);
        Console.Read();




    }




}