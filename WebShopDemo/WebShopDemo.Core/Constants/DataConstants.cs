using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopDemo.Core.Constants
{
    public static class DataConstants
    {
        public static class Product
        {
            public const int NameMaxLenght = 50;

            public const int NameMinLenght = 2;
        }

        public static class User
        {
            public const int FirstNameMaxLenght = 20;
            public const int LastNameMaxLenght = 20;
        }

        public static class ClaimType
        {
            public const string FirstName = "urn:softuni:webshop:firstname";
        }

        public static class Roles
        {
            public const string Manager = "Manager";
            public const string Supervisor = "Supervisor";
            public const string Admin = "Administrator";
            //public const string User = "User";
        }

        public static class Policies
        {
            public const string CanAddRolesToUsers = "CanAddRolesToUsers";
        }
        
    }
}
