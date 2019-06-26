
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static SqlPackMan.Models.Enums;

namespace SqlPackMan.Models
{
    public interface IDbObjectDAL
    {
        IEnumerable<string> DbObjectNames(string searchStringDB, string searchStringType,string searchStringName, int packageId );
        List<string> DbNames();
    }
    public class DbObjectDAL: IDbObjectDAL
    {
        private string _connString;
        public DbObjectDAL(string server)
        {
            _connString = GetConnString(server);
        }

        public List<string> DbNames()
        {
            List<string> retList = new List<string>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connString))
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
            return retList;
        }
           

        //cannot yield within try block with catch. Caller must enclose call in Try
        public IEnumerable<string> DbObjectNames(string searchStringDB, string searchStringType, string searchStringName,int packageId)
        {
            List<string> nameList = new List<string>();

                //Get 
                using (SqlConnection con = new SqlConnection(_connString))
                {
                //SELECT *  FROM [SqlPackManContext-a1532056-1e24-4ac4-903c-df2ad386e23b].sys.objects WHERE [name] = 'DDSEnvironment'
                string  sqlQuery = $"SELECT name FROM {searchStringDB}.sys.objects WHERE [type] IN ('{searchStringType}') ";
                        sqlQuery += "AND NOT EXISTS (SELECT name from [SqlPackManContext-a1532056-1e24-4ac4-903c-df2ad386e23b].DbObjects ";
                        sqlQuery += $"WHERE PackageId != {packageId}";
                        sqlQuery += $"AND [name] LIKE '%{searchStringName}%'";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //check for empty, make new record with no type
                    //check for more than one, throw error

                    while (rdr.Read())
                    {
                        yield return rdr.GetString(0).Trim();
                    }
                    con.Close();
                }
        }


        private string GetConnString(string server)
        {
            return
           $"Server={server};"
           + "Database=SqlPackManContext-a1532056-1e24-4ac4-903c-df2ad386e23b;"
           + "Trusted_Connection=True;MultipleActiveResultSets=true";
        }


       


        //public string GetItemType(string objName, string dbName)
        //{
        //    string retValue = "";

        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(_connString))
        //        {
        //            string sqlQuery = $"SELECT [type]  FROM {dbName}.sys.objects WHERE [name] = '{objName}'";
        //            SqlCommand cmd = new SqlCommand(sqlQuery, con);

        //            con.Open();
        //            SqlDataReader rdr = cmd.ExecuteReader();
        //            //check for empty, make new record with no type
        //            //check for more than one, throw error

        //            while (rdr.Read())
        //            {

        //                //  retValue = Conversions.GetRedGateObjectType(rdr.GetString(0).Trim());

        //            }
        //            con.Close();
        //        }
        //    }

        //    catch (Exception e)
        //    {

        //    }

        //    return retValue;
        //}

    }

}

