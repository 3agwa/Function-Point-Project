using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Metrics_Project
{
    class CalculateFP
    {
        public int UFP;
        public int DI;
        public double TCF;
        public double FP;
        public double LOC;

        public Dictionary<Tuple<string, string>, int> complexityTable;
        public Dictionary<string, int> TCF_Value;
        public Dictionary<string, int> languageComplexity;

        void InitializeComplexityTable()
        {
            Tuple<string, string> param = new Tuple<string, string>("External Input", "Simple");
            complexityTable[param] = 3;
            param = new Tuple<string, string>(param.Item1, "Average");
            complexityTable[param] = 4;
            param = new Tuple<string, string>(param.Item1, "Complex");
            complexityTable[param] = 6;
            
            param = new Tuple<string, string>("External Output", "Simple");
            complexityTable[param] = 4;
            param = new Tuple<string, string>(param.Item1, "Average");
            complexityTable[param] = 5;
            param = new Tuple<string, string>(param.Item1, "Complex");
            complexityTable[param] = 7;

            param = new Tuple<string, string>("External Inquiry", "Simple");
            complexityTable[param] = 3;
            param = new Tuple<string, string>(param.Item1, "Average");
            complexityTable[param] = 4;
            param = new Tuple<string, string>(param.Item1, "Complex");
            complexityTable[param] = 6;

            param = new Tuple<string, string>("Internal Logical Files", "Simple");
            complexityTable[param] = 7;
            param = new Tuple<string, string>(param.Item1, "Average");
            complexityTable[param] = 10;
            param = new Tuple<string, string>(param.Item1, "Complex");
            complexityTable[param] = 15;

            param = new Tuple<string, string>("External Interface Files", "Simple");
            complexityTable[param] = 5;
            param = new Tuple<string, string>(param.Item1, "Average");
            complexityTable[param] = 7;
            param = new Tuple<string, string>(param.Item1, "Complex");
            complexityTable[param] = 10;
        }


        void InitializeTCF()
        {
            TCF_Value["No Influence"] = 0;
            TCF_Value["Incidental"] = 1;
            TCF_Value["Moderate"] = 2;
            TCF_Value["Average"] = 3;
            TCF_Value["Significant"] = 4;
            TCF_Value["Essential"] = 5;
        }

        void InitializeComplexity()
        {
            languageComplexity["Assembly Language"] = 320;
            languageComplexity["C"] = 128;
            languageComplexity["COBOL/Fortan"] = 105;
            languageComplexity["Pascal"] = 90;
            languageComplexity["Ada"] = 70;
            languageComplexity["C++"] = 64;
            languageComplexity["Visual Basic"] = 32;
            languageComplexity["Object-Oriented Languages"] = 30;
            languageComplexity["Smalltalk"] = 22;
            languageComplexity["Code Generators (PowerBuilder)"] = 15;
            languageComplexity["SQL/Oracle"] = 12;
            languageComplexity["Spreadsheets"] = 6;
            languageComplexity["Graphical Languages (icons)"] = 4;
        }

        public CalculateFP()
        {
            complexityTable = new Dictionary<Tuple<string, string>, int>();
            InitializeComplexityTable();
            TCF_Value = new Dictionary<string, int>();
            InitializeTCF();
            languageComplexity = new Dictionary<string, int>();
            InitializeComplexity();
        }
        
        public int CalculateUFP(List<Tuple<string, string, int>> data)
        {
            UFP = 0;
            foreach(Tuple<string, string, int> element in data)
            {
                Tuple<string, string> key = new Tuple<string, string>(element.Item1, element.Item2);
                int weight = complexityTable[key];
                UFP += weight * element.Item3;
            }

            return UFP;
        }

        public double CalculateTCF(List<string> data)
        {
            DI = 0;

            foreach(string element in data)
            {
                DI += TCF_Value[element];
            }

            TCF = 0.65 + 0.01 * DI;

            return TCF;
        }

        public double CalculateFPValue()
        {
            FP = UFP * TCF;
            return FP;
        }

        public double CalculateLOC(string language)
        {
            LOC = FP * languageComplexity[language];
            return LOC;
        }
    }
}
