using System.Xml.Linq;
using aurora_automation.ApiTests.Models;
using Newtonsoft.Json;
using NHamcrest;
using Xunit;
using static RestAssured.Dsl;

namespace aurora_automation.ApiTests
{
    public class UITests
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

            var blogPost = new BlogPost
            {
                UserId = 1,
                Title = "My blog post title",
                Body = "This is the text of my latest blog post."
            };

            string jsonPayload = JsonConvert.SerializeObject(blogPost);

            Given()
                .Body(jsonPayload)
                .When()
                .Post("https://jsonplaceholder.typicode.com/posts")
                .StatusCode(201)
            .And()
                .Body("$.id", NHamcrest.Contains.String("101"));

        }
    }
}
