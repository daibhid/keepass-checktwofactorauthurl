namespace CheckTwoFactorAuthURL.Tests
{
    using System.Linq;
    using CheckTwoFactorAuthURL;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class CheckTwoFactorAuthURLExtTestsTests
    {
        [Test]
        public void InitializeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GetDataTest()
        {
            CheckTwoFactorAuthURLExt plugin = new CheckTwoFactorAuthURLExt();

            var data = plugin.GetData();

            foreach (var item in data)
            {
                Assert.AreNotEqual(string.Empty, item);
            }
        }

        [Test]
        public void FindMatchingEntriesTest()
        {
            CheckTwoFactorAuthURLExt plugin = new CheckTwoFactorAuthURLExt();

            plugin.Init();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(string.Empty, plugin.FindMatchingEntries("aa"));

                Assert.AreEqual(Enumerable.Empty<JToken>(), plugin.FindMatchingEntries("https://this.is.not.a.real.url.com"));

                Assert.AreNotEqual(Enumerable.Empty<JToken>(), plugin.FindMatchingEntries("https://someotherdomain.google.com"));

                Assert.AreNotEqual(Enumerable.Empty<JToken>(), plugin.FindMatchingEntries("https://drive.google.com"));
                Assert.AreNotEqual(Enumerable.Empty<JToken>(), plugin.FindMatchingEntries("https://drive.google.com/"));
                Assert.AreNotEqual(Enumerable.Empty<JToken>(), plugin.FindMatchingEntries("https://drive.google.com/somesuffix"));
                Assert.AreNotEqual(Enumerable.Empty<JToken>(), plugin.FindMatchingEntries("http://drive.google.com/"));

                Assert.AreNotEqual(Enumerable.Empty<JToken>(), plugin.FindMatchingEntries("www.humblebundle.com"));
            });
        }
    }
}