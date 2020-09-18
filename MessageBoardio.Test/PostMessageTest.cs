using System;
using Xunit;
using MessageBoardio.MVC.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace MessageBoardio.Test
{
    public class PostMessageTest
    {

        [Fact]
        public void TestPostMessageReturnType()
        {
        // arrange
        HomeController hc = new HomeController();
        // IActionResult expected = new IActionResult();

        // act
        var actual = hc.PostMessage(" ").GetType();
        
        // assert
        // Assert.IsInstanceOfType(typeof(RedirectToRouteResult), actual);
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
        HomeController hc = new HomeController();

        // act
        hc.PostMessage(expected);
        var actual = hc.getMessagesRaw();
        // assert
        Assert.True(actual.Contains(expected));
        }
    }
}