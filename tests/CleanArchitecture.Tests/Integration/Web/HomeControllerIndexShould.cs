using System.Threading.Tasks;
using Xunit;

namespace DDDGuestbook.Tests.Integration.Web
{
    public class HomeControllerIndexShould : BaseWebTest
    {
        [Fact]
        public async Task ReturnViewWithCorrectMessage()
        {
            var response = await _client.GetAsync("/home");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Contains("DDDGuestbook.Web", stringResponse);

        }
    }
}