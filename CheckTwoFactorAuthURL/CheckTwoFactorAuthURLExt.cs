// <copyright file="Class1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CheckTwoFactorAuthURL
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Windows.Forms;
    using CheckTwoFactorAuthURL.Properties;
    using KeePass.Plugins;
    using KeePass.Resources;
    using KeePassLib;
    using Newtonsoft.Json.Linq;

    public class CheckTwoFactorAuthURLExt : Plugin
    {
        private IPluginHost host;
        private List<JToken> data;

        public override bool Initialize(IPluginHost host)
        {
            this.host = host;

            //System.Diagnostics.Debugger.Launch();

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
            List<PwEntry> results = new List<PwEntry>();

            foreach (PwEntry entry in this.host.Database.RootGroup.GetEntries(true))
            {
                if (this.FindMatchingEntries(entry.Strings.Get(KPRes.Url).ReadString()).Any())
                {
                    results.Add(entry);
                }
            }

            ResultsForm form = new ResultsForm();

            form.SetResults(results);
            form.ShowDialog();
        }

        public IEnumerable<JToken> FindMatchingEntries(string targetUrl)
        {
            Uri discard;
            if (!Uri.TryCreate(targetUrl, UriKind.Absolute, out discard))
            {
                return Enumerable.Empty<JToken>();
            }

            return this.data.Where(entry =>
                Uri.TryCreate(entry.First["url"].ToString(), UriKind.Absolute, out discard) &&
                Uri.Compare(
                    new Uri(targetUrl),
                    new Uri(entry.First["url"].ToString()),
                    UriComponents.Host,
                    UriFormat.Unescaped,
                    StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public List<JToken> GetData()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string rawData;
            using (var client = new WebClient())
            {
                rawData = client.DownloadString(Resources.TwoFactorURL);
            }

            return JObject.Parse(rawData).Root.SelectMany(item => item.Values()).ToList();
        }
    }
}
