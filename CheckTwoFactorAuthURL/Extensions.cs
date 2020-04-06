// <copyright file="Extensions.cs" company="daibhid">
// Copyright (c) daibhid. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CheckTwoFactorAuthURL
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Returns a list of possible subdomains from a URL.
        /// </summary>
        /// <param name="input">A url to be tokenised, then recreated with all of its possibilities.</param>
        /// <returns>A list of all possible grouping of the input string after splitting then joining.</returns>
        public static IEnumerable<string> GetAllSubdomains(this string input)
        {
            string[] subdomainParts = input.Split('.');

            for (int i = 0; i < subdomainParts.Length; i++)
            {
                yield return string.Join(".", subdomainParts.Skip(i));
            }
        }
    }
}
