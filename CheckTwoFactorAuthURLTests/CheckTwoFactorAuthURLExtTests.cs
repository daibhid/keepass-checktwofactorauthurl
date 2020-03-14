// <copyright file="CheckTwoFactorAuthURLExtTests.cs" company="daibhid">
// Copyright (c) daibhid. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CheckTwoFactorAuthURL.Tests
{
    using System.Linq;
    using CheckTwoFactorAuthURL;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;

    /// <summary>
    /// Tests the <see cref="CheckTwoFactorAuthURLExt"/> class.
    /// </summary>
    [TestFixture]
    public class CheckTwoFactorAuthURLExtTestsTests
    {
        /// <summary>
        /// Tests the <see cref="CheckTwoFactorAuthURLExt.Initialize(KeePass.Plugins.IPluginHost)"/> method.
        /// </summary>
        [Test]
        public void InitializeTest()
        {
            Assert.Inconclusive();
        }

        /// <summary>
        /// Tests the <see cref="CheckTwoFactorAuthURLExt.GetData"/> method.
        /// </summary>
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

        /// <summary>
        /// Tests the <see cref="CheckTwoFactorAuthURLExt.FindMatchingEntries(string)"/> method.
        /// </summary>
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