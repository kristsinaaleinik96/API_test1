using RestSharp;
using NUnit.Framework;
namespace API_task_1

{

    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TestSuit1
        {
            private RestClient client;
            
            [SetUp]
            public void Setup()
            {
                client = new RestClient("https://jsonplaceholder.typicode.com/");
            }
            [TearDown]
            public void TearDown() 
            {
                client.Dispose();
            }

            [Test]
            public async Task GetPostbyValidID()
            {
                var requedt = new RestRequest("posts/1", Method.Get);
                var response = await client.ExecuteAsync(requedt);

                Assert.IsTrue(response.IsSuccessful, "Response is not successful");
            }

            [Test]
            public async Task GetListofPosts()
                {
                    var requedt = new RestRequest("posts", Method.Get);
                    var response = await client.ExecuteAsync(requedt);

                    Assert.IsTrue(response.IsSuccessful, "Response is not successful");
                }

            [Test]
            public async Task GetPostbyNotValidID()
            {
                var requedt = new RestRequest("posts/909909234", Method.Get);
                var response = await client.ExecuteAsync(requedt);

                Assert.IsTrue(response.IsSuccessful, "Response is not successful");
            }
    }
}