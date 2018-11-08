using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM
{
    public class Solver
    {
        public Graph Graph { get; private set; }

        const double EPSILON = 0.000001;

        public Solver()
        {
            Graph = new Graph();
        }

        public void LoadGraph(Graph graph)
        {
            Graph = graph;
        }

        public void CalculateGraphValues()
        {
            foreach(var incident in Graph.Incidents)
            {
                incident.CalculateEarliestPossibleOccurence();
            }
            foreach(var incident in Graph.Incidents.Reverse())
            {
                incident.CalculateLatestPossibleOccurence();
            }
            foreach(var incident in Graph.Incidents.Reverse())
            {
                incident.CalculateReserve();
            }
        }

        public IList<Incident> FindIncidentsCriticalPath()
        {
            bool nextIncidentIsAvaliable = true;
            var criticalPath = new List<Incident>
            {
                Graph.Incidents.ToList().First()
            };
            while (nextIncidentIsAvaliable)
            {
                var outgoings = criticalPath.Last().Outgoing;
                var incidentsWithoutReserve = outgoings.Select(a => a.Children).Where(i => Math.Abs(i.Reserve) < EPSILON);
                Incident nextIncident = incidentsWithoutReserve.First();
                foreach(var incident in incidentsWithoutReserve)
                {
                    if (incident.EarliestPossibleOccurrence < nextIncident.EarliestPossibleOccurrence)
                        nextIncident = incident;
                }
                criticalPath.Add(nextIncident);
                nextIncidentIsAvaliable = criticalPath.Last().Outgoing.Any();
            }
            return criticalPath;
        }

        public void ShowCriticalPath(IList<Incident> criticalPath)
        {
            var sb = new StringBuilder();
            foreach (var incident in criticalPath)
            {
                if (incident.IsNotLast())
                    sb.Append($"{incident.ID} - ");
                else
                    sb.Append($"{incident.ID}");
            }
            Console.WriteLine(sb);
        }
        public void CalculatePERT()
        {

        }

    }
}
