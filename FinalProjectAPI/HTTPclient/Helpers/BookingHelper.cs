﻿using HTTPclient.DataModels;
using HTTPclient.Resources;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPclient.Helpers
{
    public class BookingHelper
    {
        public static async Task<HttpResponseMessage> PostBooking(HttpClient httpClient, BookingModels booking)
        {
            var postSerialized = JsonConvert.SerializeObject(booking);
            var request = new StringContent(postSerialized, Encoding.UTF8, "application/JSON");
            var response = await httpClient.PostAsync(Endpoints.PostBooking(), request);
            return response;
        }
        public static async Task<BookingModels> GetBookingById(HttpClient httpClient, long id)
        {
            var getResponse = await httpClient.GetAsync(Endpoints.GetBookingById(id));
            var deserializedResponse = JsonConvert.DeserializeObject<BookingModels>(getResponse.Content.ReadAsStringAsync().Result);
            return deserializedResponse;
        }
        public static async Task<HttpResponseMessage> GetBookingByInvalidId(HttpClient httpClient, long id)
        {
            var getResponse = await httpClient.GetAsync(Endpoints.GetBookingById(id));
            return getResponse;
        }
        public static async Task<HttpResponseMessage> PutBookingById(HttpClient httpClient, OrderDetail orderDetails)
        {
            var serialized = JsonConvert.SerializeObject(orderDetails.Booking);
            var request = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(Endpoints.PutBookingById(orderDetails.BookingId), request);
            return response;
        }
        public static async Task<HttpResponseMessage> DeleteBookingById(HttpClient httpClient, long id)
        {
            var response = await httpClient.DeleteAsync(Endpoints.DeleteBookingById(id));
            return response;
        }

        public static Task DeleteBookingById(RestClient restClient, long bookingid, string token)
        {
            throw new NotImplementedException();
        }
    }

    public class userReference
    {
        public static async Task<Token> AuthenticateUser(HttpClient httpClient)
        {
            UserToken user = new UserToken();
            var serialized = JsonConvert.SerializeObject(user);
            var request = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(Endpoints.AuthenticateUser(), request);

            //set retrieved pet to petRetrived variable
            var deserialized = JsonConvert.DeserializeObject<Token>(response.Content.ReadAsStringAsync().Result);

            Token token = new Token();
            token.TokenAuth = deserialized.TokenAuth;

            return token;
        }
    }
}
