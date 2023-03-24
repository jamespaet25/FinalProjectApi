using HTTPclient.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPclient.Test.TestData
{
    public class GenerateBooking
    {
        public static BookingModels bookingDetails()
        {
            return new BookingModels
            {
                Firstname = "Kellin",
                Lastname = "Quin",
                Totalprice = 4000,
                Depositpaid = true,
                Bookingdates = new BookingDates
                {
                    Checkin  = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
                    Checkout = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"))
                },
                Additionalneeds = "Dinner"
            };
        }

        public static OrderDetail newDetails()
        {
            return new OrderDetail
            {

            };
        }
    }
}
