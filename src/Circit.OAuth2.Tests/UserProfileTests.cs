using Circit.OAuth2.Models;

namespace Circit.OAuth2.Tests
{
    [TestClass]
    public class UserProfileTests
    {
        [TestMethod]
        public void ValidUserProfile()
        {
            var userProfile = new UserProfile
            {
                Login = "test@gmail.com"
            };

            Assert.IsTrue(userProfile.IsValid);
        }

        [TestMethod]
        public void invalidUserProfile()
        {
            var userProfile = new UserProfile();

            Assert.IsFalse(userProfile.IsValid);
        }
    }
}
