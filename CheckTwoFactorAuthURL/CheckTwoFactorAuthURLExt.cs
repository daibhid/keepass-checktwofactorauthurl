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
        private List<Entry> data;

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

        private void MenuItem_Click(object sender, System.EventArgs e)
        {
            List<Tuple<PwEntry, Entry>> results = new List<Tuple<PwEntry, Entry>>();

            foreach (PwEntry entry in this.host.Database.RootGroup.GetEntries(true))
            {
                var matchingEntries = this.FindMatchingEntries(entry.Strings.Get(KPRes.Url).ReadString());
                if (matchingEntries.Any())
                {
                    results.Add(new Tuple<PwEntry, Entry>(entry, matchingEntries.First()));
                }
            }

            ResultsForm form = new ResultsForm();

            form.SetResults(results);
            form.ShowDialog();
        }

        public IEnumerable<Entry> FindMatchingEntries(string targetUrl)
        {
            try
            {
                Uri discard;
                //if (!Uri.TryCreate(targetUrl, UriKind.Absolute, out discard))
                //{
                //    return Enumerable.Empty<Entry>();
                //}

                return this.data.Where(entry =>
                    Uri.TryCreate(entry.URL, UriKind.Absolute, out discard) &&
                    Uri.Compare(
                        new UriBuilder(targetUrl).Uri,
                        new Uri(entry.URL),
                        UriComponents.Host,
                        UriFormat.Unescaped,
                        StringComparison.CurrentCultureIgnoreCase) == 0);
            }
            catch (Exception)
            {
                return Enumerable.Empty<Entry>();
            }
        }

        /// <summary>
        /// Retreives the data on site's two-factor methods from https://twofactorauth.org/.
        /// </summary>
        /// <returns>A parsed list of all the supported sites and their supported methods.</returns>
        public List<Entry> GetData()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string rawData;
            using (WebClient client = new WebClient())
            {
                rawData = client.DownloadString(Resources.TwoFactorURL);
            }

            var categorizedData = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Entry>>>(rawData);

            return categorizedData.SelectMany(categorizedNamedEntry => categorizedNamedEntry.Value.Select(namedEntry => { namedEntry.Value.Category = categorizedNamedEntry.Key; return namedEntry; })).Select(keyValuePair => keyValuePair.Value).ToList();
        }
    }
}
