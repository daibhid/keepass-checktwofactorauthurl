// <copyright file="ExtensionsTests.cs" company="daibhid">
// Copyright (c) daibhid. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CheckTwoFactorAuthURL.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Tests the <see cref="Extensions"/> class.
    /// </summary>
    [TestFixture]
    public class ExtensionsTests
    {
        /// <summary>
        /// Test the <see cref="CheckTwoFactorAuthURL.Extensions.GetAllSubdomains(string)"/> method.
        /// </summary>
        [Test]
        public void GetAllSubdomainsTest()
        {
            CollectionAssert.AreEquivalent(new[] { "www.drive.google.com", "drive.google.com", "google.com", "com" }, "www.drive.google.com".GetAllSubdomains());
        }
    }
}