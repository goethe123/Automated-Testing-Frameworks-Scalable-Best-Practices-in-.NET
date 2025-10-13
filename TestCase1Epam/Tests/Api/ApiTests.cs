using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase1Epam.Business.Builders;
using TestCase1Epam.Business.Models;
using TestCase1Epam.Core.API;

namespace TestCase1Epam.Tests.Api
{
    [TestFixture]
    [Category("Api")]
    [Parallelizable(ParallelScope.All)]
    public class ApiTests
    {
        private BaseApiClient _client;
        [SetUp]
        public void Setup()
        {
            _client = new BaseApiClient("https://jsonplaceholder.typicode.com");
        }

        [Test]
        public async Task ValidateUserListCanBeRecieved()
        {
            var request = new UserRequestBuilder("/users", RestSharp.Method.Get).Build();
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            var users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content);
            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.GreaterThan(0));
        }

        [Test]
        public async  Task ValidateResponseHeader()
        {
            var request = new UserRequestBuilder("/users", RestSharp.Method.Get).Build();
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.ContentType, Is.Not.Null.Or.Empty);
            Assert.That(response.ContentType, Does.Contain("application/json"));
        }

        [Test]
        public async Task ValidateUsersArrayIntegrity()
        {
            var request = new UserRequestBuilder("/users", RestSharp.Method.Get).Build();
            var response = await _client.ExecuteAsync(request);
            var users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content);

            Assert.That(users.Count,Is.EqualTo(10));
            Assert.That(users.Select(u=>u.Id).Distinct().Count(), Is.EqualTo(10));
            Assert.That(users.All(u=> !string.IsNullOrEmpty(u.Name) && !string.IsNullOrEmpty(u.UserName)));
            Assert.That(users.All(u => u.Company != null & !string.IsNullOrEmpty(u.Company.Name)));
        }

        [Test]
        public async Task ValidateUserCanBeCreated()
        {
            var newUser = new { name = "Goethe", Username = "goet" };
            var request = new UserRequestBuilder("/users", RestSharp.Method.Post).WithJsonBody(newUser).Build(); ;
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
            Assert.That(response.Content, Does.Contain("id"));

        }

        [Test]
        public async Task ValidateRsourceNotFound()
        {
            var request = new UserRequestBuilder("/invalidendpoint", RestSharp.Method.Get).Build();
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode,Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }
    }
}
