using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CPM
{
    public class Graph
    {
        public IList<Activity> Activities { get; private set; }
        public IList<Incident> Incidents { get; private set; }

        public Graph()
        {
            Incidents = new List<Incident>();
            Activities = new List<Activity>();
        }

        public void CreateGaph()
        {
            LoadIncidents();
            CreateActicity();
        }

        private void LoadIncidents()
        {
            using (var streamReader = File.OpenText("Graf1.1.csv"))
            {
                var reader = new CsvReader(streamReader);
                reader.Configuration.RegisterClassMap<IncidentMap>();
                reader.Configuration.HeaderValidated = null;
                Incidents = reader.GetRecords<Incident>().ToList();
                
                foreach(var incident in Incidents)
                {
                    Console.WriteLine(incident.ID.ToString() + " , " + incident.Duration.ToString() + " , " + incident.IdChildren.ToString() + " , " + incident.IdParent.ToString() + " , ");
                }
            }

        }

        private void CreateActicity()
        {
            foreach (var incident in Incidents)
            {
                Activities.Add(new Activity(id,))
            }
    }
}
