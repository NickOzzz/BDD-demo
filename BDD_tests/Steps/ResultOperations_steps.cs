using BDD_tests.Drivers;
using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BDD_tests.Steps
{
    [Binding]
    public class ResultOperations_steps
    {
        private static HttpResponseMessage result;
        private static HttpRequestMessage request;
        private static ClientConstruction construct = new ClientConstruction();

        [BeforeFeature, Scope(Feature = "Result Operations")]
        public static void BeforeScenarioMain()
        {
             
        }

        [When(@"Result validation of name is requested for ""(.*)""")]
        public static async Task WhenResultValidationRequested(string user) 
        {
            request = new HttpRequestMessage(HttpMethod.Post, $"/api/Results/post-result/{user}");
            request.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            result = await construct.SendRequest(request);
        }

        [Then("Result is validated successfully and returned")]
        public static void ThenResultIsValidated() => result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
