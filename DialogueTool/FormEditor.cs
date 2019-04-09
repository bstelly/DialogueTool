using System;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace DialogueTool
{
    public partial class FormEditor : Form
    {
        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        public FormEditor(FormMain parent, string directory)
        {
            InitializeComponent();
            fileDir = directory;
            dialogue = new DialogueTree();
            if (directory != "")
            {
                dialogue.Load(fileDir);
            }
            parentForm = parent;

            if (File.Exists(fileDir))
            {
                var count = 1;
                dialogue.Load(fileDir);
                for (var i = 0; i < dialogue.DialogueRoot.Count; i++)
                {
                    Tree.Nodes[0].Nodes.Add(new TreeNode());
                    for (var j = 0; j < dialogue.DialogueRoot[i].DialogueNode.Count; j++)
                    {
                        Tree.Nodes[0].Nodes[i].Nodes.Add(new TreeNode());
                        Tree.Nodes[0].Nodes[i].Text = dialogue.DialogueRoot[i].DialogueNode[j].ConversationID;
                        Tree.Nodes[0].Nodes[i].Nodes[j].Text = count.ToString();
                        count += 1;
                    }

                    count = 1;
                }
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void FormEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Close();
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Tree.SelectedNode = e.Node;
            ToggleRootTextboxes();
            ToggleNodeTextboxes();
            GetDisplayText();
            //Conversation ID and Participants should be assigned on Root click
            //Other properties should be assigned on Node click
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tree.Nodes[0].IsSelected)
            {
                dialogue.DialogueRoot.Add(new DialogueRoot());
                Tree.Nodes[0].Nodes.Add(new TreeNode("New Root"));
                return;
            }

            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
                if (Tree.Nodes[0].Nodes[i].IsSelected)
                {
                    dialogue.DialogueRoot[i].DialogueNode.Add(new DialogueNode());
                    dialogue.DialogueRoot[i].DialogueNode[dialogue.DialogueRoot[i].DialogueNode.Count - 1]
                        .ConversationID = textBoxConvIdInput.Text;
                    dialogue.DialogueRoot[i].DialogueNode[dialogue.DialogueRoot[i].DialogueNode.Count - 1]
                        .Participants = textBoxParticipantNumInput.Text;
                    dialogue.DialogueRoot[i].DialogueNode[dialogue.DialogueRoot[i].DialogueNode.Count - 1]
                        .ConversationSummary = textBoxConversationSummaryInput.Text;
                    Tree.Nodes[0].Nodes[i].Nodes.Add(new TreeNode((Tree.Nodes[0].Nodes[i].Nodes.Count + 1).ToString()));
                    Tree.Nodes[0].Nodes[i].Expand();
                }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
                RemoveFromTree();
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void buttonAddNode_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
                if (Tree.Nodes[0].Nodes[i].IsSelected)
                {
                    Tree.Nodes[0].Nodes[i].Nodes.Add(new TreeNode((Tree.Nodes[0].Nodes[i].Nodes.Count + 1).ToString()));
                    Tree.Nodes[0].Nodes[i].Expand();
                    dialogue.DialogueRoot[i].DialogueNode.Add(new DialogueNode());
                }

            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
            for (var j = 0; j < Tree.Nodes[0].Nodes[i].Nodes.Count; j++)
                if (Tree.Nodes[0].Nodes[i].Nodes[j].IsSelected)
                {
                    Tree.Nodes[0].Nodes[i].Nodes
                        .Add(new TreeNode((Tree.Nodes[0].Nodes[i].Nodes.Count + 1).ToString()));
                    dialogue.DialogueRoot[i].DialogueNode.Add(new DialogueNode());
                    dialogue.DialogueRoot[i].DialogueNode[dialogue.DialogueRoot[i].DialogueNode.Count - 1]
                        .ConversationID = textBoxConvIdInput.Text;
                    dialogue.DialogueRoot[i].DialogueNode[dialogue.DialogueRoot[i].DialogueNode.Count - 1]
                        .Participants = textBoxParticipantNumInput.Text;
                    dialogue.DialogueRoot[i].DialogueNode[dialogue.DialogueRoot[i].DialogueNode.Count - 1]
                        .ConversationSummary = textBoxConversationSummaryInput.Text;
                    }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void buttonAddRoot_Click(object sender, EventArgs e)
        {
            Tree.Nodes[0].Nodes.Add(new TreeNode("New Root"));
            dialogue.DialogueRoot.Add(new DialogueRoot());
            Tree.Nodes[0].Expand();
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RemoveFromTree();
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void buttonOpenViewer_Click(object sender, EventArgs e)
        {
            if (fileDir != "")
            {
                viewerForm = new FormViewer(this, fileDir);
                viewerForm.Show();
            }
            else
            {
                MessageBox.Show("Can not open a new file in the viewer until it is saved.",
                    "Unsaved File", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SetConversationId();
            saveFileDialog.ShowDialog();
            fileDir = saveFileDialog.FileName;
            dialogue.Save(fileDir);
        }


        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void ToggleRootTextboxes()
        {
            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
            {
                if (Tree.Nodes[0].Nodes[i].IsSelected)
                {
                    textBoxConvIdInput.BackColor = Color.White;
                    textBoxConvIdInput.ReadOnly = false;
                    textBoxParticipantNumInput.BackColor = Color.White;
                    textBoxParticipantNumInput.ReadOnly = false;
                    textBoxConversationSummaryInput.BackColor = Color.White;
                    textBoxConversationSummaryInput.ReadOnly = false;
                    return;
                }
                    textBoxConvIdInput.BackColor = SystemColors.Control;
                    textBoxConvIdInput.ReadOnly = true;
                    textBoxParticipantNumInput.BackColor = SystemColors.Control;
                    textBoxParticipantNumInput.ReadOnly = true;
                    textBoxConversationSummaryInput.BackColor = SystemColors.Control;
                    textBoxConversationSummaryInput.ReadOnly = true;
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void RemoveFromTree()
        {
            var result = DialogResult.OK;
            if (Tree.SelectedNode != Tree.Nodes[0])
            {
                if (Tree.Nodes[0].Nodes.Contains(Tree.SelectedNode))
                {
                    if (checkBoxRootWarn.Checked)
                        result = MessageBox.Show("Are you sure you want to delete this Root?",
                            "Delete Root", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        dialogue.DialogueRoot.Remove(dialogue.DialogueRoot[Tree.SelectedNode.Index]);
                        Tree.SelectedNode.Remove();
                        return;
                    }
                }

                for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
                for (var j = 0; j < Tree.Nodes[0].Nodes[i].Nodes.Count; j++)
                    if (Tree.Nodes[0].Nodes[i].Nodes[j].IsSelected)
                    {
                        if (checkBoxNodeWarn.Checked)
                            result = MessageBox.Show("Are you sure you want to delete this Node?",
                                "Delete Node", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            Tree.SelectedNode.Remove();
                            dialogue.DialogueRoot[i].DialogueNode.Remove(
                                dialogue.DialogueRoot[i].DialogueNode[j]);
                            return;
                        }
                    }
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void ToggleNodeTextboxes()
        {
            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
            {
                for (var j = 0; j < Tree.Nodes[0].Nodes[i].Nodes.Count; j++)
                {
                    if (Tree.Nodes[0].Nodes[i].Nodes[j].IsSelected)
                    {
                        textBoxSpecialityAnimationInput.BackColor = Color.White;
                        textBoxSpecialityAnimationInput.ReadOnly = false;
                        textBoxSideInput.BackColor = Color.White;
                        textBoxSideInput.ReadOnly = false;
                        textBoxSpecialtyCameraInput.BackColor = Color.White;
                        textBoxSpecialtyCameraInput.ReadOnly = false;
                        textBoxParticipantNameInput.BackColor = Color.White;
                        textBoxParticipantNameInput.ReadOnly = false;
                        textBoxEmoteTypeInput.BackColor = Color.White;
                        textBoxEmoteTypeInput.ReadOnly = false;
                        textBoxLineInput.BackColor = Color.White;
                        textBoxLineInput.ReadOnly = false;
                        return;
                    }
                        textBoxSpecialityAnimationInput.BackColor = SystemColors.Control;
                        textBoxSpecialityAnimationInput.ReadOnly = true;
                        textBoxSideInput.BackColor = SystemColors.Control;
                        textBoxSideInput.ReadOnly = true;
                        textBoxSpecialtyCameraInput.BackColor = SystemColors.Control;
                        textBoxSpecialtyCameraInput.ReadOnly = true;
                        textBoxParticipantNameInput.BackColor = SystemColors.Control;
                        textBoxParticipantNameInput.ReadOnly = true;
                        textBoxEmoteTypeInput.BackColor = SystemColors.Control;
                        textBoxEmoteTypeInput.ReadOnly = true;
                        textBoxLineInput.BackColor = SystemColors.Control;
                        textBoxLineInput.ReadOnly = true;
                }
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void textBoxConvIdInput_TextChanged(object sender, EventArgs e)
        {
            Tree.Nodes[0].Nodes[GetSelectedRoot()].Text = textBoxConvIdInput.Text;
            foreach (var node in dialogue.DialogueRoot[GetSelectedRoot()].DialogueNode)
            {
                node.ConversationID = Tree.Nodes[0].Nodes[GetSelectedRoot()].Text;
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void textBoxParticipantNumInput_TextChanged(object sender, EventArgs e)
        {
            string[] numbers = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            for (int i = 0; i < numbers.Length; i++)
            {
                if (textBoxParticipantNumInput.Text.Contains(numbers[i]))
                {
                    while (Tree.SelectedNode.Nodes.Count < Convert.ToInt32(textBoxParticipantNumInput.Text))
                    {
                        dialogue.DialogueRoot[Tree.SelectedNode.Index].DialogueNode.Add(new DialogueNode());
                        Tree.Nodes[0].Nodes[Tree.SelectedNode.Index].Nodes
                            .Add(new TreeNode((Tree.Nodes[0].Nodes[Tree.SelectedNode.Index].Nodes.Count + 1)
                                .ToString()));
                    }

                    foreach (var node in dialogue.DialogueRoot[GetSelectedRoot()].DialogueNode)
                    {
                        node.Participants = textBoxParticipantNumInput.Text;
                    }
                }
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void textBoxParticipantNameInput_TextChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
            {
                for (var j = 0; j < Tree.Nodes[0].Nodes[i].Nodes.Count; j++)
                {
                    if (Tree.Nodes[0].Nodes[i].Nodes[j].IsSelected)
                    {
                        dialogue.DialogueRoot[i].DialogueNode[j].ParticipantName = textBoxParticipantNameInput.Text;
                    }
                }
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void textBoxEmoteTypeInput_TextChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
            {
                for (var j = 0; j < Tree.Nodes[0].Nodes[i].Nodes.Count; j++)
                {
                    if (Tree.Nodes[0].Nodes[i].Nodes[j].IsSelected)
                    {
                        dialogue.DialogueRoot[i].DialogueNode[j].EmoteType = textBoxEmoteTypeInput.Text;
                    }
                }
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void textBoxSideInput_TextChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
            {
                for (var j = 0; j < Tree.Nodes[0].Nodes[i].Nodes.Count; j++)
                {
                    if (Tree.Nodes[0].Nodes[i].Nodes[j].IsSelected)
                    {
                        dialogue.DialogueRoot[i].DialogueNode[j].Side = textBoxSideInput.Text;
                    }
                }
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void textBoxSpecialityAnimationInput_TextChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
            {
                for (var j = 0; j < Tree.Nodes[0].Nodes[i].Nodes.Count; j++)
                {
                    if (Tree.Nodes[0].Nodes[i].Nodes[j].IsSelected)
                    {
                        dialogue.DialogueRoot[i].DialogueNode[j].SpecialityAnimation =
                            textBoxSpecialityAnimationInput.Text;
                    }
                }
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:v
        private void textBoxSpecialtyCameraInput_TextChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
            {
                for (var j = 0; j < Tree.Nodes[0].Nodes[i].Nodes.Count; j++)
                {
                    if (Tree.Nodes[0].Nodes[i].Nodes[j].IsSelected)
                    {
                        dialogue.DialogueRoot[i].DialogueNode[j].SpecialtyCamera = textBoxSpecialtyCameraInput.Text;
                    }
                }
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void textBoxLineInput_TextChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
            {
                for (var j = 0; j < Tree.Nodes[0].Nodes[i].Nodes.Count; j++)
                {
                    if (Tree.Nodes[0].Nodes[i].Nodes[j].IsSelected)
                    {
                        dialogue.DialogueRoot[i].DialogueNode[j].Line = textBoxLineInput.Text;
                    }
                }
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void textBoxConversationSummaryInput_TextChanged(object sender, EventArgs e)
        {
            foreach (var node in dialogue.DialogueRoot[GetSelectedRoot()].DialogueNode)
            {
                node.ConversationSummary = textBoxConversationSummaryInput.Text;
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private int GetSelectedRoot()
        {
            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
                if (Tree.Nodes[0].Nodes[i].IsSelected)
                {
                    return i;
                }

            return 0;
        }


        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void SetConversationId()
        {
            for (int i = 0; i < dialogue.DialogueRoot.Count; i++)
            {
                for (int j = 0; j < dialogue.DialogueRoot[i].DialogueNode.Count; j++)
                {
                    dialogue.DialogueRoot[i].DialogueNode[j].ConversationID = Tree.Nodes[0].Nodes[i].Text;
                }
            }
        }

        //Prototype:
        //Arguments:
        //Description:
        //Precondition:
        //Postcondition:
        //Protection Level:
        private void GetDisplayText()
        {
            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
                if (Tree.Nodes[0].Nodes[i].IsSelected)
                {
                    textBoxConvIdInput.Text = Tree.SelectedNode.Text;
                    if (dialogue.DialogueRoot[i].DialogueNode.Count != 0)
                    {
                        textBoxParticipantNumInput.Text = dialogue.DialogueRoot[i].DialogueNode[0].Participants;
                        textBoxConversationSummaryInput.Text = dialogue.DialogueRoot[i].DialogueNode[0].ConversationSummary;
                    }
                }

            for (var i = 0; i < Tree.Nodes[0].Nodes.Count; i++)
            {
                for (var j = 0; j < Tree.Nodes[0].Nodes[i].Nodes.Count; j++)
                {
                    if (Tree.Nodes[0].Nodes[i].Nodes[j].IsSelected)
                    {
                        textBoxParticipantNameInput.Text = dialogue.DialogueRoot[i].DialogueNode[j].ParticipantName;
                        textBoxEmoteTypeInput.Text = dialogue.DialogueRoot[i].DialogueNode[j].EmoteType;
                        textBoxLineInput.Text = dialogue.DialogueRoot[i].DialogueNode[j].Line;
                        textBoxSpecialtyCameraInput.Text = dialogue.DialogueRoot[i].DialogueNode[j].SpecialtyCamera;
                        textBoxSpecialityAnimationInput.Text =
                            dialogue.DialogueRoot[i].DialogueNode[j].SpecialityAnimation;
                        textBoxSideInput.Text = dialogue.DialogueRoot[i].DialogueNode[j].Side;
                    }
                }
            }
        }
    }
}