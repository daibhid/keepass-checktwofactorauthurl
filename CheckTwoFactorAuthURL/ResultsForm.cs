namespace CheckTwoFactorAuthURL
{
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

        internal void SetResults(List<PwEntry> results)
        {
            dataGridView1.Rows.Clear();

            foreach (var item in results)
            {
                dataGridView1.Rows.Add(new object[] { item.Strings.Get(KPRes.Title).ReadString(), item.Strings.Get(KPRes.Url).ReadString() });
            }
        }
    }
}
