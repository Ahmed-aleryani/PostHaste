namespace PostHaste.Core
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    internal class HasteRequest : IDisposable
    {
        private readonly string baseUrl;
        private readonly HttpClient client;

        public HasteRequest(string baseUrl)
        {
            this.baseUrl = baseUrl;
            this.client = new HttpClient();
        }

        public async Task<HasteResponse> PostAsync(string content)
        {
            var httpContent = new StringContent(content);

            var response = await client.PostAsync(GetPostUrl(), httpContent,
                       CancellationToken.None);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<HasteResponse>(result);
        }

        private string GetPostUrl()
        {
            return $"{baseUrl}/documents";
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
