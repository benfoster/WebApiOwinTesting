using Microsoft.Owin.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace WebApiOwinTesting.Tests
{
    [TestFixture(Category = "Values Controller")]
    public class ValuesControllerTests
    {
        private TestServer server;

        [OneTimeSetUp]
        public void FixtureInit()
        {
            server = TestServer.Create<Startup>();

            // Or passing configuration inline
            //server = TestServer.Create(app =>
            //{
            //    app.UseWebApi(new HttpConfiguration());
            //});
        }

        [OneTimeTearDown]
        public void FixtureDispose()
        {
            server.Dispose();
        }

        [Test]
        public void GetAll()
        {
            var response = server.HttpClient.GetAsync("/api/values").Result;
            var result = response.Content.ReadAsAsync<IEnumerable<string>>().Result;

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("hello", result.First());
            Assert.AreEqual("world", result.Last());
        }

        [Test]
        public void GetById()
        {
            var response = server.HttpClient.GetAsync("/api/values/1").Result;
            var result = response.Content.ReadAsAsync<string>().Result;

            Assert.AreEqual("hello world", result);
        }

        [Test]
        public void GetAllWithOwnHttpClient()
        {
            var client = new HttpClient(server.Handler)
            {
                BaseAddress = new Uri("http://www.example.org")
            };

            var response = client.GetAsync("/api/values").Result;
            var result = response.Content.ReadAsAsync<IEnumerable<string>>().Result;

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("hello", result.First());
            Assert.AreEqual("world", result.Last());
        }
    }
}
