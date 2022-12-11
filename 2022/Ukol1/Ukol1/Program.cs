using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        List<string> inputCol = new List<string>();
        string lineIn1;
        //while ((lineIn1 = Console.ReadLine()) != null)
        string resultStr = "";

        Buchtator bu = new Buchtator();
        while ((lineIn1 = Console.ReadLine()) != "eof")
        {
            if (lineIn1 == "")
            {
                resultStr += bu.Viable();
                bu.Reset();
                continue;
            }
            bu.AddLine(lineIn1);
        }
        Stopwatch sw = new Stopwatch();
        sw.Start();
        //long result = GetResult1(inputCol);
        //long result = GetResult2(inputCol);
        sw.Stop();

        Console.WriteLine(resultStr);
        Console.WriteLine("Time was: " + sw.ElapsedMilliseconds + " ms.");
    }

    private static long GetResult1(List<string> inputCol)
    {

        return 0;
    }


    private static long GetResult2(List<string> inputCol)
    {
        return 0;
    }


}