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
        private List<Role> _roles;
        /*public class PersonMetaData
        {
           


        }*/

        public List<Role> Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = Tools.SQLf.GetRoles();
                    List<Role> allRoles;
                    try
                    {
                        allRoles = Tools.SQLf.GetRolesOfUser(this.Name);
              
                        foreach (var role in _roles)
                        {
                            foreach (var item in allRoles)
                            {
                                if (item.Name == role.Name)
                                {
                                    role.Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                    catch (ArgumentException)
                    {

                    }
                }
                
                return _roles;
            }

            private set
            {
                _roles = value;
            }
        }

        public bool IsStaff()
        {
            foreach (var role in Roles)
            {
                if (role.Name == "Staff" && role.Selected)
                {
                    return true;
                }
            }

            return false;
        }

        public double Workload { get { return GetWorkload(); } }

        public List<Problem> SortedWorklist { get { return GetSortedList(); } }

        private List<Problem> GetSortedList(){
            List<Problem> problemList = Worklist.ToList().Where(x =>  x.SolvedAtTime == null && x.IsDeadlineApproved == true).ToList();

            List<Problem> problemWithoutDeadline = Worklist.ToList().Where(x => x.SolvedAtTime == null && (x.IsDeadlineApproved == false || x.IsDeadlineApproved == null)).ToList();


            problemList.Sort(Problem.GetComparer());

            problemWithoutDeadline.Sort(Problem.GetComparer());

            problemList.AddRange(problemWithoutDeadline);

            return problemList;
        }

        public double GetWorkload()
        {
            int NumberOfTags = 0;
            decimal? ProblemTime = 0;
            decimal? PersonTime = 0;

            foreach (Problem problem in Worklist)
            {
                foreach (Tag tag in problem.Tags)
                {
                    if (tag.AverageTimeSpent != null)
                    {
                        ProblemTime = ProblemTime + tag.AverageTimeSpent;
                    }
                    NumberOfTags++;
                }

                if(NumberOfTags == 0){
                    NumberOfTags = 1;
                    ProblemTime = 10;
                }

                PersonTime = PersonTime + ProblemTime/NumberOfTags;
                NumberOfTags = 0;
                ProblemTime = 0;
                 

            }

            return (double)PersonTime;
        }
        /*
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
         * */
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