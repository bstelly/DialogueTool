using System.Windows.Forms;

namespace DialogueTool
{
    partial class FormEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Dialogue Tree");
            this.Tree = new System.Windows.Forms.TreeView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonAddNode = new System.Windows.Forms.Button();
            this.buttonAddRoot = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.checkBoxRootWarn = new System.Windows.Forms.CheckBox();
            this.checkBoxNodeWarn = new System.Windows.Forms.CheckBox();
            this.textBoxConvIdInput = new System.Windows.Forms.TextBox();
            this.infoText1 = new System.Windows.Forms.TextBox();
            this.infoText2 = new System.Windows.Forms.TextBox();
            this.textBoxParticipantNumInput = new System.Windows.Forms.TextBox();
            this.infoText9 = new System.Windows.Forms.TextBox();
            this.infoText4 = new System.Windows.Forms.TextBox();
            this.infoText8 = new System.Windows.Forms.TextBox();
            this.infoText7 = new System.Windows.Forms.TextBox();
            this.infoText6 = new System.Windows.Forms.TextBox();
            this.infoText5 = new System.Windows.Forms.TextBox();
            this.infoText3 = new System.Windows.Forms.TextBox();
            this.textBoxSpecialityAnimationInput = new System.Windows.Forms.TextBox();
            this.textBoxSideInput = new System.Windows.Forms.TextBox();
            this.textBoxSpecialtyCameraInput = new System.Windows.Forms.TextBox();
            this.textBoxParticipantNameInput = new System.Windows.Forms.TextBox();
            this.textBoxEmoteTypeInput = new System.Windows.Forms.TextBox();
            this.textBoxLineInput = new System.Windows.Forms.TextBox();
            this.textBoxConversationSummaryInput = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpenViewer = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tree
            // 
            this.Tree.AllowDrop = true;
            this.Tree.ContextMenuStrip = this.contextMenu;
            this.Tree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tree.Location = new System.Drawing.Point(12, 12);
            this.Tree.Name = "Tree";
            treeNode1.Name = "Dialogue Tree";
            treeNode1.Text = "Dialogue Tree";
            this.Tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.Tree.Size = new System.Drawing.Size(207, 658);
            this.Tree.TabIndex = 11;
            this.Tree.TabStop = false;
            this.Tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tree_NodeMouseClick);
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(118, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // buttonAddNode
            // 
            this.buttonAddNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddNode.Location = new System.Drawing.Point(225, 69);
            this.buttonAddNode.Name = "buttonAddNode";
            this.buttonAddNode.Size = new System.Drawing.Size(102, 51);
            this.buttonAddNode.TabIndex = 1;
            this.buttonAddNode.Text = "Add Node";
            this.toolTip.SetToolTip(this.buttonAddNode, "Adds a Node to the selected Dialogue Root");
            this.buttonAddNode.UseVisualStyleBackColor = true;
            this.buttonAddNode.Click += new System.EventHandler(this.buttonAddNode_Click);
            // 
            // buttonAddRoot
            // 
            this.buttonAddRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddRoot.Location = new System.Drawing.Point(225, 12);
            this.buttonAddRoot.Name = "buttonAddRoot";
            this.buttonAddRoot.Size = new System.Drawing.Size(102, 51);
            this.buttonAddRoot.TabIndex = 0;
            this.buttonAddRoot.Text = "Add Root";
            this.toolTip.SetToolTip(this.buttonAddRoot, "Add a Root to the Tree");
            this.buttonAddRoot.UseVisualStyleBackColor = true;
            this.buttonAddRoot.Click += new System.EventHandler(this.buttonAddRoot_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(225, 619);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(102, 51);
            this.buttonRemove.TabIndex = 4;
            this.buttonRemove.TabStop = false;
            this.buttonRemove.Text = "Remove Root/Node";
            this.toolTip.SetToolTip(this.buttonRemove, "Remove the currently selected Root or Node");
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // checkBoxRootWarn
            // 
            this.checkBoxRootWarn.AutoSize = true;
            this.checkBoxRootWarn.Checked = true;
            this.checkBoxRootWarn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRootWarn.Location = new System.Drawing.Point(337, 625);
            this.checkBoxRootWarn.Name = "checkBoxRootWarn";
            this.checkBoxRootWarn.Size = new System.Drawing.Size(158, 17);
            this.checkBoxRootWarn.TabIndex = 5;
            this.checkBoxRootWarn.TabStop = false;
            this.checkBoxRootWarn.Text = "Warn when removing Roots";
            this.checkBoxRootWarn.UseVisualStyleBackColor = true;
            // 
            // checkBoxNodeWarn
            // 
            this.checkBoxNodeWarn.AutoSize = true;
            this.checkBoxNodeWarn.Checked = true;
            this.checkBoxNodeWarn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNodeWarn.Location = new System.Drawing.Point(337, 647);
            this.checkBoxNodeWarn.Name = "checkBoxNodeWarn";
            this.checkBoxNodeWarn.Size = new System.Drawing.Size(161, 17);
            this.checkBoxNodeWarn.TabIndex = 6;
            this.checkBoxNodeWarn.TabStop = false;
            this.checkBoxNodeWarn.Text = "Warn when removing Nodes";
            this.checkBoxNodeWarn.UseVisualStyleBackColor = true;
            // 
            // textBoxConvIdInput
            // 
            this.textBoxConvIdInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConvIdInput.Location = new System.Drawing.Point(261, 333);
            this.textBoxConvIdInput.Name = "textBoxConvIdInput";
            this.textBoxConvIdInput.ReadOnly = true;
            this.textBoxConvIdInput.Size = new System.Drawing.Size(120, 23);
            this.textBoxConvIdInput.TabIndex = 2;
            this.textBoxConvIdInput.TextChanged += new System.EventHandler(this.textBoxConvIdInput_TextChanged);
            // 
            // infoText1
            // 
            this.infoText1.BackColor = System.Drawing.SystemColors.Control;
            this.infoText1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoText1.Location = new System.Drawing.Point(261, 315);
            this.infoText1.Name = "infoText1";
            this.infoText1.ReadOnly = true;
            this.infoText1.Size = new System.Drawing.Size(100, 13);
            this.infoText1.TabIndex = 8;
            this.infoText1.TabStop = false;
            this.infoText1.Text = "Conversation ID";
            // 
            // infoText2
            // 
            this.infoText2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoText2.Location = new System.Drawing.Point(423, 302);
            this.infoText2.Multiline = true;
            this.infoText2.Name = "infoText2";
            this.infoText2.ReadOnly = true;
            this.infoText2.Size = new System.Drawing.Size(100, 26);
            this.infoText2.TabIndex = 9;
            this.infoText2.TabStop = false;
            this.infoText2.Text = "Number of\r\nParticipants";
            // 
            // textBoxParticipantNumInput
            // 
            this.textBoxParticipantNumInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxParticipantNumInput.Location = new System.Drawing.Point(423, 333);
            this.textBoxParticipantNumInput.Name = "textBoxParticipantNumInput";
            this.textBoxParticipantNumInput.ReadOnly = true;
            this.textBoxParticipantNumInput.Size = new System.Drawing.Size(37, 23);
            this.textBoxParticipantNumInput.TabIndex = 3;
            this.textBoxParticipantNumInput.TextChanged += new System.EventHandler(this.textBoxParticipantNumInput_TextChanged);
            // 
            // infoText9
            // 
            this.infoText9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoText9.Location = new System.Drawing.Point(576, 50);
            this.infoText9.Name = "infoText9";
            this.infoText9.ReadOnly = true;
            this.infoText9.Size = new System.Drawing.Size(110, 13);
            this.infoText9.TabIndex = 11;
            this.infoText9.TabStop = false;
            this.infoText9.Text = "Conversation Summary";
            // 
            // infoText4
            // 
            this.infoText4.BackColor = System.Drawing.SystemColors.Control;
            this.infoText4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoText4.Location = new System.Drawing.Point(818, 270);
            this.infoText4.Name = "infoText4";
            this.infoText4.ReadOnly = true;
            this.infoText4.Size = new System.Drawing.Size(100, 13);
            this.infoText4.TabIndex = 13;
            this.infoText4.TabStop = false;
            this.infoText4.Text = "Emote Type";
            // 
            // infoText8
            // 
            this.infoText8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoText8.Location = new System.Drawing.Point(890, 358);
            this.infoText8.Name = "infoText8";
            this.infoText8.ReadOnly = true;
            this.infoText8.Size = new System.Drawing.Size(85, 13);
            this.infoText8.TabIndex = 14;
            this.infoText8.TabStop = false;
            this.infoText8.Text = "Specialty Camera";
            // 
            // infoText7
            // 
            this.infoText7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoText7.Location = new System.Drawing.Point(727, 358);
            this.infoText7.Name = "infoText7";
            this.infoText7.ReadOnly = true;
            this.infoText7.Size = new System.Drawing.Size(100, 13);
            this.infoText7.TabIndex = 15;
            this.infoText7.TabStop = false;
            this.infoText7.Text = "Speciality Animation";
            // 
            // infoText6
            // 
            this.infoText6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoText6.Location = new System.Drawing.Point(575, 441);
            this.infoText6.Name = "infoText6";
            this.infoText6.ReadOnly = true;
            this.infoText6.Size = new System.Drawing.Size(100, 13);
            this.infoText6.TabIndex = 16;
            this.infoText6.TabStop = false;
            this.infoText6.Text = "Line";
            // 
            // infoText5
            // 
            this.infoText5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoText5.Location = new System.Drawing.Point(576, 358);
            this.infoText5.Name = "infoText5";
            this.infoText5.ReadOnly = true;
            this.infoText5.Size = new System.Drawing.Size(100, 13);
            this.infoText5.TabIndex = 17;
            this.infoText5.TabStop = false;
            this.infoText5.Text = "Side";
            // 
            // infoText3
            // 
            this.infoText3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoText3.Location = new System.Drawing.Point(576, 270);
            this.infoText3.Name = "infoText3";
            this.infoText3.ReadOnly = true;
            this.infoText3.Size = new System.Drawing.Size(100, 13);
            this.infoText3.TabIndex = 18;
            this.infoText3.TabStop = false;
            this.infoText3.Text = "Participant Name";
            // 
            // textBoxSpecialityAnimationInput
            // 
            this.textBoxSpecialityAnimationInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSpecialityAnimationInput.Location = new System.Drawing.Point(727, 377);
            this.textBoxSpecialityAnimationInput.Name = "textBoxSpecialityAnimationInput";
            this.textBoxSpecialityAnimationInput.ReadOnly = true;
            this.textBoxSpecialityAnimationInput.Size = new System.Drawing.Size(126, 23);
            this.textBoxSpecialityAnimationInput.TabIndex = 7;
            this.textBoxSpecialityAnimationInput.TextChanged += new System.EventHandler(this.textBoxSpecialityAnimationInput_TextChanged);
            // 
            // textBoxSideInput
            // 
            this.textBoxSideInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSideInput.Location = new System.Drawing.Point(576, 377);
            this.textBoxSideInput.Name = "textBoxSideInput";
            this.textBoxSideInput.ReadOnly = true;
            this.textBoxSideInput.Size = new System.Drawing.Size(110, 23);
            this.textBoxSideInput.TabIndex = 6;
            this.textBoxSideInput.TextChanged += new System.EventHandler(this.textBoxSideInput_TextChanged);
            // 
            // textBoxSpecialtyCameraInput
            // 
            this.textBoxSpecialtyCameraInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSpecialtyCameraInput.Location = new System.Drawing.Point(890, 377);
            this.textBoxSpecialtyCameraInput.Name = "textBoxSpecialtyCameraInput";
            this.textBoxSpecialtyCameraInput.ReadOnly = true;
            this.textBoxSpecialtyCameraInput.Size = new System.Drawing.Size(124, 23);
            this.textBoxSpecialtyCameraInput.TabIndex = 8;
            this.textBoxSpecialtyCameraInput.TextChanged += new System.EventHandler(this.textBoxSpecialtyCameraInput_TextChanged);
            // 
            // textBoxParticipantNameInput
            // 
            this.textBoxParticipantNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxParticipantNameInput.Location = new System.Drawing.Point(575, 297);
            this.textBoxParticipantNameInput.Name = "textBoxParticipantNameInput";
            this.textBoxParticipantNameInput.ReadOnly = true;
            this.textBoxParticipantNameInput.Size = new System.Drawing.Size(197, 23);
            this.textBoxParticipantNameInput.TabIndex = 4;
            this.textBoxParticipantNameInput.TextChanged += new System.EventHandler(this.textBoxParticipantNameInput_TextChanged);
            // 
            // textBoxEmoteTypeInput
            // 
            this.textBoxEmoteTypeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmoteTypeInput.Location = new System.Drawing.Point(818, 297);
            this.textBoxEmoteTypeInput.Name = "textBoxEmoteTypeInput";
            this.textBoxEmoteTypeInput.ReadOnly = true;
            this.textBoxEmoteTypeInput.Size = new System.Drawing.Size(196, 23);
            this.textBoxEmoteTypeInput.TabIndex = 5;
            this.textBoxEmoteTypeInput.TextChanged += new System.EventHandler(this.textBoxEmoteTypeInput_TextChanged);
            // 
            // textBoxLineInput
            // 
            this.textBoxLineInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLineInput.Location = new System.Drawing.Point(576, 460);
            this.textBoxLineInput.Multiline = true;
            this.textBoxLineInput.Name = "textBoxLineInput";
            this.textBoxLineInput.ReadOnly = true;
            this.textBoxLineInput.Size = new System.Drawing.Size(439, 134);
            this.textBoxLineInput.TabIndex = 9;
            this.textBoxLineInput.TextChanged += new System.EventHandler(this.textBoxLineInput_TextChanged);
            // 
            // textBoxConversationSummaryInput
            // 
            this.textBoxConversationSummaryInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConversationSummaryInput.Location = new System.Drawing.Point(576, 69);
            this.textBoxConversationSummaryInput.Multiline = true;
            this.textBoxConversationSummaryInput.Name = "textBoxConversationSummaryInput";
            this.textBoxConversationSummaryInput.ReadOnly = true;
            this.textBoxConversationSummaryInput.Size = new System.Drawing.Size(439, 152);
            this.textBoxConversationSummaryInput.TabIndex = 10;
            this.textBoxConversationSummaryInput.TextChanged += new System.EventHandler(this.textBoxConversationSummaryInput_TextChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(951, 641);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 29;
            this.buttonSave.TabStop = false;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonOpenViewer
            // 
            this.buttonOpenViewer.Location = new System.Drawing.Point(576, 643);
            this.buttonOpenViewer.Name = "buttonOpenViewer";
            this.buttonOpenViewer.Size = new System.Drawing.Size(218, 23);
            this.buttonOpenViewer.TabIndex = 30;
            this.buttonOpenViewer.TabStop = false;
            this.buttonOpenViewer.Text = "Open In Viewer";
            this.buttonOpenViewer.UseVisualStyleBackColor = true;
            this.buttonOpenViewer.Click += new System.EventHandler(this.buttonOpenViewer_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
            // 
            // FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1038, 673);
            this.Controls.Add(this.buttonOpenViewer);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxConversationSummaryInput);
            this.Controls.Add(this.textBoxLineInput);
            this.Controls.Add(this.textBoxEmoteTypeInput);
            this.Controls.Add(this.textBoxParticipantNameInput);
            this.Controls.Add(this.textBoxSpecialtyCameraInput);
            this.Controls.Add(this.textBoxSideInput);
            this.Controls.Add(this.textBoxSpecialityAnimationInput);
            this.Controls.Add(this.infoText3);
            this.Controls.Add(this.infoText5);
            this.Controls.Add(this.infoText6);
            this.Controls.Add(this.infoText7);
            this.Controls.Add(this.infoText8);
            this.Controls.Add(this.infoText4);
            this.Controls.Add(this.infoText9);
            this.Controls.Add(this.textBoxParticipantNumInput);
            this.Controls.Add(this.infoText2);
            this.Controls.Add(this.infoText1);
            this.Controls.Add(this.textBoxConvIdInput);
            this.Controls.Add(this.checkBoxNodeWarn);
            this.Controls.Add(this.checkBoxRootWarn);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAddRoot);
            this.Controls.Add(this.buttonAddNode);
            this.Controls.Add(this.Tree);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1056, 718);
            this.Name = "FormEditor";
            this.Text = "Dialogue Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEditor_FormClosed);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FormMain parentForm;
        private string fileDir;
        private DialogueTree dialogue;
        private TreeView Tree;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolTip toolTip;
        private Button buttonAddNode;
        private Button buttonAddRoot;
        private Button buttonRemove;
        private CheckBox checkBoxRootWarn;
        private CheckBox checkBoxNodeWarn;
        private TextBox textBoxConvIdInput;
        private TextBox infoText1;
        private TextBox infoText2;
        private TextBox textBoxParticipantNumInput;
        private TextBox infoText9;
        private TextBox infoText4;
        private TextBox infoText8;
        private TextBox infoText7;
        private TextBox infoText6;
        private TextBox infoText5;
        private TextBox infoText3;
        private TextBox textBoxSpecialityAnimationInput;
        private TextBox textBoxSideInput;
        private TextBox textBoxSpecialtyCameraInput;
        private TextBox textBoxParticipantNameInput;
        private TextBox textBoxEmoteTypeInput;
        private TextBox textBoxLineInput;
        private TextBox textBoxConversationSummaryInput;
        private Button buttonSave;
        private Button buttonOpenViewer;
        private SaveFileDialog saveFileDialog;
        private FormViewer viewerForm;
    }
}