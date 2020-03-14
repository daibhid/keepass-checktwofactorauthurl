// <copyright file="CheckTwoFactorAuthURLExtTests.cs" company="daibhid">
// Copyright (c) daibhid. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CheckTwoFactorAuthURL.Tests
{
    using CheckTwoFactorAuthURL;
    using NUnit.Framework;

    /// <summary>
    /// Tests the <see cref="CheckTwoFactorAuthURLExt"/> class.
    /// </summary>
    [TestFixture]
    public class CheckTwoFactorAuthURLExtTests
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

            System.Collections.Generic.List<Entry> data = plugin.GetData();

            foreach (Entry item in data)
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

                this.TestEmpty("https://this.is.not.a.real.url.com", plugin);

                this.TestNotEmpty("https://someotherdomain.google.com", plugin);

                this.TestNotEmpty("https://drive.google.com", plugin);
                this.TestNotEmpty("https://drive.google.com/", plugin);
                this.TestNotEmpty("https://drive.google.com/somesuffix", plugin);
                this.TestNotEmpty("http://drive.google.com/", plugin);

                this.TestNotEmpty("www.humblebundle.com", plugin);

                this.TestNotEmpty("www.apple.com", plugin);
            });
        }

        private void TestNotEmpty(string url, CheckTwoFactorAuthURLExt plugin)
        {
            Assert.IsNotEmpty(plugin.FindMatchingEntries(url), url);
        }

        private void TestEmpty(string url, CheckTwoFactorAuthURLExt plugin)
        {
            Assert.IsEmpty(plugin.FindMatchingEntries(url), url);
        }
    }
}