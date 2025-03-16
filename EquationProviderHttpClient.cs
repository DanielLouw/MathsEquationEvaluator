using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEquationEvaluator
{
    public class EquationProviderHttpClient : IEquationProvider, IDisposable
    {
        //Create a private HttpClient and string to store the base URL of the API.
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public EquationProviderHttpClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        /* 
         * Implement the GetEquationDataAsync method to fetch the equation data from the API using the equation ID.
         * The method should return a Task<string> containing the equation data.
         */
        public async Task<string> GetEquationDataAsync(int equationId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/equations/{equationId}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the equation data.", ex);
            }
        }

        /*
         * Implement the GetEquationIdsAsync method to fetch the equation Id's from the API and deserialize the JSON received into a list of int values.
         * The method should return a Task<List<int>> containing the equation Id's.
         */
        public async Task<List<int>> GetEquationIdsAsync()
        {
            try 
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/List");
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RecordIdsResponse>(jsonResponse)?.RecordIds ?? [];
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the equation IDs.", ex);
            }
        }

        //Create a private class to represent the JSON response containing the equation Id's.
        private class RecordIdsResponse
        {
            public List<int>? RecordIds { get; set; }
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
