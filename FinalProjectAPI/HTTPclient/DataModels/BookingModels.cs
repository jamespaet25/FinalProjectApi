using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Globalization;

namespace HTTPclient.DataModels
{
    public class BookingModels
    {
        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("totalprice")]
        public long Totalprice { get; set; }

        [JsonProperty("depositpaid")]
        public bool Depositpaid { get; set; }

        [JsonProperty("bookingdates")]
        public BookingDates Bookingdates { get; set; }

        [JsonProperty("additionalneeds")]
        public string Additionalneeds { get; set; }
    }

    public partial class BookingDates
    {
        [JsonProperty("checkin")]
        public DateTime Checkin { get; set; }

        [JsonProperty("checkout")]
        public DateTime Checkout { get; set; }
    }

    public partial class OrderDetail
    {
        [JsonProperty("bookingid")]
        public long BookingId { get; set; }

        [JsonProperty("booking")]
        public BookingModels Booking { get; set; }

    }
}
