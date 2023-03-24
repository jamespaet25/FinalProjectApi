using HTTPclient.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPclient
{
    [TestClass]
    public class HttpApiTest
    {
        public HttpClient httpClient { get; set; }

        public BookingModels bookingModel { get; set; }



        [TestInitialize]
        public void Initialize()
        {
            httpClient = new HttpClient();
        }

        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}
