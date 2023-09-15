﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSMS
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userLogout();
        }

        public void userLogout()
        {
            Session.Abandon();
            Response.Redirect("~/index.aspx");
        }
    }
}