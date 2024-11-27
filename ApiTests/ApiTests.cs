//using Microsoft.AspNetCore.Routing;
using System.Xml.Linq;
using NHamcrest;
using Xunit;
using static RestAssured.Dsl;

namespace aurora_automation.ApiTests
{
    public class ApiTests
    {
       // Parameterized test method using xUnit's [Theory] and [InlineData]
        [Theory]
        [InlineData(1, "Leanne Graham", "harness real-time e-markets")]
        [InlineData(2, "Ervin Howell", "synergize scalable supply-chains")]
        [InlineData(3, "Clementine Bauch", "e-enable strategic applications")]
        public void StatusCodeIndicatingSuccessCanBeVerifiedAsInteger(int userId, string expectedName, string expectedBs)
        {
            var url = $"https://jsonplaceholder.typicode.com/users/{userId}";

            var response = Given().Get(url);
            Console.WriteLine(response);

            Given()
                .When()
                .Get(url)
                .Then()
                .StatusCode(200)
                .And()
                .ContentType("application/json; charset=utf-8")
                .And()
                .Body("$.name", Contains.String(expectedName))
                .And()
                .Body("$.company.bs", Contains.String(expectedBs));
        }


        [Fact]
        public void PostABlog()
        {
            Given()
                .Body("{\"userId\": 1, \"title\": \"My blog post title\", \"body\": \"This is the text of my latest blog post.\" }")
                .When()
                .Post("https://jsonplaceholder.typicode.com/posts")
                .StatusCode(201)
            .And()
                .Body("$.id", NHamcrest.Contains.String("101"));

        }
    }
}
