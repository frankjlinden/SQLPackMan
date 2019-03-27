
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SqlPackMan.Models
{
    public class ItemDAL
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Master;Integrated Security=true;";
  

        //To View all employees details    
        public string GetItemType(string objName, string dbName)
        {
            string retValue = "";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"SELECT [type]  FROM {dbName}.sys.objects WHERE [name] = '{objName}'";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //check for empty, make new record with no type
                    //check for more than one, throw error

                    while (rdr.Read())
                    {
                       
                      //  retValue = Conversions.GetRedGateObjectType(rdr.GetString(0).Trim());
                       
                    }
                    con.Close();
                }
            }

            catch (Exception e)
            {

            }


            return retValue;



        }
        }
}
