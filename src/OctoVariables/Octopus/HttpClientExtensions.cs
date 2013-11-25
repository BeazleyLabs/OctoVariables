using System.Net.Http;

namespace OctoVariables.Octopus
{
    public static class HttpClientExtensions
    {

        public static TResource GetResource<TResource>(this HttpClient client, string requestUri)
        {
            var response = client.GetAsync(requestUri).Result;
            return response.Content.ReadAsAsync<TResource>().Result;
        }


    }
}