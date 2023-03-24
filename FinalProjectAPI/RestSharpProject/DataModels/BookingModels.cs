using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RestSharpProject.DataModels
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
        public BookDates Bookingdates { get; set; }

        [JsonProperty("additionalneeds")]
        public string Additionalneeds { get; set; }
    }

}
