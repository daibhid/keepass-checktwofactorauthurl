// <copyright file="ResultsForm.cs" company="daibhid">
// Copyright (c) daibhid. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CheckTwoFactorAuthURL
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using KeePass.Resources;
    using KeePassLib;

    /// <summary>
    /// The UI form for displaying results.
    /// </summary>
    public partial class ResultsForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultsForm"/> class.
        /// </summary>
        public ResultsForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Fills the results data into the form.
        /// </summary>
        /// <param name="results">The data used to populate.</param>
        internal void SetResults(List<Tuple<PwEntry, TwoFactorSite>> results)
        {
            this.dataGridView1.Rows.Clear();

            foreach (Tuple<PwEntry, TwoFactorSite> item in results)
            {
                this.dataGridView1.Rows.Add(new object[]
                {
                    item.Item1.Strings.Get(KPRes.Title).ReadString(),
                    item.Item1.Strings.Get(KPRes.Url).ReadString(),
                    item.Item2.URL,
                    item.Item2.Methods.SupportsTwoFactor(),
                    item.Item2.Methods.SupportsPhone(),
                    item.Item2.Methods.SupportsSMS(),
                    item.Item2.Methods.SupportsHardware(),
                    item.Item2.Methods.SupportsSoftware(),
                });
            }
        }
    }
}
