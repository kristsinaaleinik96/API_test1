using RestSharp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_task_1
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    [NonParallelizable]
    internal class TestSuit2
    {
        private RestClient client;

        [SetUp]
        public void Setup()
        { 
            client = new RestClient("https://jsonplaceholder.typicode.com/");
        }

        [TearDown]
        public void Teardown() 
        {
            client.Dispose();
        }

        [Test]
        public async Task CreatePostwithValidData() 
        {
            var request = new RestRequest("posts", Method.Post);
            request.AddJsonBody(new { title = "new title", body = "new body", userId = 4 });
            var response = await client.ExecuteAsync(request);
            Assert.AreEqual(201, (int)response.StatusCode, "201 status code should be returned");
        }

        [Test]
        public async Task CreatePostwithNonValidData()
        {
            var request = new RestRequest("posts", Method.Post);
            request.AddJsonBody(new { title = "0", body = "0", userId = -474 });
            var response = await client.ExecuteAsync(request);
            Assert.AreEqual(201, (int)response.StatusCode, "201 status code should be returned");
        }
    }
}
