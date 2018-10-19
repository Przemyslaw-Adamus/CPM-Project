using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM
{
    class Graph
    {
        public IList<Activity> Activities { get; private set; }
        public IList<Incident> Incidents { get; private set; }

        Graph()
        {
            Incidents = new List<Incident>();
            Activities = new List<Activity>();
        }

        public void LoadGaph()
        {

        }

    }
}
