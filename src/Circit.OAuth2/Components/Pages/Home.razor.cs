using Microsoft.AspNetCore.Components;

namespace Circit.OAuth2.Components.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IConfiguration Configuration { get; set; }

        public async Task Login()
        {
            var authorizeUri = Configuration["GitHub:AuthorizationUri"];
            var clientId = Configuration["GitHub:ClientId"];
            var redirectUri = Configuration["GitHub:RedirectUri"];

            NavigationManager.NavigateTo($"{authorizeUri}?client_id={clientId}&redirect_uri={redirectUri}");
        }
    }
}
