﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoplaHelpdesk.Models
{
    public partial class Category
    {

        public bool IsHidden()
        {
            return false;
            bool isHidden = true;
            foreach (var tag in Tags)
            {
                if (!tag.Hidden)
                {
                    return false;
                }


            }
            return isHidden;
        }
    }
}