using NUnit.Framework;
using Nancy.Testing;

namespace Test
{
    [TestFixture]
    public class Tester
    {
        [Test]
        public void ExposeTheBug()
        {
            var b = new Browser(c => { });
            var response = b.Get("/");
            var str = response.Body.AsString();
            Assert.AreNotEqual("foo", str);
        }
    }
}
