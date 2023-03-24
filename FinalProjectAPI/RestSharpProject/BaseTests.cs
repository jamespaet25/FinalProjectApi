using RestSharp;
using RestSharpProject.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestSharpProject
{
    public class BaseTests
    {
            public RestClient restClient { get; set; }
            public BookingModels bookingModel { get; set; }

            public BookHelper bookingHelper { get; set; }

            public string token;

            [TestInitialize]
            public async Task Initialize()
            {
                restClient = new RestClient();
                bookingHelper = new BookHelper();
                token = await bookingHelper.GetToken(restClient);
            }

     }
}



