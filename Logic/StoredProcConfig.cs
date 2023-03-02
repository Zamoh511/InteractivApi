using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace InteractiveAssesment_API.Logic
{
    public class StoredProcConfig
    {
        
        string ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["InteractiveConnection"].ConnectionString;
        public void ExecuteStoredProcedure(string procedureName)
        {
            SqlConnection sqlConnObj = new SqlConnection(ConnString);

            SqlCommand sqlCmd = new SqlCommand(procedureName, sqlConnObj);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlConnObj.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConnObj.Close();
        }

        public void ExecuteStoredProcedure(string procedureName, object model)
        {
            var parameters = GenerateSQLParameters(model);
            SqlConnection sqlConnObj = new SqlConnection(ConnString);

            SqlCommand sqlCmd = new SqlCommand(procedureName, sqlConnObj);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            foreach (var param in parameters)
            {
                sqlCmd.Parameters.Add(param);
            }

            sqlConnObj.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConnObj.Close();

            //return "Execution Completed";
        }

        public dynamic LoadList(string procName)
        {
            SqlConnection sqlConnObj = new SqlConnection(ConnString);
            SqlDataReader rd;
            List<dynamic> dataLits = new List<dynamic>();
            using (sqlConnObj)
            {
                SqlCommand cmd = new SqlCommand(procName, sqlConnObj); 
                cmd.CommandType = CommandType.StoredProcedure;
                sqlConnObj.Open();
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dataLits.Add(rd); 
                }
                rd.Close();
            }
            sqlConnObj.Close();
            return dataLits;
            
        }

        private List<SqlParameter> GenerateSQLParameters(object model)
        {
            var paramList = new List<SqlParameter>();
            Type modelType = model.GetType();
            var properties = modelType.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    paramList.Add(new SqlParameter(property.Name, DBNull.Value));
                }
                else
                {
                    paramList.Add(new SqlParameter(property.Name, property.GetValue(model)));
                }
            }
            return paramList;

        }
    }
}
