using System;
using System.IO;
using System.Windows.Forms;

namespace DialogueTool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            fileDir = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                displayFileDir.Text = openFileDialog.FileName;
                fileDir = openFileDialog.FileName;
            }
        }

        private void displayFileDir_TextChanged(object sender, EventArgs e)
        {
            fileDir = displayFileDir.Text;
        }

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