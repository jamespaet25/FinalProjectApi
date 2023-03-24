using RestSharpProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Test.TestData
{
    public class GenerateToken
    {
        public static LoginModels newToken()
        {
            return new LoginModels
            {
                Username = "admin",
                Password = "password123"

            };
        }
    }
}
