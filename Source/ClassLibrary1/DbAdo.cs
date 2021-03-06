﻿using System;

namespace DbObjectHandler
{
    public class Conversion
    {
        public string GetRedGateObjectType(string sqlType)
        {
            string strReturn = "";
            switch (sqlType)
            {
                case "U":
                    strReturn = "Table";
                    break;
                case "V":
                    strReturn = "View";
                    break;
                case "P":
                    strReturn = "StoredProcedure";
                    break;
                case "FN":
                case "FT":
                case "IF":
                    strReturn = "Function";
                    break;
                case "SO":
                    strReturn = "Sequence";
                    break;
            }
            return strReturn;
        }
    }
}
