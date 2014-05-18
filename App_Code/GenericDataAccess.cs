using System;


using System.Data;
using System.Data.Common;

/// <summary>
/// Summary description for GenericDataAccess
/// </summary>
public static class GenericDataAccess
{
	static GenericDataAccess()
	{
		
	}

    public static DataTable ExecuteSelectCommand(DbCommand command)
    {
        DataTable table;

        try
        {
            command.Connection.Open();

            DbDataReader reader = command.ExecuteReader();
            table = new DataTable();
            table.Load(reader);

            reader.Close();
        }
        catch (Exception)
        {
            //log error
            throw;
        }
        finally
        {
            command.Connection.Close();

        }

        return table;
    }


    public static DbCommand CreateCommand()
    {
        //Obtain the db provider name
        string dataProviderName = BalloonShopConfiguration.DbProviderName;
        string connectionString = BalloonShopConfiguration.DbConnectionString;

        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);
        DbConnection conn = factory.CreateConnection();

        conn.ConnectionString = connectionString;
        DbCommand comm = conn.CreateCommand();
        comm.CommandType = CommandType.StoredProcedure;
        return comm;

    }
}