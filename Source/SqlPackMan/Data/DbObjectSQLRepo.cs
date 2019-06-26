using Microsoft.EntityFrameworkCore;
using SqlPackMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Data
{
    public class DbObjectSqlRepo
    {
        private readonly SqlPackManContext _context;

        public DbObjectSqlRepo(SqlPackManContext context) {
            _context = context;
            
        }
        public IQueryable<DbObjectName> GetDbObjNameIQ(string searchStringDB, string searchStringType,string searchStringName)
        {
            string sqlQuery = $"SELECT name, pkgObj.PackageId FROM {searchStringDB}.sys.objects dbObj ";
            sqlQuery += "LEFT JOIN sqlPackManContext.dbo.DbObject pkgObj ";
            sqlQuery += "ON dbObj.name = pkgObj.ObjectName ";
            sqlQuery += $"WHERE [type] IN ('{searchStringType}') ";
            sqlQuery += $"AND [name] LIKE '%{searchStringName}%'";

            return  _context.DbObjectName.FromSql(sqlQuery);

        }


    }
}
