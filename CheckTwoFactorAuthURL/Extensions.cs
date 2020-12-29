// <copyright file="Extensions.cs" company="daibhid">
// Copyright (c) daibhid. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CheckTwoFactorAuthURL
{
    using System;
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

        /// <summary>
        /// Returns whether a given list contains any tfa methods.
        /// </summary>
        /// <param name="input">A list of parsed tfa methods from the json.</param>
        /// <returns>True if the <see cref="IEnumerable{T}"/> is not null and not empty.</returns>
        public static bool SupportsTwoFactor(this IEnumerable<string> input)
        {
            return input != null && input.Any();
        }

        /// <summary>
        /// Returns whether a list of tfa methods contains the "phone" method.
        /// </summary>
        /// <param name="input">A list of parsed tfa methods from the json.</param>
        /// <returns>True if the <see cref="IEnumerable{T}"/> is not null and contains "phone".</returns>
        public static bool SupportsPhone(this IEnumerable<string> input)
        {
            return input != null && input.Any(s => s.Equals("phone"));
        }

        /// <summary>
        /// Returns whether a list of tfa methods contains the "sms" method.
        /// </summary>
        /// <param name="input">A list of parsed tfa methods from the json.</param>
        /// <returns>True if the <see cref="IEnumerable{T}"/> is not null and contains "sms".</returns>
        public static bool SupportsSMS(this IEnumerable<string> input)
        {
            return input != null && input.Any(s => s.Equals("sms"));
        }

        /// <summary>
        /// Returns whether a list of tfa methods contains the "hardware" method.
        /// </summary>
        /// <param name="input">A list of parsed tfa methods from the json.</param>
        /// <returns>True if the <see cref="IEnumerable{T}"/> is not null and contains "hardware".</returns>
        public static bool SupportsHardware(this IEnumerable<string> input)
        {
            return input != null && input.Any(s => s.Equals("hardware"));
        }

        /// <summary>
        /// Returns whether a list of tfa methods contains the "software" method.
        /// </summary>
        /// <param name="input">A list of parsed tfa methods from the json.</param>
        /// <returns>True if the <see cref="IEnumerable{T}"/> is not null and contains "software".</returns>
        public static bool SupportsSoftware(this IEnumerable<string> input)
        {
            return input != null && input.Any(s => s.Equals("software"));
        }
    }
}
