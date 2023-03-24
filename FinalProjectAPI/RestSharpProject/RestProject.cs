
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharpProject.DataModels;
using RestSharp;
using System.Net;
using RestSharpProject;
using RestSharpProject.Resources;


namespace Project1
{
    [TestClass]
    public class RestProject : BaseTests
    {
        private readonly List<BookingResponseModel> cleanUpList = new List<BookingResponseModel>();

        [TestCleanup]
        public async Task CleanUp()
        {
            foreach (var data in cleanUpList)
            {
                var deleteResponse = await bookingHelper.DeleteBooking(restClient, data.Bookingid, token);

            }

        }

        /// <summary>
        /// Create the Booking Data
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task CreateBooking()
        {
            //Arrange
            var response = await bookingHelper.CreateBooking(restClient);
            var newBooking = JsonConvert.DeserializeObject<BookingResponseModel>(response.Content);

            cleanUpList.Add(newBooking);

            //Act
            var getBooking = await bookingHelper.GetBookingById(restClient, newBooking.Bookingid);

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(newBooking.BookingDetails.Firstname, getBooking.Firstname);
            Assert.AreEqual(newBooking.BookingDetails.Lastname, getBooking.Lastname);
            Assert.AreEqual(newBooking.BookingDetails.Totalprice, getBooking.Totalprice);
            Assert.AreEqual(newBooking.BookingDetails.Depositpaid, getBooking.Depositpaid);
            Assert.AreEqual(newBooking.BookingDetails.Bookingdates.Checkout, getBooking.Bookingdates.Checkout);
            Assert.AreEqual(newBooking.BookingDetails.Bookingdates.Checkin, getBooking.Bookingdates.Checkin);

        }

        /// <summary>
        /// Update Booking
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task UpdateBooking()
        {
            //Arrange
            var response = await bookingHelper.CreateBooking(restClient);
            var newBooking = JsonConvert.DeserializeObject<BookingResponseModel>(response.Content);
            cleanUpList.Add(newBooking);

            var updateBooking = new BookingModels()
            {
                Firstname = "Vic",
                Lastname = "Fuentes",
                Totalprice = 5099,
                Depositpaid = true,
                Bookingdates = new BookDates
                {
                    Checkin = "2030-03-19",
                    Checkout = "2030-03-20"
                },
                Additionalneeds = "Jack Daniels"

            };


            //Act
            var updateResponse = await bookingHelper.UpdateBookingById(restClient, newBooking.Bookingid, updateBooking, token);
            var updateData = JsonConvert.DeserializeObject<BookingModels>(updateResponse.Content);

            var getBooking = await bookingHelper.GetBookingById(restClient, newBooking.Bookingid);

            //Assert
            Assert.AreEqual(updateResponse.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(updateData.Firstname, getBooking.Firstname);
            Assert.AreEqual(updateData.Lastname, getBooking.Lastname);
            Assert.AreEqual(updateData.Totalprice, getBooking.Totalprice);
            Assert.AreEqual(updateData.Depositpaid, getBooking.Depositpaid);
            Assert.AreEqual(updateData.Bookingdates.Checkout, getBooking.Bookingdates.Checkout);
            Assert.AreEqual(updateData.Bookingdates.Checkin, getBooking.Bookingdates.Checkin);
        }

        /// <summary>
        /// Delete Booking
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task DeleteBooking()
        {
            //Arrange
            var response = await bookingHelper.CreateBooking(restClient);
            var newBooking = JsonConvert.DeserializeObject<BookingResponseModel>(response.Content);

            //Act
            var deleteData = await bookingHelper.DeleteBooking(restClient, newBooking.Bookingid, token);

            //Assert
            Assert.AreEqual(deleteData.StatusCode, HttpStatusCode.Created);

        }

        /// <summary>
        /// Validate Get Booking
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetBooking()
        {
            //Arrange
            var request = new RestRequest(BookEndPoints.GetBookingById(-31233))
               .AddHeader("Accept", "application/json");

            //Act
            var response = await restClient.ExecuteGetAsync<BookingModels>(request);

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
        }

    }
}