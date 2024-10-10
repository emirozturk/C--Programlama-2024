class Number
{
    public int Value { get; set; }

    public Number(int n) => Value = n;

    public void degerArttir()
    {
        Value++;
    }
}

public class Deneme
{
    public static void Metot()
    {
        var yeniSayi = new Number(0);
        for (var i = 0; i < 500_000_000; i++)
        {
            yeniSayi.Value=i+1;
            if (yeniSayi.Value > 500_000_000 - 2)
                Console.WriteLine(yeniSayi.Value);
        }
    }
}

class main
{
    public static void Main(string[] args)
    {
        Deneme.Metot();
    }
}