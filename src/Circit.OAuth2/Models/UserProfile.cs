using System.Text.Json.Serialization;

namespace Circit.OAuth2.Models
{
    public class UserProfile
    {
        public string? Login { get; set; }
        public string? Name { get; set; }
        public string? Avatar_Url { get; set; }
        public string? Bio { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; }
        public string? Company { get; set; }
        public string? Twitter_Username { get; set; }
        public string? Gists_Url { get; set; }
        public string? Repos_Url { get; set; }
        public string? Html_Url { get; set; }
        public int Public_Repos { get; set; }
        public int Public_Gists { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public DateTime Created_At { get; set; }

        [JsonIgnore]
        public bool IsValid => !string.IsNullOrEmpty(Login);
    }
}
