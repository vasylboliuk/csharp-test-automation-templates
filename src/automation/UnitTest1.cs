using RestSharp;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace test_automation_dotnet_template.src.automation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // send GET request with RestSharp
            var client = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("todos/1");
            var response = client.ExecuteGet(request);

            // deserialize json string response to JsonNode object
            var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;

            // output result
            Console.WriteLine($"""
                ----------------
                json properties
                ----------------
                id: {data["id"]}
                name: {data["name"]}

                ----------------
                raw json data
                ----------------
                {data}
                """);
            Assert.Pass();
        }
    }
}