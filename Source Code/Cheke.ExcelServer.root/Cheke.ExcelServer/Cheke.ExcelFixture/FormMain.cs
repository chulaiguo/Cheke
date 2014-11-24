using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cheke.Excel;

namespace Cheke.ExcelFixture
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                byte[] data = File.ReadAllBytes(dlg.FileName);

                ExcelReader rd = new ExcelReader();
                DataTable table = rd.LoadIntoDataTable(data, "稳定性试验结果", false);
                MessageBox.Show(table.Rows.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
