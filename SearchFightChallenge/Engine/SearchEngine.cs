using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFightChallenge.Engine
{
    interface ISearchEngine
    {
        string Name { get; set; }
        long TotalResults { get; set; }

        void GenerateRequest(string searchArgument);
    }
}
