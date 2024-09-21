using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using NUnit.Framework;

namespace API_task_1
{
    [TestFixture]
    public class TestSuit3
    {
        private RestClient client;
        [SetUp]
        public void SetUp()
        {
            client = new RestClient("https://jsonplaceholder.typicode.com/");
        }
        [TearDown]
        public void TearDown() 
        {
            client.Dispose();
        }

        [Test]
        public async Task DeletePostbyValidID()
        { 
            var request = new RestRequest("posts/4", Method.Delete);
            var response = await client.ExecuteAsync(request);
            Assert.IsTrue(response.IsSuccessful, "Request is not valid");
        }

        [Test]
        [Category("IntegrationTest")]
        public async Task DeletePostbyNonValidID()
        {
            var request = new RestRequest("posts/0299994", Method.Delete);
            var response = await client.ExecuteAsync(request);
            Assert.AreEqual(404, (int)response.StatusCode, "Request is not valid");
        }

        [Test]
        [Retry(3)]
        public async Task DeletePostFailTest()
        {
            var request = new RestRequest("posts/1", Method.Delete);
            var response = await client.ExecuteAsync(request);
            Assert.AreEqual(422, (int)response.StatusCode, "Request is not valid");
        }
    }  
}
