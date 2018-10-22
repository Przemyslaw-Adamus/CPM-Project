using CsvHelper.Configuration;
using CsvHelper;
using System;

namespace CPM
{
    internal class ActivityMapModeActivities : ClassMap<Activity>
    {
        public ActivityMapModeActivities()
        {
            Map(m => m.ID).Name("ID").Index(0);
            Map(m => m.Duration).Name("Time").Index(0);
            Map(m => m.IdPreviousIDs).Name("PreviousIDs").Index(0);
        }
    }
}