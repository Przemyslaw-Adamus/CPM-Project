﻿using System;
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
                  //  max = current > max ? current : max;
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
                   // var current = LatestPossibleOccurrence - incident.Duration;
                    //min = current < min ? current : min;
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
