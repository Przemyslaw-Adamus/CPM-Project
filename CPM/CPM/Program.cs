﻿using System;
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

            var graph = new Graph();
            var solver = new Solver();
            String choose = "-1";
            while(choose != "0"){
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("                  MENU                   ");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("1. Consequences of events CPM");
                Console.WriteLine("2. Preceding activities  CPM");
                Console.WriteLine("3. Consequences of events CPM + PERT");
                Console.WriteLine("4. Preceding activities CPM + PERT");
                Console.WriteLine("0. Close");
                Console.Write("Your choose: ");
                choose = Console.ReadLine();

                if(choose != "0" && choose != "1" && choose != "2" && choose != "3" && choose != "4")
                {
                    choose = "-1";
                    Console.WriteLine("You have chosen the wrong option.Make your selection again. Press ENTER");
                    Console.ReadLine();
                }
                else
                {
                    switch (choose)
                    {
                        case "1":
                            {
                                graph.CreateGraphIncidients();
                                solver.LoadGraph(graph);
                                solver.CalculateGraphValues();
                                graph.ShowGraph();
                                var cp = solver.FindIncidentsCriticalPath();
                                solver.ShowCriticalPath(cp);
                                Console.WriteLine("Press ENTER");
                                Console.ReadLine();
                            }
                            break;
                        case "2":
                            {
                                int[] perviousActivity;
                                int countPreviousActivity;
                                double duration;
                                int countActivities = 0;

                                Console.WriteLine("Give the number of activities: ");
                                countActivities = int.Parse(Console.ReadLine());
                                for (int i = 0; i < countActivities; i++)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter the duration of this activity: ");
                                    duration = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Give the number of preceding activities has this action: ");
                                    countPreviousActivity = int.Parse(Console.ReadLine());
                                    perviousActivity = new int[countPreviousActivity];
                                    for (int j = 0; j < countPreviousActivity; j++)
                                    {
                                        Console.Write(j + " - ");
                                        perviousActivity[j] = int.Parse(Console.ReadLine());
                                    }
                                    graph.NewActivity(new Activity(i, duration, perviousActivity));
                                    Console.WriteLine("Activity number " + i + " has been added. Press ENTER");
                                    Console.ReadLine();
                                }
                                graph.CreateIncidentsModeActivities();
                                solver.LoadGraph(graph);
                                solver.CalculateGraphValues();
                                graph.ShowGraph();
                                var cpp = solver.FindIncidentsCriticalPath();
                                solver.ShowCriticalPath(cpp);
                                Console.WriteLine("Press ENTER");
                                Console.ReadLine();
                            }
                            break;
                        case "3":
                            {
                                int numberActivities = 0;
                                double optimisticTime;
                                double pessimisticTime;
                                double probableTime;
                                int idParent;
                                int idChildren;
                                double directiveTime;
                                Console.WriteLine("Give the number of activities: ");
                                numberActivities = int.Parse(Console.ReadLine());
                                for (int i = 0; i < numberActivities; i++)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter the optimistic time of this activity: ");
                                    optimisticTime = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the pessimistic time of this activity: ");
                                    pessimisticTime = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the probable time of this activity: ");
                                    probableTime = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the id Parent of this activity: ");
                                    idParent = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the id Child of this activity: ");
                                    idChildren = int.Parse(Console.ReadLine());
                                    graph.Activities.Add(new Activity(i, optimisticTime, pessimisticTime, probableTime, idParent, idChildren));
                                    Console.WriteLine("Activity number " + i + " has been added. Press ENTER");
                                }

                                graph.CreateIncidents();
                                solver.LoadGraph(graph);
                                solver.CalculateGraphValues();
                                graph.ShowGraph();
                                var cppp = solver.FindIncidentsCriticalPath();
                                solver.ShowCriticalPath(cppp);
                                Console.WriteLine("Press ENTER to PERT");
                                Console.ReadLine();
                                Console.WriteLine("Enter the directive time of this activity: ");
                                directiveTime = int.Parse(Console.ReadLine());
                                Console.WriteLine("The probability is " + solver.CalculatePERT(directiveTime) + " %");
                                Console.ReadLine();
                            }
                            break;
                        case "4":
                            {
                                double directiveTime;
                                
                                //-----------------------------------
                                    //TWORZENIE GRAFU PODAJĄC POPRZEDNIE CZYNNOŚCI
                                //----------------------------------

                                solver.LoadGraph(graph);
                                solver.CalculateGraphValues();
                                graph.ShowGraph();
                                var cppp = solver.FindIncidentsCriticalPath();
                                solver.ShowCriticalPath(cppp);
                                Console.WriteLine("Press ENTER to PERT");
                                Console.ReadLine();
                                Console.WriteLine("Enter the directive time of this activity: ");
                                directiveTime = int.Parse(Console.ReadLine());
                                Console.WriteLine("The probability is " + solver.CalculatePERT(directiveTime) + " %");
                                Console.ReadLine();
                            }
                            break;
                        case "0":
                            break;
                    }
                }

                Console.Clear();
            }
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
