using RestSharpProject.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharpProject.DataModels;
using RestSharp;
using RestSharpProject.Test.TestData;


namespace RestSharpProject
{
    public class BookHelper
    {
        public async Task<RestResponse> CreateBooking(RestClient client)
        {
            var bookingData = GenerateBookData.BookingDetails();
            var postRequest = new RestRequest(BookEndPoints.PostBooking())
                .AddJsonBody(bookingData)
                .AddHeader("Accept", "application/json");

            var response = await client.ExecutePostAsync(postRequest);

            return response;

        }

        public async Task<BookingModels> GetBookingById(RestClient client, long id)
        {

            var request = new RestRequest(BookEndPoints.GetBookingById(id))
                .AddHeader("Accept", "application/json");
            var response = await client.ExecuteGetAsync<BookingModels>(request);


            return response.Data;

        }

        public async Task<RestResponse> UpdateBookingById(RestClient client, long id, BookingModels updatedBooking, string token)
        {

            var request = new RestRequest(BookEndPoints.PutBookingById(id))
                .AddJsonBody(updatedBooking)
                .AddHeader("Accept", "application/json")
                .AddHeader("Cookie", $"token={token}");
            var response = await client.ExecutePutAsync<BookingModels>(request);

            return response;


        }

        public async Task<RestResponse> DeleteBooking(RestClient client, long id, string token)
        {

            var postRequest = new RestRequest(BookEndPoints.DeleteBookingById(id))
                .AddHeader("Accept", "application/json")
                .AddHeader("Cookie", $"token={token}");

            var response = await client.DeleteAsync(postRequest);

            return response;

        }

        public async Task<string> GetToken(RestClient client)

        {
            var loginData = GenerateToken.newToken();
            var request = new RestRequest(BookEndPoints.AuthenticateUser())
                .AddJsonBody(loginData)
                .AddHeader("Accept", "application/json");

            var response = await client.ExecutePostAsync(request);
            var content = JsonConvert.DeserializeObject<Token>(response.Content);

            return content.TokenAuth;

        }

    }
}




