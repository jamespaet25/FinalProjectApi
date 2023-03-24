using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharpProject.DataModels;

namespace RestSharpProject.Test.TestData
{
    public class GenerateBookData
    {
        public static BookingModels BookingDetails()
        {
            return new BookingModels
            {
                Firstname = "Kellin",
                Lastname = "Quin",
                Totalprice = 4000,
                Depositpaid = true,
                Bookingdates = new BookDates
                {
                    Checkin = "2030-01-20",
                    Checkout = "2030-01-29"
                },
                Additionalneeds = "Dinner"
            };
        }

    }
}
