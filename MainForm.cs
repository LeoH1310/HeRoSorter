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
        public struct fileElement
        {
            public string path;
            public string name;
            public int season;
        }

        private List<fileElement> fileList = new List<fileElement>();

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private string folderPath = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void resetMainForm()
        {
            txtName.Text = "";
            tbPath.Text = "";
            folderPath = "";
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

            if (txtName.Text.Length == 0 || folderPath.Length == 0) btnSort.Enabled = false;
            else btnSort.Enabled = true;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            // create sorted result folder
            string dirTo = folderPath + "\\" + txtName.Text;

            if (!Directory.Exists(dirTo)) Directory.CreateDirectory(dirTo);

            heroSort(folderPath, dirTo);

        }

        private void heroSort(string dirFrom, string dirTo)
        {
            int counterNoTag = 0;
            int counterTag = 0;
            int counterMoved = 0;
            // change cursor to hourglass type
            Cursor.Current = Cursors.WaitCursor; 

            string[] files = Directory.GetFiles(dirFrom, "*", SearchOption.AllDirectories);
            foreach (string f in files)
            {
                // filter avi and mkv files containing series information
                string fileTyp = f.Substring(f.Length - 3, 3);
                if (fileTyp == "avi" || fileTyp == "mkv")
                {
                    int season = getSeasonFromName(f);
                    if (season != -1)
                    {
                        fileElement curElement = new fileElement();
                        curElement.path = f;
                        curElement.season = season;
                        curElement.name = Path.GetFileName(f);
                        fileList.Add(curElement);
                        counterTag++;
                    }
                    else counterNoTag++;
                }
            }
            // all video files with series information are in the list
            // move files according to the season in separate folders
            foreach (fileElement file in fileList)
            {
                // create path string
                string path = dirTo + "\\Staffel " + getSeasonNumStr(file.season);
                // determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                // move file
                Directory.Move(file.path, path + "\\" + file.name);
                counterMoved++;
            }

            // change cursor to normal type
            Cursor = Cursors.Arrow;

            // show message box with results
            MessageBox.Show("HeRoSort has finished. \n"
                + (counterNoTag + counterTag) + " video files were found. \n" 
                + counterNoTag + " of them had no season tag and have not been moved! \n", 
                "Sorting Done", MessageBoxButtons.OK);

            // clear form
            resetMainForm();
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

        private string getSeasonNumStr(int num)
        {
            if (num < 9) return "0" + num.ToString();
            else return num.ToString();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0 || folderPath.Length == 0) btnSort.Enabled = false;
            else btnSort.Enabled = true;
        }
    }
}
