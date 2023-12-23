using test_automation_dotnet_template.automation.services;
using test_automation_dotnet_template.src.automation.config;
using test_automation_dotnet_template.src.automation.models.configuration;

namespace test_automation_dotnet_template.test.placeholder.service
{
    public class TestToDoCrud: BaseNUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRetrieveToDos()
        {
            List<ToDoDto> todos = Service.PlaceholderApi.ToDoEndpoint().GetToDos();
            Assert.That(todos.Count, Is.GreaterThan(100));
        }
    }
}