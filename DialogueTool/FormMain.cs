using System;
using System.IO;
using System.Windows.Forms;

namespace DialogueTool
{
    public partial class FormMain : Form
    {
        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        public FormMain()
        {
            InitializeComponent();
            fileDir = "";
        }


       /// <summary>
       ///button1 slicked
       /// </summary>
       /// <param name="sender">whosent it</param>
       /// <param name="e">the arguments</param>
        private void button1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                displayFileDir.Text = openFileDialog.FileName;
                fileDir = openFileDialog.FileName;
            }
        }

        /////Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void displayFileDir_TextChanged(object sender, EventArgs e)
        {
            fileDir = displayFileDir.Text;
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void buttonViewer_Click(object sender, EventArgs e)
        {
            if (File.Exists(fileDir))
            {
                viewerForm = new FormViewer(this, fileDir);
                viewerForm.Show();
                Hide();
            }
            else if (fileDir != "")
            {
                MessageBox.Show("The file could not be found. It may have been moved or " +
                                "had its name changed",
                    "Directory not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("You must enter the directory for a .json file to view it.",
                    "No File Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void buttonEditor_Click(object sender, EventArgs e)
        {
            if (File.Exists(fileDir))
            {
                editorForm = new FormEditor(this, fileDir);
                editorForm.Show();
                Hide();
            }
            else if (fileDir != "")
            {
                MessageBox.Show("The file could not be found. It may have been moved or " +
                                "had its name changed",
                    "Directory not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                {
                    editorForm = new FormEditor(this, fileDir);
                    editorForm.Show();
                    Hide();
                }
            }
        }
    }
}