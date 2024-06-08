using System.Net;
using TechTalk.SpecFlow;
using NUnit.Framework;


namespace Product.Api.Tests.Acceptance.StepDefinitions
{
    [Binding]
    public class RetrieveAllProductsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private HttpClient _client;
        private HttpResponseMessage _response;

        public RetrieveAllProductsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _client = new HttpClient();
        }
        [Given(@"the product service is available")]
        public void GivenTheProductServiceIsAvailable()
        {
            var baseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? "http://localhost:5219/";
            _client.BaseAddress = new Uri(baseUrl);

           // Assert.True(true);
        }

        

       

        [When(@"I request to get all products")]
        public async Task WhenIRequestToGetAllProducts()
        {
            _response = await _client.GetAsync("Product/Get-All-Products");
            _scenarioContext["Response"] = _response;
        }

        [Then(@"the response should contain a list of products")]
        public async Task ThenTheResponseShouldContainAListOfProducts()
        {
            var response = _scenarioContext["Response"] as HttpResponseMessage;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var products = await response.Content.ReadAsStringAsync();
            //  Assert.AreEqual(products); // Adjust based on your actual product serialization
        }

       

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            var response = _scenarioContext["Response"] as HttpResponseMessage;
            Assert.That(response.StatusCode, Is.EqualTo((HttpStatusCode)statusCode));
        }


        [ThenAttribute(@"the response should contain Empty list")]
        public void ThenTheResponseShouldContainEmptyList()
        {
            
        }

        [GivenAttribute(@"the product service is unavailable")]
        public void GivenTheProductServiceIsUnavailable()
        {
            
        }

        [ThenAttribute(@"the response Message should be ""(.*)""")]
        public void ThenTheResponseMessageShouldBe(string p0)
        {
           
        }
    }

}
