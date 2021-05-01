// <copyright file="CheckTwoFactorAuthURLExt.cs" company="daibhid">
// Copyright (c) daibhid. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CheckTwoFactorAuthURL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows.Forms;
    using CheckTwoFactorAuthURL.Properties;
    using KeePass.Plugins;
    using KeePass.Resources;
    using KeePassLib;
    using Newtonsoft.Json;

    /// <summary>
    /// The main class for the plugin.
    /// </summary>
    public class CheckTwoFactorAuthURLExt : Plugin
    {
        private IPluginHost host;
        private List<TwoFactorSite> data;

        /// <summary>
        /// Method call to initialize the data for testing purposes.
        /// </summary>
        public void Init()
        {
            this.data = this.GetData();
        }

        /// <inheritdoc/>
        public override bool Initialize(IPluginHost host)
        {
            this.host = host;

            this.data = this.GetData();

            ToolStripItemCollection tsMenu = this.host.MainWindow.ToolsMenu.DropDownItems;

            ToolStripSeparator separator = new ToolStripSeparator();
            tsMenu.Add(separator);

            ToolStripMenuItem menuItem = new ToolStripMenuItem
            {
                Text = "Two-&factor search",
            };

            menuItem.Click += this.MenuItem_Click;
            tsMenu.Add(menuItem);

            return base.Initialize(host);
        }

        /// <summary>
        /// Gets any entries in the list of sites that match the given URL.
        /// </summary>
        /// <param name="targetUrl">The search URL.</param>
        /// <returns>A list of <see cref="TwoFactorSite"/>s that have some of this url.</returns>
        public IEnumerable<TwoFactorSite> FindMatchingEntries(string targetUrl)
        {
            try
            {
                Uri targetUri = new UriBuilder(targetUrl).Uri;

                return this.data.Where(twoFactorSource =>
                {
                    Uri twoFactorSupportedUrl = new UriBuilder(twoFactorSource.URL).Uri;

                    //// We need to split targetUri.Host into each subdomain, then test that against twoFactorSupportedUrl.Host without the "www." prefix.

                    return targetUri.Host.GetAllSubdomains().Any(subdomain => string.Compare(twoFactorSupportedUrl.Host.Replace("www.", string.Empty), subdomain, true) == 0);
                });
            }
            catch (Exception)
            {
                return Enumerable.Empty<TwoFactorSite>();
            }
        }

        /// <summary>
        /// Retreives the data on site's two-factor methods from https://twofactorauth.org/.
        /// </summary>
        /// <returns>A parsed list of all the supported sites and their supported methods.</returns>
        public List<TwoFactorSite> GetData()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string rawData;
            using (WebClient client = new WebClient())
            {
                rawData = client.DownloadString(Resources.TwoFactorURL);
            }

            Dictionary<string, Dictionary<string, TwoFactorSite>> categorizedData = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, TwoFactorSite>>>(rawData);

            return categorizedData.SelectMany(categorizedNamedEntry => categorizedNamedEntry.Value.Select(namedEntry =>
            {
                namedEntry.Value.Category = categorizedNamedEntry.Key;
                return namedEntry;
            })).Select(keyValuePair => keyValuePair.Value).ToList();
        }

        private void MenuItem_Click(object sender, System.EventArgs e)
        {
            List<Tuple<PwEntry, TwoFactorSite>> results = new List<Tuple<PwEntry, TwoFactorSite>>();

            foreach (PwEntry entry in this.host.Database.RootGroup.GetEntries(true))
            {
                IEnumerable<TwoFactorSite> matchingEntries = this.FindMatchingEntries(entry.Strings.Get(KPRes.Url).ReadString());
                if (matchingEntries.Any())
                {
                    results.Add(new Tuple<PwEntry, TwoFactorSite>(entry, matchingEntries.First()));
                }
                else
                {
                    results.Add(new Tuple<PwEntry, TwoFactorSite>(entry, new TwoFactorSite()));
                }
            }

            results.Sort((left, right) => left.Item1.Strings.Get(KPRes.Title).ReadString().CompareTo(right.Item1.Strings.Get(KPRes.Title).ReadString()));

            ResultsForm form = new ResultsForm();

            form.SetResults(results);
            form.Show();
        }
    }
}
