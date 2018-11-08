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

        public double OptimisticTime { get; set; }
        public double PessimisticTime { get; set; }
        public double ProbableTime { get; set; }
        public double Variance { get; set; }


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

        public Activity(int id, double OptimisticTime, double PessimisticTime, double ProbableTime, int idParent, int idChildren)
        {
            this.ID = id;
            this.OptimisticTime = OptimisticTime;
            this.PessimisticTime = PessimisticTime;
            this.ProbableTime = ProbableTime;
            this.IdChildren = idChildren;
            this.IdParent = idParent;
            this.Duration = CalculateDuration();
            this.Variance = CalculateVariance();

        }

        public double CalculateVariance()
        {
            Variance = (OptimisticTime + PessimisticTime) / 6;
            return Variance;
        }

        public double CalculateDuration()
        {
            Duration = (OptimisticTime + 4 * ProbableTime + PessimisticTime) / 6;
            return Duration;
        }
    }
}
