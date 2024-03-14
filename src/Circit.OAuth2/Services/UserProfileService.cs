using Circit.OAuth2.Models;
using System.Text.Json;

namespace Circit.OAuth2.Services
{
    public class UserProfileService(GithubService githubService, ILogger<UserProfileService> logger)
    {
        public UserProfile? UserProfile { get; set; } = new UserProfile();

        public string UserProfileToJson => JsonSerializer.Serialize(UserProfile, new JsonSerializerOptions { WriteIndented = true });

        public async Task LoadUserProfile(string code)
        {
            try
            {
                var accessToken = await githubService.GetAccessToken(code);
                UserProfile = await githubService.GetProfile(accessToken.Access_Token);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
