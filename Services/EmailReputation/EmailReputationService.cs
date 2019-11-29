using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CheckSpammyEmailAddresses.Services.EmailReputation
{
    public class EmailReputationService
    {
        public HttpClient Client { get; }

        public EmailReputationService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://emailrep.io/");
            
            Client = client;
        }

        public async Task<ReputationResponse> GetEmailReputation(string emailAddress)
        {
            var response = await Client.GetAsync(emailAddress);
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ReputationResponse>(responseStream);
        }
    }
}