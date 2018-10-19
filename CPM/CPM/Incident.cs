using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM
{
    public class Incident
    {
        public double Duration { get; set; }
        public Activity Parent { get; set; }
        public Activity Children { get; set; }

    }
}
