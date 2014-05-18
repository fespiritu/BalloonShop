using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Common;



/// <summary>
/// Wraps department details data
/// </summary>
public struct DepartmentDetails
{
    public string Name;
    public string Description;
}

public struct CategoryDetails
{
    public int DepartmentId;
    public string Name;
    public string Description;
}

public struct ProductDetails
{
    public int ProductID;
    public string Name;
    public string Description;
    public decimal Price;
    public string Thumbnail;
    public string Image;
    public bool PromoFront;
    public bool PromoDept;
}


/// <summary>
/// Product catalog business tier component
/// </summary>
public static class CatalogAccess
{
	static CatalogAccess()
	{
		
	}

    public static DataTable GetDepartments()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetDepartments";
        return GenericDataAccess.ExecuteSelectCommand(comm);

    }

    public static DepartmentDetails GetDepartmentDetails(string departmentId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogGetDepartmentDetails";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentID";
        param.Value = departmentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        DepartmentDetails details = new DepartmentDetails();
        if (table.Rows.Count > 0)
        {
            details.Name = table.Rows[0]["Name"].ToString();
            details.Description = table.Rows[0]["Description"].ToString();
        }

        return details;
    }

    public static CategoryDetails GetCategoryDetails(string categoryId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogGetCategoryDetails";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = categoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        CategoryDetails details = new CategoryDetails();
        if (table.Rows.Count > 0)
        {
            details.DepartmentId = Int32.Parse(table.Rows[0]["DepartmentID"].ToString());
            details.Name = table.Rows[0]["Name"].ToString();
            details.Description = table.Rows[0]["Description"].ToString();

        }


        return details;
    }


    public static ProductDetails GetProductDetails(string productId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogGetProductDetails";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        ProductDetails details = new ProductDetails();
        if (table.Rows.Count > 0)
        {
            //get the first table row
            DataRow dr = table.Rows[0];
            //get product details
            details.ProductID = int.Parse(productId);
            details.Name = dr["Name"].ToString();
            details.Description = dr["Description"].ToString();
            details.Price = Decimal.Parse(dr["Price"].ToString());
            details.Thumbnail = dr["Thumbnail"].ToString();
            details.Image = dr["Image"].ToString();
            details.PromoFront = bool.Parse(dr["PromoFront"].ToString());
            details.PromoDept = bool.Parse(dr["PromoDept"].ToString());

        }

        return details;
    }

    public static DataTable GetCategoriesInDepartment(string departmentId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogGetCategoriesInDepartment";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentID";
        param.Value = departmentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

        return table;
    }

    //Retrieve the list of products on catalog promotion
    public static DataTable GetProductsOnFrontPromo(string pageNumber, out int howManyPages)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogGetProductsOnFrontPromo";
      
        //
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = BalloonShopConfiguration.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = BalloonShopConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        //Calculate how many pages of products and set the out parameter
        int howManyProducts = Int32.Parse(comm.Parameters["@HoManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts /
            (double)BalloonShopConfiguration.ProductsPerPage);

        return table;
    }


}