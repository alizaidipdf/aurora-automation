using Microsoft.AspNetCore.Routing;
using Xunit;
using static RestAssured.Dsl;

namespace aurora_automation.UnitTests
{
    public class UnitTests
    {
        [Fact]
        public void addTwoPlusTwo()
        {
            int a = 2;
            int b = 2;
            int c = a + b;
            Assert.Equal(c, 4);

        }
        [Fact]
        public void addThreePlusFive()
        {
            int a = 3;
            int b = 5;
            int c = a + b;
            Assert.Equal(c, 7);

        }

    }
}
