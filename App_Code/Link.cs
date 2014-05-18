using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Link
/// </summary>
public class Link
{
	//Builds an absolute URL
    private static string BuildAbsolute(string relativeUri)
    {
        //get current uri
        //e.g. http://www.example.com/Default.aspx
        Uri uri = HttpContext.Current.Request.Url;

        //build absolute path
        //e.g. /
        string app = HttpContext.Current.Request.ApplicationPath;
        if (!app.EndsWith("/")) app += "/";
        relativeUri = relativeUri.TrimStart('/');   //Catalog.aspx?DepartmentID=1

        //return the absolute path
        string urlPath = HttpUtility.UrlPathEncode(
            String.Format("http://{0}:{1}{2}{3}",
            uri.Host,
            uri.Port,
            app,
            relativeUri));
        //e.g. http://www.example.com:80/Catalog.aspx?DepartmentID=1
        return urlPath;

    }


    //Generate a department URL
    public static string ToDepartment(string departmentId, string page)
    {
        if(page == "1")
            return BuildAbsolute(String.Format("Catalog.aspx?DepartmentID={0}",departmentId));
        else
            return BuildAbsolute(String.Format("Catalog.aspx?DepartmentID={0}&Page={1}",departmentId, page));

    }


    //Generate a department URL for the first page
    public static string ToDepartment(string departmentId)
    {
        return ToDepartment(departmentId,"1");
    }
}