using CsvHelper.Configuration;
//using System.Globalization;
using CsvHelper;
using System;

namespace CPM
{
    internal class IncidentMap : ClassMap<Incident>
    {
        public IncidentMap()
        {
            Map(m => m.ID).ConvertUsing(row => Int32.Parse(row.GetField<String>(0)));
            Map(m => m.Duration).ConvertUsing(row => Double.Parse(row.GetField<String>(1)));
            Map(m => m.IdParent).ConvertUsing(row => Int32.Parse(row.GetField<String>(2)));
            Map(m => m.IdChildren).ConvertUsing(row => Int32.Parse(row.GetField<String>(3)));
        }

        private double ParseDateDouble(string v)
        {
            Double val = Double.Parse(v);
            return val;
        }
    }
}