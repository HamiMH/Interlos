public class Card
{
    public enum Co
    {
        gula,
        zalud,
        zelen,
        srdce
    }
    public enum Ra
    {
        r7,
        r8,
        r9,
        r10,
        dolnik,
        hornik,
        kral,
        eso
    }

    public Co Col;
    public Ra Ran;
    public string Name;

    public Card(string str)
    {
        string[] strArr = str.Split(" ");
        switch (strArr[0].ToLower())
        {
            case "gula":
                Col = Co.gula;
                break;
            case "zalud":
                Col = Co.zalud;
                break;
            case "zelen":
                Col = Co.zelen;
                break;
            case "srdce":
                Col = (Co.srdce);
                break;
            default:
                throw new Exception("Case color");
        }

        switch (strArr[1].ToLower())
        {
            case "7":
                Ran = Ra.r7;
                break;
            case "8":
                Ran = Ra.r8;
                break;
            case "9":
                Ran = Ra.r9;
                break;
            case "10":
                Ran = Ra.r10;
                break;
            case "dolnik":
                Ran = Ra.dolnik;
                break;
            case "hornik":
                Ran = Ra.hornik;
                break;
            case "kral":
                Ran = Ra.kral;
                break;
            case "eso":
                Ran = Ra.eso;
                break;

            default:
                throw new Exception("Case rank");
        }
        Name = strArr[2].Replace("(", "").Replace(")", "").Trim();
    }

    public string Print()
    {
        return this.Ran + " " + this.Col;
    }
}