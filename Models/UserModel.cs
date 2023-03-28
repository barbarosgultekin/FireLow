using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FireLow.Models
{
    public class UserModel
    {
        string username;
        string password;
        string company;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
            }
        }

   
    }
}