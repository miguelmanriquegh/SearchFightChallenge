using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFightChallenge.Results
{
    class ResultsReport
    {
        private Result[] results;

        public ResultsReport(ResultCalculator results)
        {
            this.results = results.GetResults();
        }

        public Result[] GetResults()
        {
            return results;
        }

        public void SetResults(Result[] value)
        {
            results = value;
        }

        internal void PrintWinnersToConsole()
        {
            for (int i = 0; i < this.results.Length - 1; i++)
            {
                Console.Write(this.results[i].EngineName + " winner: ");
                if (this.results[i].ResultNumber != -1)
                    Console.WriteLine(this.results[i].ArgumentName + "\n");
                else
                    Console.WriteLine("No winner\n");
            }

            Console.Write("Total winner: ");

            if (this.results[this.results.Length - 1].ResultNumber != -1)
                Console.WriteLine(this.results[this.results.Length - 1].ArgumentName + "\n");
            else
                Console.WriteLine("No winner\n");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
