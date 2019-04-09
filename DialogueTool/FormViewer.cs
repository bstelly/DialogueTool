using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DialogueTool
{
    public partial class FormViewer : Form
    {
        public FormViewer(Form parent, string directory)
        {
            Click += Refresh_Click;
            parentForm = parent;
            fileDir = directory;
            InitializeComponent();
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dialogue = new DialogueTree();
            dialogue.Load(directory);
            for (var i = 0; i < dialogue.DialogueRoot.Count; i++)
            for (var j = 0; j < dialogue.DialogueRoot[i].DialogueNode.Count; j++)
            {
                var row = (DataGridViewRow) grid.RowTemplate.Clone();
                string[] strings =
                {
                    dialogue.DialogueRoot[i].DialogueNode[j].ConversationID,
                    dialogue.DialogueRoot[i].DialogueNode[j].ParticipantName,
                    dialogue.DialogueRoot[i].DialogueNode[j].EmoteType,
                    dialogue.DialogueRoot[i].DialogueNode[j].Side,
                    dialogue.DialogueRoot[i].DialogueNode[j].Line,
                    dialogue.DialogueRoot[i].DialogueNode[j].SpecialityAnimation,
                    dialogue.DialogueRoot[i].DialogueNode[j].SpecialtyCamera,
                    dialogue.DialogueRoot[i].DialogueNode[j].Participants,
                    dialogue.DialogueRoot[i].DialogueNode[j].ConversationSummary
                };
                row.CreateCells(grid, strings);
                grid.Rows.Add(strings);
                dialogueLines += 1;
            }

            buttonFontSizeUp.Text = char.ConvertFromUtf32(0x2191);
            buttonFontSizeDown.Text = char.ConvertFromUtf32(0x2193);


        }

        private void grid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var convID = grid.SelectedRows[0].Cells[0].Value + string.Empty;
            var partName = grid.SelectedRows[0].Cells[1].Value + string.Empty;
            var emote = grid.SelectedRows[0].Cells[2].Value + string.Empty;
            var line = grid.SelectedRows[0].Cells[4].Value + string.Empty;
            display.Text = convID + ", " + partName + ", " + emote + ":" +
                           Environment.NewLine + "\"" + line + "\"";
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.SelectedCells.Count == 1 && e.RowIndex != -1)
                display.Text = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + string.Empty;
        }

        private void buttonNextLine_Click(object sender, EventArgs e)
        {
            if (!display.Text.Contains(dialogue.DialogueRoot[dialogue.DialogueRoot.Count - 1]
                .DialogueNode[dialogue.DialogueRoot[dialogue.DialogueRoot.Count - 1].DialogueNode.Count - 1].Line))
                for (var i = 0; i < dialogue.DialogueRoot.Count; i++)
                for (var j = 0; j < dialogue.DialogueRoot[i].DialogueNode.Count; j++)
                    if (display.Text == GetDisplayText(i, j))
                    {
                        if (dialogue.DialogueRoot[i].DialogueNode.Count == j + 1)
                        {
                            UpdateDisplayText(i + 1, 0);
                            GetCurrentRowIndex();
                            return;
                        }

                        UpdateDisplayText(i, j + 1);
                        GetCurrentRowIndex();
                        return;
                    }
        }

        private void buttonPrevLine_Click(object sender, EventArgs e)
        {
            if (!display.Text.Contains(dialogue.DialogueRoot[0].DialogueNode[0].Line))
                for (var i = 0; i < dialogue.DialogueRoot.Count; i++)
                for (var j = 0; j < dialogue.DialogueRoot[i].DialogueNode.Count; j++)
                    if (display.Text == GetDisplayText(i, j))
                    {
                        if (j == 0)
                        {
                            UpdateDisplayText(
                                i - 1, dialogue.DialogueRoot[i - 1].DialogueNode.Count - 1);
                            GetCurrentRowIndex();
                            return;
                        }

                        UpdateDisplayText(i, j - 1);
                        GetCurrentRowIndex();
                        return;
                    }
        }

        private void buttonPrevConv_Click_1(object sender, EventArgs e)
        {
            for (var i = 0; i < dialogue.DialogueRoot.Count; i++)
            for (var j = 0; j < dialogue.DialogueRoot[i].DialogueNode.Count; j++)
                if (display.Text == GetDisplayText(i, j) && i > 0)
                {
                    UpdateDisplayText(i - 1, 0);
                    GetCurrentRowIndex();
                    return;
                }
        }

        private void buttonNextConv_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < dialogue.DialogueRoot.Count; i++)
            for (var j = 0; j < dialogue.DialogueRoot[i].DialogueNode.Count; j++)
                if (display.Text == GetDisplayText(i, j) &&
                    i < dialogue.DialogueRoot.Count - 1)
                {
                    UpdateDisplayText(i + 1, 0);
                    GetCurrentRowIndex();
                    return;
                }
        }

        private void FormViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Close();
        }

        private string GetDisplayText(int i, int j)
        {
            var text = dialogue.DialogueRoot[i].DialogueNode[j].ConversationID + ", " +
                       dialogue.DialogueRoot[i].DialogueNode[j].ParticipantName + ", " +
                       dialogue.DialogueRoot[i].DialogueNode[j].EmoteType + ":" +
                       Environment.NewLine +
                       "\"" + dialogue.DialogueRoot[i].DialogueNode[j].Line + "\"";
            return text;
        }

        private void UpdateDisplayText(int i, int j)
        {
            display.Text = GetDisplayText(i, j);
        }

        private void GetCurrentRowIndex()
        {
            grid.ClearSelection();
            var count = 0;

            for (var i = 0; i < dialogue.DialogueRoot.Count; i++)
            for (var j = 0; j < dialogue.DialogueRoot[i].DialogueNode.Count; j++)
            {
                count += 1;
                if (display.Text.Contains(
                        dialogue.DialogueRoot[i].DialogueNode[j].ConversationID) &&
                    display.Text.Contains(
                        dialogue.DialogueRoot[i].DialogueNode[j].Line))
                {
                    count -= 1;
                    grid.Rows[count].Selected = true;
                    grid.CurrentCell = grid.Rows[count].Cells[0];
                }
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            dialogue = JsonConvert.DeserializeObject<DialogueTree>(File.ReadAllText(
                fileDir));
            grid.Rows.Clear();
            for (var i = 0; i < dialogue.DialogueRoot.Count; i++)
            for (var j = 0; j < dialogue.DialogueRoot[i].DialogueNode.Count; j++)
            {
                var row = (DataGridViewRow) grid.RowTemplate.Clone();
                string[] strings =
                {
                    dialogue.DialogueRoot[i].DialogueNode[j].ConversationID,
                    dialogue.DialogueRoot[i].DialogueNode[j].ParticipantName,
                    dialogue.DialogueRoot[i].DialogueNode[j].EmoteType,
                    dialogue.DialogueRoot[i].DialogueNode[j].Side,
                    dialogue.DialogueRoot[i].DialogueNode[j].Line,
                    dialogue.DialogueRoot[i].DialogueNode[j].SpecialityAnimation,
                    dialogue.DialogueRoot[i].DialogueNode[j].SpecialtyCamera,
                    dialogue.DialogueRoot[i].DialogueNode[j].Participants,
                    dialogue.DialogueRoot[i].DialogueNode[j].ConversationSummary
                };
                row.CreateCells(grid, strings);
                grid.Rows.Add(strings);
                dialogueLines += 1;
            }
        }

        private void buttonFontSizeUp_Click(object sender, EventArgs e)
        {
            display.Font = new Font(display.Font.FontFamily, display.Font.Size + 1);
        }

        private void buttonFontSizeDown_Click(object sender, EventArgs e)
        {
            if (display.Font.Size != 1) display.Font = new Font(display.Font.FontFamily, display.Font.Size - 1);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (parentForm is FormEditor)
            {
                Close();
            }
            else
            {
                parentForm.Close();
            }
        }
    }
}