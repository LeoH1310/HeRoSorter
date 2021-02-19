using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeRoSorter
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private string folderPath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

            // Set the help text description for the FolderBrowserDialog.
            folderBrowserDialog.Description = "Select the folder to be sorted.";

            // Do not allow the user to create new files via the FolderBrowserDialog.
            folderBrowserDialog.ShowNewFolderButton = false;

            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderPath = folderBrowserDialog.SelectedPath;
                tbPath.Text = folderPath;
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            // ToDo: Check input
            string dirTo = folderPath + "\\HeRoSorted";
            DirectoryInfo di = Directory.CreateDirectory(dirTo);

            heroSort(folderPath, dirTo, rbSerie.Checked);

        }

        private void heroSort(string dirFrom, string dirTo, bool serie)
        {
            if (serie)
            {
                string[] files = Directory.GetFiles(dirFrom);
                foreach (string f in files)
                {
                    int season = getSeasonFromName(f);
                }
            }
        }

        private int getSeasonFromName(string fileName)
        {
            for(int i = 0; i <= fileName.Length; i++)
            {
                string debug1 = fileName.Substring(i, 1).ToLower();
                string debug2 = fileName.Substring(i + 1, 2).ToLower();
                if (fileName.Substring(i, 1).ToLower() == "s"
                        && fileName.Substring(i + 1, 2).All(char.IsDigit)
                        && fileName.Substring(i + 3, 1).ToLower() == "e"
                        && fileName.Substring(i + 4, 2).All(char.IsDigit))
                {
                    return Int32.Parse(fileName.Substring(i + 1, 2));
                }
            }
            return -1;
        }
    }
}
