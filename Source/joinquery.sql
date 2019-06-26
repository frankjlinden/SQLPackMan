select name,packobj.PackageId from DB1.sys.objects dbobj Left Join sqlPackManContext.dbo.DbObject packobj on dbobj.name = packobj.objectname;
