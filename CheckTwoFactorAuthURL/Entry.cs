// <copyright file="Entry.cs" company="daibhid">
// Copyright (c) daibhid. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CheckTwoFactorAuthURL
{
    using System.Drawing;
    using Newtonsoft.Json;

    /// <summary>
    /// Class storing the 2-factor data about a site.
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// Gets or sets the url for the site.
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// Gets or sets the name of the site.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this site supports any 2-factor method.
        /// </summary>
        [JsonProperty("tfa")]
        public bool SupportsTwoFactor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the site supports 2-factor over SMS.
        /// </summary>
        [JsonProperty("sms")]
        public bool SupportsSMS { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the site supports 2-factor over phone.
        /// </summary>
        [JsonProperty("phone")]
        public bool SupportsPhone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the site supports 2-factor with software key.
        /// </summary>
        [JsonProperty("software")]
        public bool SupportsSoftware { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the site supports 2-factor with a hardware key.
        /// </summary>
        [JsonProperty("hardware")]
        public bool SupportsHardware { get; set; }

        /// <summary>
        /// Gets or sets the site's icon.
        /// </summary>
        [JsonProperty("icon")]
        public Icon Icon { get; set; }

        /// <summary>
        /// Gets or sets the category this site.
        /// </summary>
        public string Category { get; set; }
    }
}
