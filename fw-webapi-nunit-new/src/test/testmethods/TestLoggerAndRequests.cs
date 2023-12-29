using RestSharp;
using Serilog;
using System.Text.Json;
using System.Text.Json.Nodes;
using fw_webapi_nunit.src.automation.utils;

namespace fw_webapi_nunit.test.testmethods
{
    public class TestLoggerAndRequests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRequestRestSharp()
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

        [Test]
        public void TestLoggerSerilog()
        {
            var customLogger = LogManager.GetInstance().SomeInt();
            Console.WriteLine(customLogger);

            LogManager.GetInstance().GetLogger();


            var car1 = new CarDto("Tesla Model S", 2020);
            var car2 = new CarDto("Tesla Model X", 2020);
            // logging
            Log.Verbose("Some verbose log");
            Log.Debug("Some debug log");
            Log.Information("Person1: {@person}");
            Log.Information("Car2: {@car}", car2);
            Log.Warning("Warning accrued at {now}", DateTime.Now);
            Log.Error("Error accrued at {now}", DateTime.Now);
            Log.Fatal("Problem with car {@car} accrued at {now}", car1, DateTime.Now);
        }
    }
}