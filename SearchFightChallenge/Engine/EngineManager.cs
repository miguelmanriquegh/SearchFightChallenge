using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFightChallenge.Engine
{
    class EngineManager
    {
        private ArrayList engineList;

        public EngineManager()
        {
            GoogleEngine google = new GoogleEngine();
            BingEngine bing = new BingEngine();
            this.engineList = new ArrayList { google, bing };
        }

        public ArrayList GetEngineList()
        {
            return engineList;
        }

        public void SetEngineList(ArrayList value)
        {
            engineList = value;
        }
    }
}
