using Circit.OAuth2.Services;
using Microsoft.AspNetCore.Components;

namespace Circit.OAuth2.Components.Pages
{
    public partial class Profile : ComponentBase
    {
        [Inject] 
        UserProfileService UserProfileService { get; set; }

        [SupplyParameterFromQuery]
        private string? Code { get; set; }

        private string Error { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!UserProfileService.UserProfile.IsValid)
            {
                try
                {
                    await UserProfileService.LoadUserProfile(Code);
                }
                catch
                {
                    Error = "Could not load user profile";
                }           
            }

            await base.OnInitializedAsync();
        }
    }
}
