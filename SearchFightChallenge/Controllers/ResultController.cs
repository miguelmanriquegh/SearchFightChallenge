using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchFightChallenge.Engine;
using SearchFightChallenge.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFightChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public string Get(int id)
        {
            return "value";
        }

        public Result[] Post([FromBody] string[] searchArguments)
        {
            EngineManager engines = new EngineManager();
            ResultCalculator results = new ResultCalculator(engines, searchArguments);
            ResultsReport output = new ResultsReport(results);
            return output.GetResults();
        }
    }
}
