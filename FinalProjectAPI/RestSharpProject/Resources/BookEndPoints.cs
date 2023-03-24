using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Resources
{
    public class BookEndPoints
    {
        public const string BaseUrl = "https://restful-booker.herokuapp.com";

        public static string PostBooking() => $"{BaseUrl}/booking";

        public static string GetBookingById(long bookingId) => $"{BaseUrl}/booking/{bookingId}";

        public static string PutBookingById(long bookingId) => $"{BaseUrl}/booking/{bookingId}";

        public static string DeleteBookingById(long bookingId) => $"{BaseUrl}/booking/{bookingId}";

        public static string AuthenticateUser() => $"{BaseUrl}/auth";
    }
}
