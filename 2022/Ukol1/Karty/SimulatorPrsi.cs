using System.Text;

internal class SimulatorPrsi
{

    public List<Card> lizaci = new List<Card>();
    //public List<Card> odhazovaci = new List<Card>();
    public List<List<Card>> hraci = new List<List<Card>>();

    private int spec7 = 1;
    private int specEso = 0;

    internal void AddCard(string str)
    {
        lizaci.Add(new Card(str));
    }

    public string Simulate()
    {
        int r7 = 0;
        int r8 = 0;
        int r9 = 0;
        int r10 = 0;
        int dolnik = 0;
        int hornik = 0;
        int kral = 0;
        int eso = 0;
        foreach(Card c in lizaci)
        {
            switch (c.Ran)
            {
                case Card.Ra.r7:
                    r7++;
                    break;
                case Card.Ra.r8:
                    r8++;
                    break;
                case Card.Ra.r9:
                    r9++;
                    break;
                case Card.Ra.r10:
                    r10++;
                    break;
                case Card.Ra.dolnik:
                    dolnik++;
                    break;
                case Card.Ra.hornik:
                    hornik++;
                    break;
                case Card.Ra.kral:
                    kral++;
                    break;
                case Card.Ra.eso:
                    eso++;
                    break;


            }
        }

        hraci.Add(new List<Card>());
        hraci.Add(new List<Card>());
        hraci.Add(new List<Card>());
        hraci.Add(new List<Card>());
        hraci.Add(new List<Card>());

        Rozdej();
        //lizaci.Add(lizaci[0]);
        //lizaci.RemoveAt(0);
        int i, j;
        StringBuilder stTmp = new StringBuilder();
        for (int _iter = 0; ; _iter++)
        {
            stTmp.Clear();
            for (i = 0; i < 5; i++)
            {
                stTmp.AppendLine();
                stTmp.Append((i + 1) + " - ");
                foreach(Card card in hraci[i])
                {
                    stTmp.Append(card.Print()+",   "); 
                }
            }
            stTmp.AppendLine();
            stTmp.Append( "B - ");
            foreach (Card card in lizaci)
            {
                stTmp.Append(card.Print() + ",   ");
            }
            Console.WriteLine(stTmp.ToString());
            if (Hraj(_iter, _iter % 5))
                break;
        }

        StringBuilder stb = new StringBuilder();
        foreach (Card card in lizaci)
        {
            stb.Append(card.Name);
        }
        return stb.ToString();
    }

    private bool Hraj(int kolo, int hracInd)
    {
        Card horni = lizaci.Last();

        Console.WriteLine("Horni Karta: "+horni.Ran + " " + horni.Col);
        bool hrano;
        if ((horni.Ran == Card.Ra.r7) && spec7 > 0)
        {
            hrano = Hledej7(hracInd, horni);
        }
        else if (horni.Ran == Card.Ra.eso && specEso > 0)
        {
            hrano = HledejEso(hracInd, horni);
        }
        else
        {
            hrano = HledeKartu(hracInd, horni);
        }
        if (hrano)
        {
            horni = lizaci.Last();
            if (horni.Ran == Card.Ra.r7)
            {
                specEso = 0;
                spec7++;
            }
            else if (horni.Ran == Card.Ra.eso)
            {

                spec7 = 0;
                specEso++;
            }
            else
            {
                spec7 = 0;
                specEso = 0;
            }
            Console.WriteLine((hracInd + 1) + " " + lizaci.Last().Ran + " " + lizaci.Last().Col);
        }
        else
        {
            spec7 = 0;
            specEso = 0;
            Console.WriteLine((hracInd + 1) + "--");
        }


        if (hraci[hracInd].Count() == 0)
            return true;
        return false;
    }

    private bool Hledej7(int hracInd, Card horni)
    {
        Card iter;
        List<Card> hrac = hraci[hracInd];
        int hracLen = hrac.Count;
        for (int i = 0; i < hracLen; i++)
        {
            iter = hrac[i];
            if (iter.Ran == horni.Ran)
            {
                lizaci.Add(iter);
                hrac.RemoveAt(i);
                return true;
            }
        }
        for (int i = 0; i < spec7; i++)
        {

            hrac.Add(lizaci[0]);
            lizaci.RemoveAt(0);
            hrac.Add(lizaci[0]);
            lizaci.RemoveAt(0);
        }
        return false;
    }

    private bool HledejEso(int hracInd, Card horni)
    {
        Card iter;
        List<Card> hrac = hraci[hracInd];
        int hracLen = hrac.Count;
        for (int i = 0; i < hracLen; i++)
        {
            iter = hrac[i];
            if (iter.Ran == horni.Ran)
            {
                lizaci.Add(iter);
                hrac.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    private bool HledeKartu(int hracInd, Card horni)
    {
        Card iter;
        List<Card> hrac = hraci[hracInd];
        int hracLen = hrac.Count;
        for (int i = 0; i < hracLen; i++)
        {
            iter = hrac[i];
            if (iter.Col == horni.Col || iter.Ran == horni.Ran)
            {
                lizaci.Add(iter);
                hrac.RemoveAt(i);
                return true;
            }
        }
        hrac.Add(lizaci[0]);
        lizaci.RemoveAt(0);
        return false;

    }

    private void Rozdej()
    {
        int i, j;

        for (i = 0; i < 5; i++)
            for (j = 0; j < 5; j++)
            {
                hraci[i].Add(lizaci[0]);
                lizaci.RemoveAt(0);
            }
    }
}