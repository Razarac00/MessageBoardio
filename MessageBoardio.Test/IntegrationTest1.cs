using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using MessageBoardio.MVC;
using System.Net.Http;
using System.Net;

namespace MessageBoardio.Test
{
    public class ServerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ServerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void StorePostAndGetByMsg()
        {
            // arrange
            string expected = "Test";
            // string address = "a";
            // string jsonToPost = JsonSerializer.Serialize(new GroceryStore { Name = name, Address = address });
            var contentToPost = new StringContent(expected); //provide this as proper form data key and value pairs
            HttpClient client = _factory.CreateClient();

            // act: post a store
            HttpResponseMessage postResponse = await client.PostAsync("/home/index", contentToPost);

            // assert
            Assert.Equal(HttpStatusCode.OK, postResponse.StatusCode);
            // Uri storeLocation = postResponse.Headers.Location;
            // Assert.NotNull(storeLocation);
            // GroceryStore postStore = await Utilities.AssertResponseBodyWellFormedJsonAsync<GroceryStore>(postResponse);
            // Assert.Equal(name, postStore.Name);
            // Assert.Equal(address, postStore.Address);

            var responseString = await postResponse.Content.ReadAsStringAsync();
            Assert.Contains(expected, responseString);//responseString);

            // arrange: get the message back
            // var response = await client.GetAsync("/home/index");
            // act
            // response.EnsureSuccessStatusCode();
            // var responseString = await response.Content.ReadAsStringAsync();

            // assert

            // Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            // GroceryStore getStore = await Utilities.AssertResponseBodyWellFormedJsonAsync<GroceryStore>(getResponse);
            // Assert.Equal(name, getStore.Name);
            // Assert.Equal(address, getStore.Address);
        }
    }
}
