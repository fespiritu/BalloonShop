﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_DepartmentsList : System.Web.UI.UserControl
{
    //Load department details into the DataList
    protected void Page_Load(object sender, EventArgs e)
    {
        //CatalogAccess.GetDepartments returns a DataTable object containing
        // department data, which is read in the ItemTemplate of the DataList
        list.DataSource = CatalogAccess.GetDepartments();

        list.DataBind();
    }
}