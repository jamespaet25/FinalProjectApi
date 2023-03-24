
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;
using HTTPclient.DataModels;
using HTTPclient;
using HTTPclient.Resources;
using HTTPclient.Test.TestData;
using HTTPclient.Helpers;

[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.MethodLevel)]

namespace HttpProject
{
    [TestClass]
    public class PostProject : HttpApiTest
    {
        private readonly List<OrderDetail> cleanUpList = new List<OrderDetail>();

        [TestInitialize]
        public async Task Initialize()
        {
            httpClient = new HttpClient();

            Token token = await userAuth.AuthenticateUser(httpClient);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Cookie", $"token={token.TokenAuth}");
        }

        [TestCleanup]
        public async Task CleanUp()
        {
            foreach (var data in cleanUpList)
            {
                var httpResponse = await httpClient.DeleteAsync(Endpoints.DeleteBookingById(data.BookingId));
            }
        }

        /// <summary>
        /// Create new book details
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        
        public async Task PostNewBook()
        {
            BookingModels Booking = GenerateBooking.bookingDetails();

            var postRequest = await BookingHelper.PostBooking(httpClient, Booking);
            var postDeserialize = JsonConvert.DeserializeObject<OrderDetail>(postRequest.Content.ReadAsStringAsync().Result);

            cleanUpList.Add(postDeserialize);

            var getResponse = await BookingHelper.GetBookingById(httpClient, postDeserialize.BookingId);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, postRequest.StatusCode, "Status not match. Should be 200");
            Assert.AreEqual(Booking.Firstname, getResponse.Firstname, "Firstname did not match");
            Assert.AreEqual(Booking.Lastname, getResponse.Lastname, "Lastname did not match");
            Assert.AreEqual(Booking.Totalprice, getResponse.Totalprice, "Total price not match");
            Assert.AreEqual(Booking.Depositpaid, getResponse.Depositpaid, "Deposit incorrect");
            Assert.AreEqual(Booking.Bookingdates.Checkin, getResponse.Bookingdates.Checkin, "Check-in date not match");
            Assert.AreEqual(Booking.Bookingdates.Checkout, getResponse.Bookingdates.Checkout, "Check-out date not match");
            Assert.AreEqual(Booking.Additionalneeds, getResponse.Additionalneeds, "Additional need ");
        }

        /// <summary>
        /// Update the created booking
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        
        public async Task PutMethod()
        {
            BookingModels Booking = GenerateBooking.bookingDetails();
            
            var postRequest = await BookingHelper.PostBooking(httpClient, Booking);
            var postDeserialize = JsonConvert.DeserializeObject<OrderDetail>(postRequest.Content.ReadAsStringAsync().Result);

            cleanUpList.Add(postDeserialize);

            postDeserialize.Booking.Firstname = "Vic";
            postDeserialize.Booking.Lastname = "Fuentes";

            var putResponse = await BookingHelper.PutBookingById(httpClient, postDeserialize);
            var getResponse = await BookingHelper.GetBookingById(httpClient, postDeserialize.BookingId);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, putResponse.StatusCode, "Status code not 200");
            Assert.AreEqual(postDeserialize.Booking.Firstname, getResponse.Firstname, "Firstname did not match");
            Assert.AreEqual(postDeserialize.Booking.Lastname, getResponse.Lastname, "Lastname did not match");
        }

        /// <summary>
        /// Delete Booking Details
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task DeleteBooking()
        {
            BookingModels Booking = GenerateBooking.bookingDetails();
            
            var postRequest = await BookingHelper.PostBooking(httpClient, Booking);
            var postDeserialize = JsonConvert.DeserializeObject<OrderDetail>(postRequest.Content.ReadAsStringAsync().Result);

            cleanUpList.Add(postDeserialize);

            var deleteResponse = await BookingHelper.DeleteBookingById(httpClient, postDeserialize.BookingId);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, deleteResponse.StatusCode, "Status code not 200");
        }


        [TestMethod]
        public async Task GetInvalidBookingId()
        {
            long invalidId = 404040;

            var getResponse = await BookingHelper.GetBookingByInvalidId(httpClient, invalidId);

            Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode, "Status code not 200");
        }

        public class userAuth
        {
            public static async Task<Token> AuthenticateUser(HttpClient httpClient)
            {
                UserToken user = new UserToken();
                var serialized = JsonConvert.SerializeObject(user);
                var request = new StringContent(serialized, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(Endpoints.AuthenticateUser(), request);

                var deserialized = JsonConvert.DeserializeObject<Token>(response.Content.ReadAsStringAsync().Result);

                Token token = new Token();
                token.TokenAuth = deserialized.TokenAuth;

                return token;
            }
        }
    }
}
