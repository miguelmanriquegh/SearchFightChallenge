using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFightChallenge.Results
{
    public class Result
    {
        private string engineName;
        private long resultNumber;
        private string argumentName;

        public Result(int v = -1)
        {
            this.resultNumber = v;
        }

        public string EngineName { get; set; }
        public long ResultNumber { get; set; }
        public string ArgumentName { get; set; }
    }
}
}
