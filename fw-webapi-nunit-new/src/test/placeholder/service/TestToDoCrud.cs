using fw_webapi_nunit.src.automation.models.configuration;
using fw_webapi_nunit.automation.services;


namespace fw_webapi_nunit.test.placeholder.service
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