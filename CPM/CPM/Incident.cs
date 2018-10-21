using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM
{
    public class Incident
    {
        public int ID;
        public double Duration { get; set; }
        public int IdParent;
        public int IdChildren;
        public Activity Parent { get; set; }
        public Activity Children { get; set; }

    }
}
