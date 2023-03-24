using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HttpProject
{
        public class Booking
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("totalprice")]
        public long Totalprice { get; set; }

        [JsonProperty("depositpaid")]
        public bool Depositpaid { get; set; }

        [JsonProperty("bookingdates")]
        public Bookingdates Bookingdates { get; set; }

        [JsonProperty("additionalneeds")]
        public string Additionalneeds { get; set; }
    }

    public partial class Bookingdates
    {
        [JsonProperty("checkin")]
        public DateTimeOffset Checkin { get; set; }

        [JsonProperty("checkout")]
        public DateTimeOffset Checkout { get; set; }
    }
}
