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
        public int[] IdPrevious;

        public Activity()
        {

        }

        public Activity(int id, double duration, int idParent, int idChildren)
        {
            this.ID = id;
            this.Duration = duration;
            this.IdParent = idParent;
            this.IdChildren = idChildren;
        }

        public Activity(int id, double duration, int[] idPrevious)
        {
            this.ID = id;
            this.Duration = duration;
            this.IdPrevious = idPrevious;
        }

    }
}
