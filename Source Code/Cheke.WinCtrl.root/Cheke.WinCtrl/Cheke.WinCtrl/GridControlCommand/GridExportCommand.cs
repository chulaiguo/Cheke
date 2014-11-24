using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlCommand
{
    internal static class GridExportCommand
    {
        public static void ExportToHTML(GridView view)
        {
            string fileName = ShowSaveFileDialog("HTML Document", "HTML Documents|*.html");
            if (fileName.Length == 0)
                return;

            if (!fileName.ToLower().EndsWith(".html"))
            {
                fileName = string.Format("{0}.html", fileName);
            }

            view.ExportToHtml(fileName);
            OpenFile(fileName);
        }

        public static void ExportToPDF(GridView view)
        {
            string fileName = ShowSaveFileDialog("PDF Document", "PDF Documents|*.pdf");
            if (fileName.Length == 0)
                return;

            if (!fileName.ToLower().EndsWith(".pdf"))
            {
                fileName = string.Format("{0}.pdf", fileName);
            }

            view.ExportToPdf(fileName);
            OpenFile(fileName);
        }

        public static void ExportToRTF(GridView view)
        {
            string fileName = ShowSaveFileDialog("RTF Document", "RTF Documents|*.rtf");
            if (fileName.Length == 0)
                return;

            if (!fileName.ToLower().EndsWith(".rtf"))
            {
                fileName = string.Format("{0}.rtf", fileName);
            }

            view.ExportToRtf(fileName);
            OpenFile(fileName);
        }

        public static void ExportToMHT(GridView view)
        {
            string fileName = ShowSaveFileDialog("MHT Document", "MHT Documents|*.mht");
            if (fileName.Length == 0)
                return;

            if (!fileName.ToLower().EndsWith(".mht"))
            {
                fileName = string.Format("{0}.mht", fileName);
            }

            view.ExportToMht(fileName);
            OpenFile(fileName);
        }

        public static void ExportToTXT(GridView view)
        {
            string fileName = ShowSaveFileDialog("Text Document", "Text Files|*.txt");
            if (fileName.Length == 0)
                return;

            if (!fileName.ToLower().EndsWith(".txt"))
            {
                fileName = string.Format("{0}.txt", fileName);
            }

            view.ExportToText(fileName);
            OpenFile(fileName);
        }

        public static void ExportToXLS(GridView view)
        {
            string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Excel 97-2003 Workbook|*.xls");
            if (fileName.Length == 0)
                return;

            if (!fileName.ToLower().EndsWith(".xls"))
            {
                fileName = string.Format("{0}.xls", fileName);
            }

            view.ExportToXls(fileName);
            OpenFile(fileName);
        }

        public static void ExportToXLSX(GridView view)
        {
            string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Excel Workbook|*.xlsx");
            if (fileName.Length == 0)
                return;

            if (!fileName.ToLower().EndsWith(".xlsx"))
            {
                fileName = string.Format("{0}.xlsx", fileName);
            }

            view.ExportToXlsx(fileName);
            OpenFile(fileName);
        }

        public static void ExportToCSV(GridView view)
        {
            string fileName = ShowSaveFileDialog("Microsoft Excel Document", "CSV|*.csv");
            if (fileName.Length == 0)
                return;

            if (!fileName.ToLower().EndsWith(".csv"))
            {
                fileName = string.Format("{0}.csv", fileName);
            }

            view.ExportToCsv(fileName);
            OpenFile(fileName);
        }

        private static void OpenFile(string fileName)
        {
            if (MessageBox.Show("Do you want to open this file?", fileName,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    MessageBox.Show(
                        "Cannot find an application on your system suitable for openning the file with exported data.",
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = Application.ProductName;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0)
            {
                name = name.Substring(n, name.Length - n);
            }

            dlg.Title = "Export To " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName;
            }

            return string.Empty;
        }
    }
}