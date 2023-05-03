using System;
using System.IO;
using System.Windows.Forms;

namespace StudentMgmnt
{
    internal static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            var openFileDialog = new OpenFileDialog
            {
                Filter = "CSV-Dateien (*.csv)|*.csv"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var dateiPfad = openFileDialog.FileName;
                    StudentControl.LadeSchuelerListeAusCsv(dateiPfad);
                    StudentControl.GeneriereEmailAdressen();

                    var form = new FormMain();
                    form.KurzstatistikText = StudentControl.ZeigeKurzstatistik();
                    Application.Run(form);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Beim Laden der CSV-Datei ist ein Fehler aufgetreten:{Environment.NewLine}{ex.Message}");
                }
            }
        }
    }
}