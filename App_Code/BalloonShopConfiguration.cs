using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;

/// <summary>
/// Repository for BalloonShop Configuration settings
/// </summary>
public static class BalloonShopConfiguration
{
    //cache the conn string
    private static string dbConnectionString;
    private static string dbProviderName;


    private readonly static int productsPerPage;
    private readonly static int productDescriptionLength;
    private readonly static string siteName;

	static BalloonShopConfiguration()
	{
        dbConnectionString = ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ProviderName;

        productsPerPage = System.Int32.Parse(ConfigurationManager.AppSettings["ProductsPerPage"]);
        productDescriptionLength = System.Int32.Parse(ConfigurationManager.AppSettings["ProductDescriptionLenght"]);
        siteName = ConfigurationManager.AppSettings["SiteName"];
	}

    public static string DbConnectionString
    {
        get
        {
            return dbConnectionString;
        }
    }

    public static string DbProviderName
    {
        get { return dbProviderName; }
    }
    public static int ProductsPerPage
    {
        get { return productsPerPage; }
    }
    public static int ProductDescriptionLength
    {
        get { return productDescriptionLength; }
    }
    public static string SiteName
    {
        get { return siteName; }
    }

}