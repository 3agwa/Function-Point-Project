using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Metrics_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateFP obj = new CalculateFP();
            List<Tuple<string, string, int>> data = new List<Tuple<string, string, int>>();
            data.Add(Tuple.Create("External Input", "Average", 24));
            data.Add(Tuple.Create("External Output", "Average", 16));
            data.Add(Tuple.Create("External Inquiry", "Average", 22));
            data.Add(Tuple.Create("Internal Logical Files", "Average", 4));
            data.Add(Tuple.Create("External Interface Files", "Average", 2));

            Console.WriteLine(obj.CalculateUFP(data));
            
            List<string> GSC = new List<string>();
            List<string> arr = new List<string>();
            arr.Add("No Influence");
            arr.Add("Incidental");
            arr.Add("Moderate");
            arr.Add("Average");
            arr.Add("Significant");
            arr.Add("Essential");
            GSC.Add(arr[2]);
            GSC.Add(arr[0]);
            GSC.Add(arr[5]);
            GSC.Add(arr[5]);
            GSC.Add(arr[2]);
            GSC.Add(arr[4]);
            GSC.Add(arr[3]);
            GSC.Add(arr[5]);
            GSC.Add(arr[4]);
            GSC.Add(arr[5]);
            GSC.Add(arr[4]);
            GSC.Add(arr[3]);
            GSC.Add(arr[4]);
            GSC.Add(arr[5]);

            Console.WriteLine(obj.CalculateTCF(GSC) + " " + obj.DI);
            Console.WriteLine(obj.CalculateFPValue() + " " + obj.UFP + " " + obj.TCF);

        }
    }
}
