using SqlPackMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SqlPackMan.Models.Enums;

namespace SqlPackMan.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SqlPackManContext context)
        {
            //ENVIRONMENTS
            if (!context.DdsEnvironment.Any())
            {
                var environments = new DdsEnvironment[]
                {
                new DdsEnvironment{Name="DEV",Server="(localdb)\\mssqllocaldb", SchemaPath="G:\\RedGate\\DBSource"},
                new DdsEnvironment{Name="QA",Server="(localdb)\\mssqllocaldb", SchemaPath="G:\\RedGate\\DBSource"},
                new DdsEnvironment{Name="STAG",Server="(localdb)\\mssqllocaldb", SchemaPath="G:\\RedGate\\DBSource"},
                new DdsEnvironment{Name="PROD",Server="(localdb)\\mssqllocaldb", SchemaPath="G:\\RedGate\\DBSource"}
                };
                foreach (DdsEnvironment env in environments)
                {
                    context.Add(env);
                }
                context.SaveChanges();
            }
           
            //DbObjectTypes
            if (!context.DbObject.Any())
            {
              
            }

         
            if (!context.Package.Any())
            {
                //Packages
                var packages = new Package[]
            {
                new Package{ DbName="DB1",  Description="Test Package for DB1 Feature1",Name="Feature1",Version=1,MaxEnvironmentId=4},
                new Package{ DbName="DB1",  Description="Test Package for DB1 Feature2",Name="Feature2",Version=1,MaxEnvironmentId=4},
                new Package{ DbName="DB1",  Description="Test Package for DB1 Feature3",Name="Feature3",Version=1,MaxEnvironmentId=4},
            };
                foreach (Package pkg in packages)
                {
                    context.Add(pkg);
                }
                context.SaveChanges();
            }
            
            //DbObjects
            if (!context.DbObject.Any())
            {
                var dbObjects = new DbObject[] {
                    new DbObject{PackageId=3,ObjectName="Table1",DbObjectType=DbObjectType.Table, Status=Status.Development, Tags = new HashSet<string>{"Form1,Report1"}},
                    new DbObject{PackageId=4,ObjectName="Table2",DbObjectType=DbObjectType.Table, Status=Status.Development, Tags = new HashSet<string>{"Form2,Report2"}},
                    new DbObject{PackageId=5,ObjectName="Table3",DbObjectType=DbObjectType.Table, Status=Status.Development, Tags = new HashSet<string>{"Form3,Report3"}},
                    new DbObject{PackageId=3,ObjectName="View1",DbObjectType=DbObjectType.View, Status=Status.Development, Tags = new HashSet<string>{"Form1,Report1"}},
                    new DbObject{PackageId=4,ObjectName="View2",DbObjectType=DbObjectType.View, Status=Status.Development, Tags = new HashSet<string>{"Form2,Report2"}},
                    new DbObject{PackageId=5,ObjectName="View3",DbObjectType=DbObjectType.View, Status=Status.Development, Tags = new HashSet<string>{"Form3,Report3"}},
                };
                foreach (DbObject dbo in dbObjects)
                {
                    context.Add(dbo);
                }
                context.SaveChanges();

            }
        }
    }
}
