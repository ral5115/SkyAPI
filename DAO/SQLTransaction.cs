using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebAPI.DAO
{
    public class SQLTransaction
    {
public static IConfiguration Configuration { get; set; }
        public DataSet GetStruct()
        {
            
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            DataSet result = new DataSet();
            Configuration = builder.Build();
            SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));
            SqlCommand command = new SqlCommand();
            SqlDataAdapter daData = new SqlDataAdapter();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_select_struct";
            try
            {
                daData.SelectCommand = command;
                daData.Fill(result);
                result.Tables[0].TableName = "Struct";
                result.Tables[1].TableName = "StructMasters";
                result.Tables[2].TableName = "StructDetails";
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                command.Connection.Close();
            }



            return result;
        }

    }
}
