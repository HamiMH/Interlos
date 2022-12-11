internal class Buchtator
{

    private int[,] _direc = {
        {1,0 },
        {-1,0 },
        {0,1 },
        { 0,-1},
    };

    public bool[,] Grid = new bool[4, 6];
    public bool[,] Used = new bool[4, 6];
    private int _iter = 0;

    public void AddLine(string str)
    {
        for (int i = 0; i < 6; i++)
        {
            if (str[i] == '0')
                Grid[_iter, i] = false;
            else
                Grid[_iter, i] = true;
        }
        _iter++;
    }

    public void Reset()
    {
        _iter = 0;
    }

    internal string Viable()
    {
        int i, j;

        for (i = 0; i < 4; i++)
            for (j = 0; j < 6; j++)
                Used[i,j] = false;

        Add(0, 0,0, 0);
            
        throw new NotImplementedException();
    }

    private bool Add(int x, int y, int t, int f)
    {

       if(t>3 ||)
    }
}