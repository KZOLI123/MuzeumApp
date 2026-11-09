using MuzeumApp;


List<Mutargy> gyujtemeny = new List<Mutargy>();
int hibas = 0;

foreach(string sor in File.ReadAllLines("mutargyak.txt").Skip(1))
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
    if (tipus == "M")
        gyujtemeny.Add(new Mutargy(darabol[1], ertek));
    else gyujtemeny.Add(new Festmeny(darabol[1], ertek, extra));
}