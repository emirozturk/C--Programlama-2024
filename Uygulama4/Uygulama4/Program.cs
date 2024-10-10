class Athlete
{
    public int Age { get; set; }
    public int Height{ get; set; }
    public string Name{ get; set; }
    public int Weight{ get; set; }
    public string Profession{ get; set; }
    public bool Gender{ get; set; }
}
class main
{
    public static void Main(string[] args)
    {
        /*
        var numbers = new List<int>([1,2,3,41,12,57,39,42,15,35,22, 13,100,99,-99,11,110,7,111,98,6,6_000_000,34,4,404,0,9,7,-10,-161,-61,-3,-5,-7]);

        //How do you filter numbers greater than -10, check if all of them are negative, and count how many such numbers are there?
        var result = numbers.Count(x => x > -10
                                        && x < 0);
        
        Console.WriteLine($"Count: {result}");
        
        //How do you sort a list of numbers in descending order, filter out numbers greater than 20, and take the top 3?
        
        var result2 = numbers
            .Where(x=>x > 20)            
            .OrderByDescending(x => x)
            .Take(3);
        foreach(var number in result2)
            Console.WriteLine(number);
        */
        //How do you filter names that contain more than 4 characters, sort them alphabetically, and check if any name starts with the letter "A"?
        /*
        var nameList = new List<string>(["Emir","Anıl","Koçtaş","Ali","Bünyamin","Ebrar","Moustafa","Sena","İlker","Tarık","Furkan","Ecem","Aydın","Barış","Ferhat"]);

        var result = nameList
            .Where(x => x.Length >= 4 && (x.StartsWith("A") || x.StartsWith("a")))
            .OrderBy(x => x)
            .ToList();

        foreach (var eleman in result)
        {
            Console.WriteLine(eleman);
        }
        */
        var athletes = new List<Athlete>(
            [
                new Athlete{Name = "İlker",Age = 23,Gender=true,Height = 187,Weight = 90,Profession = "Basketball"},
                new Athlete{Name = "Bünyamin",Age = 21,Gender=true,Height = 173,Weight = 80,Profession = "Volleyball"},
                new Athlete{Name = "Emir",Age = 44,Gender=true,Height = 172,Weight = 73,Profession = "Tennis"},
            ]);
        var averageHeight = athletes
            .Where(x=>x.Age <30)
            .Select(x=>x.Height)
            .Average();
        Console.WriteLine(averageHeight);
        
        
    }
}