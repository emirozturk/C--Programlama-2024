using System.ComponentModel;
using System.Numerics;

namespace Uygulama2;

class User(int id, string name, int age)
{
    public int Id{get; set; } = id;
    public string Name{get; set; } = name;
    public int Age{get; set; } = age;
}
class Genel<T>
{
    public T deger { get; set; }
}
struct yapi
{
       
}
class main
{
    static void DosyaOkumaFonksiyonu()
    {
        using (var fileStream = new FileStream("/Users/emirozturk/Desktop/sonuclarKisa.txt", FileMode.Open, FileAccess.Read))
        {
            var reader = new StreamReader(fileStream);
            var line = reader.ReadLine();
            Console.WriteLine(line);
        }
    }
    public static void Main(string[] args)
    {
        /*
        bool d1;
        int d2;
        double d3;
        byte d4;
        float d5;
        long d6;
        decimal d7;
        short d8;
        char d9;
        ushort d10;
        uint d11;
        ulong d12;
        BigInteger d13;
        DateTime d14;
        FileStream d16;
        StreamReader sr;
        StreamWriter sw;
        BinaryWriter bw;
        Thread t;
       
        double? d15;
        */
        
        /*
        var br = new BinaryReader(new MemoryStream(x));
        var sr = new StreamReader(br.BaseStream);
        var bi = new BigInteger();
        */

        
        int? degisken = null;
        Console.WriteLine(degisken!);
        User? user  = new User(1,"Emir",48);
        User? user2 = null;
        try
        {
            Console.WriteLine(user2.Name);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("Kullancı null");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        var liste = new List<string>();
        
        for(int i=0;i<10;i++)
            liste.Add(i.ToString());
        liste.Remove("3");
        liste.RemoveAt(3);
        liste.Add("7");
        liste.Add("1");
        liste.Add("1");
        var x = liste[5];
        
        foreach(var eleman in liste)
            Console.WriteLine(eleman);
        
        int[] dizi = new int[10];
        
        var sayilar = new Dictionary<string, int>();
        var sayac = 0;
        while (sayac < liste.Count)
        {
            var eleman = liste[sayac];
            if (sayilar.ContainsKey(eleman))
                sayilar[eleman] += 1;
            else
                sayilar.Add(eleman, 1);
            sayac++;
        }

        foreach (var (k,v) in sayilar)
        {
            Console.WriteLine($"{k} - {v}");
        }
        //HashSet<string> harfler = new HashSet<string>();
        //harfler.Contains()

        DosyaOkumaFonksiyonu();
        Genel<int> genel = new Genel<int>();
        Genel<string>genel2 = new Genel<string>();
        dynamic sonDegisken = 3;
        sonDegisken = "asd";
    }
}