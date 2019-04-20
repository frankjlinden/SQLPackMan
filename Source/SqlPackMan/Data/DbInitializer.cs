using SqlPackMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                var dbObjectTypes = new DbObjectType[]
                {
                new DbObjectType{SqlType="U",RGType="Table"},
                new DbObjectType{SqlType="V",RGType="View"},
                new DbObjectType{SqlType="P",RGType="StoredProcedure"},
                new DbObjectType{SqlType="FN,FT,IF",RGType="Function"},
                new DbObjectType{SqlType="SQ",RGType="Sequence"}
                };
                foreach (DbObjectType type in dbObjectTypes)
                {
                    context.Add(type);
                }
                context.SaveChanges();
            }

            //STATUS
            if (!context.Status.Any())
            {
                var status = new Status[]
                   {
                new Status{Label="Development"},
                new Status{Label="Admin Review"},
                new Status{Label="Queued"},
                new Status{Label="Test Review"},
                new Status{Label="Current"},
                new Status{Label="Error"}
                   };
                foreach (Status stat in status)
                {
                    context.Add(stat);
                }
                context.SaveChanges();
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
                    new DbObject{PackageId=3,ObjectName="Table1",DbObjectTypeId=1, StatusId=1, Tags = new HashSet<string>{"Form1,Report1"}},
                    new DbObject{PackageId=4,ObjectName="Table2",DbObjectTypeId=1, StatusId=1, Tags = new HashSet<string>{"Form2,Report2"}},
                    new DbObject{PackageId=5,ObjectName="Table3",DbObjectTypeId=1, StatusId=1, Tags = new HashSet<string>{"Form3,Report3"}},
                    new DbObject{PackageId=3,ObjectName="View1",DbObjectTypeId=2, StatusId=1, Tags = new HashSet<string>{"Form1,Report1"}},
                    new DbObject{PackageId=4,ObjectName="View2",DbObjectTypeId=2, StatusId=1, Tags = new HashSet<string>{"Form2,Report2"}},
                    new DbObject{PackageId=5,ObjectName="View3",DbObjectTypeId=2, StatusId=1, Tags = new HashSet<string>{"Form3,Report3"}},
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
