using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            graph.CreateGaphIncidients();
            graph.ShowGraph();

            graph = new Graph();
        
            graph.CreateGaphActivities();
            //graph.ShowGraph();

            //int choose;
            //Console.WriteLine("1. \t MODE 1");
            //Console.WriteLine("2. \t MODE 2");
            //Console.WriteLine("0. \t EXIT");
            //Console.Write("CHOOSE THE MODE: ");
            //choose = Console.Read();
            //switch (choose)
            //{
            //    case 1:
            //        graph.CreateGaphIncidients();
            //        graph.ShowGraph();
            //        break;
            //    case 2:
            //        graph.CreateGaphActivities();
            //        graph.ShowGraph();
            //        break;
            //    case 0:
            //        break;
            //}
            Console.ReadLine();
        }
    }
}
