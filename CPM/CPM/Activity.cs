using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM
{
    public class Activity
    {
        private static int _globalID;
        public int ID { get; }
        public double EarliestPossibleOccurrence { get; private set; }
        public double LatestPossibleOccurrence { get; private set; }
        public double Reserve { get; private set; }
        public IList<Incident> Incoming { get; private set; }
        public IList<Incident> Outgoing { get; private set; }
        

        Activity(List<Incident> incoming, List<Incident> outgoing)
        {
            _globalID++;
            this.ID = _globalID;
            Incoming = new List<Incident>(incoming);
            Outgoing = new List<Incident>(outgoing);
        }

        public bool IsLast()
        {
            return Incoming.Any();
        }

        public bool IsFirst()
        {
            return Outgoing.Any();
        }
        
        public void CalculateEarliestPossibleOccurence()
        {
            double max = 0;
            if (!IsFirst())
            {
                foreach(var incident in Incoming)
                {
                    var current = EarliestPossibleOccurrence + incident.Duration;
                    max = current > max ? current : max;
                }
            }

            EarliestPossibleOccurrence = max;
        }

        public void CalculateLatestPossibleOccurence()
        {
            double min = 0;
            if (!IsLast())
            {
                foreach (var incident in Outgoing)
                {
                    var current = LatestPossibleOccurrence - incident.Duration;
                    min = current < min ? current : min;
                }
                LatestPossibleOccurrence = min;
            }

            LatestPossibleOccurrence = EarliestPossibleOccurrence;
        }

        public void CalculateReserve()
        {
            Reserve = LatestPossibleOccurrence - EarliestPossibleOccurrence;
        }
    }
}
