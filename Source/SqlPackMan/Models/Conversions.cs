using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public static class Conversions
    {
        public static string GetRedGateObjectType(string sqlType)
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
