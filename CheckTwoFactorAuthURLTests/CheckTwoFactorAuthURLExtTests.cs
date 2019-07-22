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
            CheckTwoFactorAuthURLExt class1 = new CheckTwoFactorAuthURLExt();

            foreach (var item in class1.GetData())
            {
                Assert.AreNotEqual(string.Empty, item);
            }
        }

        [Test]
        public void FindMatchingEntriesTest()
        {
            CheckTwoFactorAuthURLExt class1 = new CheckTwoFactorAuthURLExt();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(string.Empty, class1.FindMatchingEntries("aa"));

                Assert.AreEqual(Enumerable.Empty<JToken>(), class1.FindMatchingEntries("https://this.is.not.a.real.url.com"));

                Assert.AreNotEqual(Enumerable.Empty<JToken>(), class1.FindMatchingEntries("https://drive.google.com"));
                Assert.AreNotEqual(Enumerable.Empty<JToken>(), class1.FindMatchingEntries("https://drive.google.com/"));
                Assert.AreNotEqual(Enumerable.Empty<JToken>(), class1.FindMatchingEntries("https://drive.google.com/somesuffix"));
                Assert.AreNotEqual(Enumerable.Empty<JToken>(), class1.FindMatchingEntries("http://drive.google.com/"));
            });
        }
    }
}