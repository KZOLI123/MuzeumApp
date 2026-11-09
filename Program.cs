using MuzeumApp;


List<Mutargy> gyujtemeny = new List<Mutargy>();
int hibas = 0;

foreach(string sor in File.ReadAllLines("Muzeum.txt").Skip(1))
{
    if(string.IsNullOrWhiteSpace(sor))
    {
        hibas++;
        continue;
    }
    string[] darabol = sor.Split('|');
    if(darabol.Count()<3)
    {
        hibas++;
        continue;
    }
    string tipus = darabol[0].Trim().ToUpper();
    if (tipus!="M" && tipus!="F")
    {
        hibas++;
        continue;
    }
    if (string.IsNullOrWhiteSpace(darabol[1]))
    {
        hibas++;
        continue;
    }
    if (int.TryParse(darabol[2], out int ertek))
    {
        hibas++;
        continue;
    }
    if (int.TryParse(darabol[3], out int extra))
    {
        hibas++;
        continue;
    }
    if (tipus == "M") gyujtemeny.Add(new Mutargy(darabol[1], ertek));
    else gyujtemeny.Add(new Festmeny(darabol[1], ertek, extra));
}
Console.WriteLine($"Sikeresen beolvasott műtárgyak: {gyujtemeny.Count} db");
Console.WriteLine($"Kiszűrt hibás sorok száma: {hibas} db");
Console.WriteLine("\nBeolvasot műtárgyak listája:");
foreach (Mutargy m in gyujtemeny)
{
    Console.WriteLine(m);
}
Console.WriteLine("\nLINQ Statisztikák:");
double atlag = gyujtemeny.Average(x => x.BecsultErtek);
Console.WriteLine($"Műtárgyak átlagos értéke: {atlag:F0} Ft");
Mutargy draga = gyujtemeny.MaxBy(x => x.BecsultErtek);
Console.WriteLine($"Legértékesebb műtárgy: {draga.Azonosito} ({draga.BecsultErtek} Ft)");
int dragadb = gyujtemeny.Count(x => x.BecsultErtek > 1000000);
Console.WriteLine($"Milliós értéket meghaladó műtárgyak: {dragadb} db");

foreach(Mutargy m in gyujtemeny)
{
    if(m is Festmeny fest) Console.WriteLine($" - {fest.Azonosito} festmény kora: {fest.KorEvekben} év");
}

IEnumerable<string> kiir = gyujtemeny.OrderByDescending(x => x.BecsultErtek).Select(x => $"{x.Azonosito};{x.BecsultErtek};{x.BiztositasDij}");

File.WriteAllLines("riport.txt", kiir);