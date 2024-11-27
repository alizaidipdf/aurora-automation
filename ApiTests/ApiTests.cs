//using Microsoft.AspNetCore.Routing;
using System.Xml.Linq;
using NHamcrest;
using Xunit;
using static RestAssured.Dsl;

namespace aurora_automation.ApiTests
{
    public class ApiTests
    {        
        [Fact]
        public void StatusCodeIndicatingSuccessCanBeVerifiedAsInteger()
        {
            var response = Given().Get("https://jsonplaceholder.typicode.com/users/1");
            Console.WriteLine(response);

            Given()
            .When()
            .Get("https://jsonplaceholder.typicode.com/users/1")
            .Then()
            .StatusCode(200)
            .And()
            .ContentType("application/json; charset=utf-8")
            .And()
            .Header("Connection", "keep-alive")
            .And()
            .Body("$.name", NHamcrest.Contains.String("Leanne Graham"))
            .And()
            .Body("$.company.bs", NHamcrest.Contains.String("harness real-time e-markets"));
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
