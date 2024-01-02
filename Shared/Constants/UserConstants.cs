using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Constants
{
    public static class UserConstants
    {
        public static readonly int MAX_LOGIN_ATTEMPTS = 5;
        public static readonly string LOGIN_METHOD_PHONE = "PHONE";
        public static readonly string LOGIN_METHOD_EMAIL = "EMAIL";
        public static readonly string ACCOUNT_STATUS_LOCKED = "LOCKED";
        public static readonly string ACCOUNT_STATUS_DISABLED = "DISABLED";
        public static readonly string ACCOUNT_STATUS_CREATED = "CREATED";
       
    }

    public static class UtilityConstants
    {
        public static readonly int VEHICLE_EXCEL_SHEET_FILED_COUNT = 14;
    }
}
