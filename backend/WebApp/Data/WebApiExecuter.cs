using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApp.Data
{
    public class WebApiExecuter : IWebApiExecuter
    {
        private const string apiName = "ShirtsApi";
        private readonly IHttpClientFactory httpClientFactory;

        public WebApiExecuter(IHttpClientFactory httpClientFactory)

        {
            this.httpClientFactory = httpClientFactory;
        }

        
            public async Task<T?> InvokeGet<T>(string relativeUrl)
        {
            try
            {
                var httpClient = httpClientFactory.CreateClient(apiName);
                return await httpClient.GetFromJsonAsync<T>(relativeUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }


        public async Task<T?> InvokePost<T>(string relativeUrl,T obj)
        {
            var httpclient = httpClientFactory.CreateClient(apiName);
            var response = await httpclient.PostAsJsonAsync(relativeUrl,obj);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();

        }



    }
}

