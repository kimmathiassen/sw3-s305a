﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Tools
{
    public static class ProblemSearch
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="catTag">A CategoryTagSelectionViewModel</param>
        /// <param name="db">DB entitites</param>
        /// <returns></returns>
        public static List<Problem> Search(CategoryTagSelectionViewModel catTag, hoplaEntities db)
        {
            List<Problem> result;

            var temp = db.ProblemSet;

            if (catTag.Categories != null)
            {
                foreach (Tag tag in catTag.AllTagsSelected())
                {
                    temp = (System.Data.Objects.ObjectSet<Problem>)temp.Where(x => x.Tags.Contains(tag));
                }
                
                result = temp.ToList();
            }
            else
            {
                result = temp.Where(x => x.Tags.Count == 0).ToList();
            }

            return result;
        }

    }
}