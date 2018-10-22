using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM
{
    public class Incident
    {
        public int ID { get; private set; }
        public double EarliestPossibleOccurrence { get; private set; }
        public double LatestPossibleOccurrence { get; private set; }
        public double Reserve { get; private set; }
        public IList<Activity> Incoming { get; private set; }
        public IList<Activity> Outgoing { get; private set; }
        

        public Incident(int id)
        {
            ID = id;
            EarliestPossibleOccurrence = 0.0;
            LatestPossibleOccurrence = 0.0;
            Reserve = 0.0;
            Incoming = new List<Activity>();
            Outgoing = new List<Activity>();
        }

        public bool IsNotLast()
        {
            return Outgoing.Any();
        }

        public bool IsNotFirst()
        {
            return Incoming.Any();
        }
        
        public void CalculateEarliestPossibleOccurence()
        {
            double max = 0;
            if (IsNotFirst())
            {
                foreach(var activity in Incoming)
                {
                    var current = activity.Parent.EarliestPossibleOccurrence + activity.Duration;
                    max = current > max ? current : max;
                }
            }

            EarliestPossibleOccurrence = max;
        }

        public void CalculateLatestPossibleOccurence()
        {
            LatestPossibleOccurrence = EarliestPossibleOccurrence;
            if (IsNotLast())
            {
                double min = Outgoing.Min(i => i.Children.LatestPossibleOccurrence);
                foreach (var activity in Outgoing)
                {
                    var current = activity.Children.LatestPossibleOccurrence - activity.Duration;
                    min = current < min ? current : min;
                }
                LatestPossibleOccurrence = min;
            }
        }

        public void CalculateReserve()
        {
            Reserve = LatestPossibleOccurrence - EarliestPossibleOccurrence;
        }
    }
}
