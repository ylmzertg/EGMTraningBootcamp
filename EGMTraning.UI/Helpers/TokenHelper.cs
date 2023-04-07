using EGMTraning.Common.Dtos;

namespace EGMTraning.UI.Helpers
{
    public class TokenHelper
    {
        private readonly HttpClient _httpClient;

        public TokenHelper(HttpClient httpClient)
        {
            _httpClient=httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7002/");
        }

        public async Task<AccessToken> AuthenticateAsync()
        {
            var token = RetrieveCachedToken();
            if (!string.IsNullOrWhiteSpace(token))
                return new() { Token = token };

            var result = await _httpClient.PostAsync("/api/Login/login", GenerateBody());

            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadAsStringAsync();

            var deserializedToken = DeserializeResponse<CustomResponseDto<AccessToken>>(response);
            if (deserializedToken.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                //yonlendırme yap. Yetkısız gırıs sayfasına
            }
            SetCacheToken(deserializedToken.Data);

            return deserializedToken.Data;
        }

        private StringContent GenerateBody()
        {
            var email = "ylmzertg@gmail.com";
            var password = "123456";

            var body = JsonSerializer.Serialize(new { email, password },
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return new StringContent(body, Encoding.UTF8, "application/json");
        }

        private void SetCacheToken(AccessToken deserializedToken)
        {
            //In a real-world application we should store the token in a cache service and set an TTL.(Session or cache)
            Environment.SetEnvironmentVariable("token", deserializedToken.Token);
        }

        private string RetrieveCachedToken()
        {
            //In a real-world application, we should retrieve the token from a cache service.(Session or cache)
            return Environment.GetEnvironmentVariable("token");
        }

        public T DeserializeResponse<T>(string response)
        {
            return JsonSerializer.Deserialize<T>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

    }
}
