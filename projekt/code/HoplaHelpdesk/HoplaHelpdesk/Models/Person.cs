﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Objects.DataClasses;

namespace HoplaHelpdesk.Models
{

    //[MetadataType(typeof(PersonMetaData))]
    public partial class Person : IPerson
    {

        /*public class PersonMetaData
        {
           


        }*/


        public bool IsStaff()
        {
            if (DepartmentId == 0)
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        public double Workload { get { return GetWorkload(); } }

        public double GetWorkload()
        {
            int TotalNumberOfTags = 0;
            decimal? ProblemTime = 0;
            decimal? PersonTime = 0;

            foreach (Problem problem in Problems)
            {
                foreach (Tag tag in problem.Tags)
                {
                    if (tag.AverageTimeSpent != null)
                    {
                        ProblemTime = ProblemTime + tag.AverageTimeSpent;
                    }
                    TotalNumberOfTags++;
                }


                PersonTime = PersonTime + ProblemTime;
                ProblemTime = 0;

            }

            return ((double)(PersonTime)/TotalNumberOfTags);
        }
    }

    public interface IPerson 
    {
        bool IsStaff();
        double GetWorkload();
        string Name { get; set; }
        string Email { get; set; }
        EntityCollection<Problem> Worklist { get; set; }
        int Id { get; set; }
        Department Department { get; set; }
    }
}