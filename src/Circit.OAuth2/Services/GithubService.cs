using Circit.OAuth2.Models;
using System.Net.Http.Headers;

namespace Circit.OAuth2.Services
{
    public class GithubService(HttpClient httpClient, IConfiguration configuration, ILogger<UserProfileService> logger)
    {
        public async Task<AccessToken> GetAccessToken(string code)
        {
            try
            {
                var clientId = configuration["GitHub:ClientId"];
                var clientSecret = configuration["GitHub:ClientSecret"];
                var accessTokenUri = configuration["GitHub:AccessTokenUri"];
                var redirectUri = configuration["GitHub:RedirectUri"];

                var fullAccessTokenUri = $"{accessTokenUri}?client_id={clientId}&client_secret={clientSecret}&code={code}&redirect_uri={redirectUri}";

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                var response = await httpClient.PostAsync(fullAccessTokenUri, new StringContent(string.Empty));

                response.EnsureSuccessStatusCode();

                var accessToken = await response.Content.ReadFromJsonAsync<AccessToken>();

                return accessToken;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }          
        }

        public async Task<UserProfile> GetProfile(string accessToken)
        {
            try
            {
                var userUri = configuration["GitHub:UserUri"];

                httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Circit.OAuth2", "1"));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient.GetAsync(userUri);
                response.EnsureSuccessStatusCode();

                var userProfile = await response.Content.ReadFromJsonAsync<UserProfile>();

                return userProfile;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
