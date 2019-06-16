
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SqlPackMan.Models
{
    public class dbObjectDAL
    {
        private string connString;
        public dbObjectDAL(string server)
        {
            connString = GetConnString(server);
        }

        //To View all employees details    
        public string GetItemType(string objName, string dbName)
        {
            string retValue = "";

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
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

        public List<string> DbNames()
        {
            List<string> retList = new List<string>();

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    string sqlQuery = $"SELECT name  FROM master.dbo.sysdatabases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //check for empty, make new record with no type
                    //check for more than one, throw error

                    while (rdr.Read())
                    {

                        //  retValue = Conversions.GetRedGateObjectType(rdr.GetString(0).Trim());
                        retList.Add(rdr.GetString(0).Trim());
                    }
                    con.Close();
                }
            }

            catch (Exception e)
            {
                throw(e);
            }
            return retList;
        }

        public IQueryable DbObjectNames(string dbName, string sqlType, string nameSearchString)
        {
            List<string> retList = new List<string>();

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    string sqlQuery = $"SELECT name  FROM master.dbo.sysdatabases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //check for empty, make new record with no type
                    //check for more than one, throw error

                    while (rdr.Read())
                    {
                        //  retValue = Conversions.GetRedGateObjectType(rdr.GetString(0).Trim());
                        retList.Add(rdr.GetString(0).Trim());
                    }
                    con.Close();
                }
            }

            catch (Exception e)
            {
                throw (e);
            }
            return retList.AsQueryable();
        }

      

        public string GetConnString(string server)
        {
            return
           $"Server={server};"
           + "Database=SqlPackManContext-a1532056-1e24-4ac4-903c-df2ad386e23b;"
           + "Trusted_Connection=True;MultipleActiveResultSets=true";
        }




    }

}

