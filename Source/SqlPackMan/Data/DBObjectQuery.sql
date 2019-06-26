SELECT name, type AS objType FROM [SqlPackManContext-a1532056-1e24-4ac4-903c-df2ad386e23b].sys.objects WHERE  exists (Select name from DbOBject where PackageID =1)
