namespace CheckTwoFactorAuthURL
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using KeePass.Resources;
    using KeePassLib;

    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }

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
