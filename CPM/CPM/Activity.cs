using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM
{
    public class Activity
    {
        public int ID;
        public double Duration { get; set; }
        public Incident Parent { get; set; }
        public Incident Children { get; set; }

        public int IdParent;
        public int IdChildren;
        public int IdPreviousIDs;

        public Activity()
        {

        }

    }
}
