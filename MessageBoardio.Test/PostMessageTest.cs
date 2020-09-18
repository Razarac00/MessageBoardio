using System;
using Xunit;
using MessageBoardio.MVC.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace MessageBoardio.Test
{
    public class PostMessageTest
    {

        [Fact]
        public void TestPostMessageReturnType()
        {
        // arrange
        
        // act
        
        // assert
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("a")]
        [InlineData("1")]
        [InlineData("abc")]
        [InlineData(" abc")]
        [InlineData("\n")]
        [InlineData("\t")]
        [InlineData("fox\n")]
        [InlineData("abc123")]
        [InlineData("!@#$")]
        public void TestValidNonMaliciousInput(string expected)
        {
        // arrange
        var mock = new Mock<ILogger<HomeController>>(); //forget about mocking the logger--we arent using logging anyway so remove it
        ILogger<HomeController> logger = mock.Object;

        // HomeController hc = new HomeController(mock);
        // act
        
        // assert
        // Assert.Equal(expected, );
        }
    }
}