using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CPM
{
    public class Graph
    {
        public IList<Incident> Incidents { get; private set; }
        public IList<Activity> Activities { get; private set; }

        public Graph()
        {
            Incidents = new List<Incident>();
            Activities = new List<Activity>();
        }

        public void CreateGraphIncidients()
        {
            LoadActivities();
            CreateIncidents();
        }

        public void CreateGraphActivities()
        {
            LoadActivitiesModeActivities();
            CreateIncidentsModeActivities();
        }

        public void ShowGraph()
        {
            Console.WriteLine("ACTIVITIES");
            foreach (var act in Activities)
            {
                Console.WriteLine("_______________________");
                Console.WriteLine("ID \t \t" + act.ID);
                Console.WriteLine("Duration \t" + act.Duration);
                Console.WriteLine("ID Parent \t" + act.Parent.ID);
                Console.WriteLine("ID Child \t" + act.Children.ID);
                Console.WriteLine("_______________________");
            }

            Console.WriteLine("\n INCIDENTS");
            foreach (var inc in Incidents)
            {
                Console.WriteLine("_______________________");
                Console.WriteLine("ID \t \t" + inc.ID);
                Console.WriteLine("EPO \t \t" + inc.EarliestPossibleOccurrence);
                Console.WriteLine("LPO \t \t" + inc.LatestPossibleOccurrence);
                Console.WriteLine("Reserve \t" + inc.Reserve);
                Console.WriteLine("Count Incoming \t" + inc.Incoming.Count);
                Console.WriteLine("Count Outgoing \t" + inc.Outgoing.Count);
                Console.WriteLine("_______________________");
            }
        }

        private void LoadActivities()
        {
            using (var streamReader = File.OpenText("Graf1.1.csv"))
            {
                var reader = new CsvReader(streamReader);
                reader.Configuration.RegisterClassMap<ActivityMap>();
                reader.Configuration.HeaderValidated = null;
                Activities = reader.GetRecords<Activity>().ToList();
            }

        }

        public void CreateIncidents()
        {
            //---------------------------------------------
            Incident item;
            HashSet<Incident> uniqueIncidents = new HashSet<Incident>();
            foreach (var act in Activities)
            {
                item = new Incident(act.IdParent);
                uniqueIncidents.Add(item);
                item = new Incident(act.IdChildren);
                uniqueIncidents.Add(item);
            }
            foreach (var inc in uniqueIncidents)
            {
                Incidents.Add(inc);
            }
            Incidents = Incidents.OrderBy(o => o.ID).ToList();
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            int id = 0;
            List<Incident> removeIncidents = new List<Incident>();
            foreach (var inc in Incidents)
            {
                if(id == inc.ID)
                {
                    removeIncidents.Add(inc);
                }
                else
                {
                    id = inc.ID;
                }
            }
            foreach(var remove in removeIncidents)
            {
                Incidents.Remove(remove);
            }
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //---------------------------------------------
            foreach (var act in Activities)
            {
                foreach (var inc in Incidents)
                {
                    if (act.IdParent == inc.ID)
                    {
                        act.Parent = inc;
                        inc.Outgoing.Add(act);
                    }
                    if (act.IdChildren == inc.ID)
                    {
                        act.Children = inc;
                        inc.Incoming.Add(act);
                    }
                }
            }
            //---------------------------------------------
        }

        private void LoadActivitiesModeActivities()
        {
            using (var streamReader = File.OpenText("Graf1.2.csv"))
            {
                var reader = new CsvReader(streamReader);
                reader.Configuration.RegisterClassMap<ActivityMapModeActivities>();
                reader.Configuration.HeaderValidated = null;
                reader.Configuration.Delimiter = ";";
                Activities = reader.GetRecords<Activity>().ToList();
            }

        }

        public void CreateIncidentsModeActivities()
        {
            foreach(var incident in Incidents)
            {
                foreach(var activity in Activities)
                {
                    if (activity.IdPrevious == null)
                        activity.Children = Incidents.Single(i => i.ID == 0);
                    else
                    {
                        foreach(var id in activity.IdPrevious)
                        {
                            var actual = Activities.Single(a => a.ID == id);
                            activity.Parent.Incoming.Add(actual);
                            actual.Children = actual.Parent;
                        }
                    }
                }
            }
        }

        public void NewActivity(Activity activity)
        {
            Activities.Add(activity);
            if (activity.IdPrevious.Length == 0 || !Activities.Contains(activity))
            {
                var incident = new Incident();
                Incidents.Add(incident);
                incident.Outgoing.Add(activity);
                activity.Parent = incident;
            }
        }

    }
}
