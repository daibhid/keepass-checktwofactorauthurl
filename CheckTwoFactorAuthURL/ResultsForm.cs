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
            InitializeComponent();
        }

        /// <summary>
        /// Fills the results data into the form.
        /// </summary>
        /// <param name="results">The data used to populate.</param>
        internal void SetResults(List<Tuple<PwEntry, Entry>> results)
        {
            dataGridView1.Rows.Clear();

            foreach (var item in results)
            {
                dataGridView1.Rows.Add(new object[] {
                    item.Item1.Strings.Get(KPRes.Title).ReadString(),
                    item.Item1.Strings.Get(KPRes.Url).ReadString(),
                    item.Item2.SupportsTwoFactor,
                    item.Item2.SupportsPhone,
                    item.Item2.SupportsSmS,
                    item.Item2.SupportsHardware,
                    item.Item2.SupportsSoftware,
                });
            }
        }
    }
}
