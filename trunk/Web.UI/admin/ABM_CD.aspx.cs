﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UI.admin
{
    public partial class ABM_CD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RangeValidator.MaximumValue = DateTime.Today.ToString("yyyy");
        }
    }
}