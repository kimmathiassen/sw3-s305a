﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects.DataClasses;
using HoplaHelpdesk.Tools;

namespace HoplaHelpdesk.Models
{
    public partial class Department
    {

        public string Name
        {
            get { return DepartmentName; }
            set { DepartmentName = value; }
        }
        /// <summary>
        /// Balance the workload between all staffs in  a department. 
        /// </summary>
        public void BalanceWorkload()
        {
            // Run through all persons.
            for (var i = 0; i < Persons.Count; i++)
            {
                    // Find the person with the highest workload
                    var max = Persons.FirstOrDefault(y => y.GetWorkload() == Persons.Max(x => x.GetWorkload()));

                    // If there is no person. 
                    if (max.Worklist == null)
                    {
                        return;
                    }

                    // Sort his worklist so that the highest priority is the first.
                    max.Worklist.ToList().Sort(Problem.GetComparer());

                    // Find the person with the lowest workload
                    var min = Persons.FirstOrDefault(y => y.GetWorkload() == Persons.Min(x => x.GetWorkload()));
                 
                    // If max and min is the same person.
                    if (max == min)
                    {
                        return;
                    }

                    // To determine the while loop.
                    bool couldStillMove = true;
                    do
                    {
                        // Finde the reassignable problem with the highest priority which has not been moved yet. 
                        var problemToBeMoved = max.Worklist.FirstOrDefault(y => y.Reassignable == true && y.HasBeen == false && y.SolvedAtTime == null);
                        // If none can be moved, move on to the next iteration.
                        if (problemToBeMoved == null)
                        {
                            couldStillMove = false;
                        }
                        else
                        {
                            // Mark as has been moved
                            problemToBeMoved.HasBeen = true;

                            // Reassign the highest priority problem to staff called min.
                            problemToBeMoved.AssignedTo = min;
                            if (min.Workload > max.Workload)
                            {
                                // Move it back
                                problemToBeMoved.AssignedTo = max;
                                couldStillMove = false;
                            }
                            else if (min.Workload == max.Workload)
                            {
                                // Don't move bakc if they are equal
                                couldStillMove = false;
                            }
                        }

                    } while (couldStillMove);
                }
            }
        
        
    }
}