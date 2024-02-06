using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Utilities
{
    public static class AppConstants
    {
        public enum RoleType
        {
            SuperAdmin = 1,
            Admin = 2,
            Staff = 3,
            Customer = 4
        }
    }
}