﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPclient.Resources
{
    public class Endpoints
    {
        public const string BaseUrl = "https://restful-booker.herokuapp.com";

        public static string PostBooking() => $"{BaseUrl}/booking";

        public static string GetBookingById(long id) => $"{BaseUrl}/booking/{id}";

        public static string PutBookingById(long id) => $"{BaseUrl}/booking/{id}";

        public static string DeleteBookingById(long id) => $"{BaseUrl}/booking/{id}";

        public static string AuthenticateUser() => $"{BaseUrl}/auth";
    }
}
