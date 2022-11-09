using System.Net.Http.Headers;

namespace ProjectManagement.WebMvc.Helpers
{
    public class TokenSavingSessionHelper
    {
        public static HttpClient TokenSaveOnSession(HttpContext context)
        {
            HttpClient client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", context.Session.GetString("accessToken"));

            return client;
        }
    }
}
