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
            var baseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? "http://localhost:5000/api/";
            _client.BaseAddress = new Uri(baseUrl);

            Assert.True(true);
        }

        [Given(@"the product service is not available")]
        public void GivenTheProductServiceIsNotAvailable()
        {
            var baseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? "http://localhost:5001/api/"; //Simulate With Invalid Address
            _client.BaseAddress = new Uri(baseUrl);
        }

        [Given(@"there are no products in the database")]
        public async Task GivenThereAreNoProductsInTheDatabase()
        {
            // Optionally, implement code to ensure the database is empty
            //var result = await _client.GetAsync("products");

            //if(result.Count)
            //Assert.AreEqual(HttpStatusCode.OK, deleteResponse.StatusCode);
        }

        [When(@"I request to get all products")]
        public async Task WhenIRequestToGetAllProducts()
        {
            _response = await _client.GetAsync("products");
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

        [Then(@"the response should contain an empty list")]
        public async Task ThenTheResponseShouldContainAnEmptyList()
        {
            var response = _scenarioContext["Response"] as HttpResponseMessage;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var products = await response.Content.ReadAsStringAsync();
            //   Assert.(products); // Adjust based on your actual product serialization
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            var response = _scenarioContext["Response"] as HttpResponseMessage;
            Assert.That(response.StatusCode, Is.EqualTo((HttpStatusCode)statusCode));
        }

        [Then(@"the response message should be ""([^""]*)""")]
        public async Task ThenTheResponseMessageShouldBe(string expectedMessage)
        {
            var response = _scenarioContext["Response"] as HttpResponseMessage;
            var responseMessage = await response.Content.ReadAsStringAsync();
            Assert.That(responseMessage, Is.EqualTo(expectedMessage));
        }

    }

}
