using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace SOFT549_ASD_MIS_DemoWebApp.Models
{
    public partial class GilesContext
    {

        #region Variables

        // Variables specified and used in the functions below.

        private HttpClient _httpClient;
        private Uri _apiBaseURL;                    //API URL found below in base(options)
        public bool authenticated {private set; get;}

        #endregion

        #region Constructors

        public GilesContext()
        {
            _httpClient = new HttpClient();
            _apiBaseURL = new Uri("https://localhost:44318/api/");       //Change API URL when API is uploaded to server or when port changes.
            authenticated = false;                                       //Sets authentication to false at start of running program.
        }

        public void Login()
        {
            authenticated = true;
        }

        public void Logout()
        {
            authenticated = false;
        }

        #endregion

        #region API Methods

        // CreateRequestUri method 

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endPoint = new Uri(_apiBaseURL, relativePath);
            var uriBuilder = new UriBuilder(endPoint);

            uriBuilder.Query = queryString;

            return uriBuilder.Uri;
        }


        //

        private HttpContent CreateHttpContent<T>(T model)
        {
            var json = JsonConvert.SerializeObject(model, MicrosoftDateFormatSettings);
            //return new StringContent(json, Encoding.UTF8, "application/json");
            var bob = new StringContent(json, Encoding.UTF8, "application/json");
            return bob;
        }


        // A method to add headers for security/validation.

        private void AddHeaders()
        {
            //_httpClient.DefaultRequestHeaders.Remove("apiKey");
            //_httpClient.DefaultRequestHeaders.Add("apiKey", "gobbledygook!");
        }


        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }


        // Function to build a string that will call API.

        private Uri StartApiCall(string apiCommand)
        {
            Uri requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, apiCommand));

            AddHeaders();

            return requestUrl;
        }


        // Function to receive information from database through API.

        public async Task<T> GetApiCall<T>(string apiCommand)
        {
            Uri requestUrl = StartApiCall(apiCommand);


            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var responseModel = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseModel);
        }


        // Function to post information to database through API.

        public async Task<T> PostApiCall<T>(string apiCommand, T model)
        {
            Uri requestUrl = StartApiCall(apiCommand);

            var response = await _httpClient.PostAsync(requestUrl, CreateHttpContent<T>(model));
            response.EnsureSuccessStatusCode();

            var responseModel = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseModel);
        }


        // Function to edit data in database through API.

        public async Task<T> PutApiCall<T>(string apiCommand, T model)
        {
            Uri requestUrl = StartApiCall(apiCommand);

            var response = await _httpClient.PutAsync(requestUrl, CreateHttpContent<T>(model));
            response.EnsureSuccessStatusCode();

            var responseModel = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseModel);
        }


        // Function to delete data in database through API.

        public async Task<T> DeleteApiCall<T>(string apiCommand)
        {
            Uri requestUrl = StartApiCall(apiCommand);

            var response = await _httpClient.DeleteAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var responseModel = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseModel);
        }

        #endregion

    }
}
