using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DialogueTool
{
    public partial class FormViewer : Form
    {
        /// <summary>
        /// Creates an instance of the FormViewer class and creates rows for
        /// </summary>
        /// <param name="parent">The Form that opens this form</param>
        /// <param name="directory">The string containing the file location</param>

        //Prototype: FormViewer(Form parent, string directory)
        //Arguments: takes in a Form and a string
        //Description: Creates an instance of the FormViewer class and creates rows for
        //              the data grid
        //Precondition: There must be an instance of the Form class
        //Postcondition: An instance of the FormViewer class is created
        //Protection Level: public
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

        /// <summary>
        ///When the data grid view's header is clicked the text box displays
        ///the Conversation ID, Participant Name, Emote, and line text within its
        ///cells
        /// </summary>
        /// <param name="sender">Who sent it</param>
        /// <param name="e">Mouse events</param>
        //Prototype: void grid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //Arguments: an object and a DataGridViewCellMouseEventArgs
        //Description: When the data grid view's header is clicked the text box displays
        //              the Conversation ID, Participant Name, Emote, and line text within its
        //              cells
        //Precondition: There must be an instance of the FormViewer class
        //Postcondition: The text box is updated
        //Protection Level: private
        private void grid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var convID = grid.SelectedRows[0].Cells[0].Value + string.Empty;
            var partName = grid.SelectedRows[0].Cells[1].Value + string.Empty;
            var emote = grid.SelectedRows[0].Cells[2].Value + string.Empty;
            var line = grid.SelectedRows[0].Cells[4].Value + string.Empty;
            display.Text = convID + ", " + partName + ", " + emote + ":" +
                           Environment.NewLine + "\"" + line + "\"";
        }

        /// <summary>
        /// If a cell within the data grid view is selected, the textbox
        /// will display the text within that cell
        /// </summary>
        /// <param name="sender">Who sent it</param>
        /// <param name="e">Arguments from mouse clicking on a cell</param>
        //Prototype: void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        //Arguments: an object and a DataGridViewCellEventArgs
        //Description: If a cell within the data grid view is selected, the textbox
        //              will display the text within that cell
        //Precondition: There must be an instance of the FormViewer class
        //Postcondition: The textbox is updated
        //Protection Level: private
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.SelectedCells.Count == 1 && e.RowIndex != -1)
                display.Text = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + string.Empty;
        }

        /// <summary>
        /// If the buttonNextLine is clicked and a row in the dataGridView is selected,
        /// the text box will display the text in the row after the currently selected row.
        /// </summary>
        /// <param name="sender">Who sent it</param>
        /// <param name="e">Arguments from the mouse after clicking a button</param>
        //Prototype:void buttonNextLine_Click(object sender, EventArgs e)
        //Arguments: an object and an EventArgs
        //Description: If the buttonNextLine is clicked and a row in the dataGridView is selected,
        //the text box will display the text in the row after the currently selected row.
        //Precondition: There must be an instance of the FormViewer class
        //Postcondition: The textbox is updated
        //Protection Level: private
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

        /// <summary>
        /// If the buttonPrevLine is clicked and a row in the dataGridView is
        /// selected, the textbox will display the text in the row before the
        /// currently selected row
        /// </summary>
        /// <param name="sender">Who sent it</param>
        /// <param name="e">Arguments from the mouse after clicking a button</param>
        //Prototype:void buttonPrevLine_Click(object sender, EventArgs e)
        //Arguments: an object and an EventArgs
        //Description: If the buttonPrevLine is clicked and a row in the dataGridView is
        //             selected, the textbox will display the text in the row before the
        //             currently selected row
        //Precondition: There must be an instance of the FormViewer class
        //Postcondition: The textbox is updated
        //Protection Level: private
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


        /// <summary>
        ///If the buttonPrevConv is clicked, the textbox will display the
        /// dialogue in the previous DialogueRoot from the currently selected line
        /// </summary>
        /// <param name="sender">Who sent it</param>
        /// <param name="e">Arguments from mouse after clicking a button</param>
        //Prototype: void buttonPrevConv_Click_1(object sender, EventArgs e)
        //Arguments: an object and an EventArgs
        //Description: If the buttonPrevConv is clicked, the textbox will display the
        //             dialogue in the previous DialogueRoot from the currently selected line
        //Precondition: There must be an instance of the FormViewer class
        //Postcondition: The textbox is updated
        //Protection Level: private
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

        /// <summary>
        ///
        /// </summary>
        /// <param name=""></param>
        /// <param name="">Arguments from mouse after clicking a button</param>
        //Prototype: void buttonNextConv_Click(object sender, EventArgs e)
        //Arguments: an object and an EventArgs
        //Description: If the buttonNextConv is clicked, the textbox will display the
        //             dialogue in the Next DialogueRoot from the currently selected line
        //Precondition: There must be an instance of the FormViewer class
        //Postcondition: The textbox is updated
        //Protection Level: private
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

        /// <summary>
        ///
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        //Prototype: FormViewer_FormClosed(object sender, FormClosedEventArgs e)
        //Arguments: an object and a FormClosedEventArgs
        //Description: If the instance of FormViewer is closed, the parent form will also
        //             close resulting in the program ending
        //Precondition: There must be an instance of the FormViewer class
        //Postcondition: The main form is closed and the program is finished running
        //Protection Level: private
        private void FormViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Close();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        //Prototype:string GetDisplayText(int i, int j)
        //Arguments: two intergers
        //Description: Returns a string which is the text to be displayed to the textbox
        //Precondition:There must be an instance of the FormViewer class
        //Postcondition: A string is returned
        //Protection Level: private
        private string GetDisplayText(int i, int j)
        {
            var text = dialogue.DialogueRoot[i].DialogueNode[j].ConversationID + ", " +
                       dialogue.DialogueRoot[i].DialogueNode[j].ParticipantName + ", " +
                       dialogue.DialogueRoot[i].DialogueNode[j].EmoteType + ":" +
                       Environment.NewLine +
                       "\"" + dialogue.DialogueRoot[i].DialogueNode[j].Line + "\"";
            return text;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        //Prototype: void UpdateDisplayText(int i, int j)
        //Arguments: Two intergers
        //Description: Updates the textbox that displays information
        //Precondition: There must be an instance of the FormViewer class
        //Postcondition: The textbox is updated
        //Protection Level: private
        private void UpdateDisplayText(int i, int j)
        {
            display.Text = GetDisplayText(i, j);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        //Prototype: void GetCurrentRowIndex()
        //Arguments: None
        //Description: Selects the row currently being viewed in the textbox when the text
        //             in the textBox is changed by a button; Also allows the dataGridView
        //             to scroll with the buttons when a button selects a row that is not
        //             currently visible
        //Precondition: There must be an instance of the FormViewer class
        //Postcondition: A new row is selected
        //Protection Level: private
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

        /// <summary>
        ///
        /// </summary>
        /// <param name=""></param>
        /// <param name="">Arguments from mouse after clicking a button</param>
        //Prototype: void buttonRefresh_Click(object sender, EventArgs e)
        //Arguments: an object and an EventArgs
        //Description: Causes the dataGridView to refresh by deserializing the same json file
        //             into the dialogue variable. The dataGridView is then cleared and then
        //             re-populated with the information from the dialogue variable
        //Precondition: There must be an instance of the FormViewer class
        //Postcondition: The dataGridView is cleared and re-populated, showing changes made
        //               to the json file, if any
        //Protection Level: private
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

        /// <summary>
        ///
        /// </summary>
        /// <param name=""></param>
        /// <param name="">Arguments from mouse after clicking a button</param>
        //Prototype: void buttonFontSizeUp_Click(object sender, EventArgs e)
        //Arguments: An object and an EventArgs
        //Description: Assigns the display.Font a new Font with a font size one value more
        //             than the current value
        //Precondition: There must be an instance of the FormViewer class
        //Postcondition: The text in the textbox will now be displayed with the new font size
        //Protection Level: private
        private void buttonFontSizeUp_Click(object sender, EventArgs e)
        {
            display.Font = new Font(display.Font.FontFamily, display.Font.Size + 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name=""></param>
        /// <param name="">Arguments from mouse after clicking a button</param>
        //Prototype: void buttonFontSizeDown_Click(object sender, EventArgs e)
        //Arguments: An object and an EventArgs
        //Description: Assigns the display.Font a new Font with a font size one value more
        //             than the current value
        //Precondition: There must be an instance of the FormViewer class
        //Postcondition: The text in the textbox will now be displayed with the new font size
        //Protection Level: private
        private void buttonFontSizeDown_Click(object sender, EventArgs e)
        {
            if (display.Font.Size != 1) display.Font = new Font(display.Font.FontFamily, display.Font.Size - 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name=""></param>
        /// <param name="">Arguments from mouse after clicking a button</param>
        //Prototype: void buttonClose_Click(object sender, EventArgs e)
        //Arguments: An object and an EventArgs
        //Description: if the buttonClose is clicked the parent form will close and end the app.
        //Precondition: There must be an instance of the FormViewer class
        //Postcondition: The main form is closed and the application stops running
        //Protection Level: private
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