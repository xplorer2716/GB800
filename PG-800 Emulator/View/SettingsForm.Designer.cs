
namespace MidiApp.GB800.View
{
    partial class SettingsForm
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.gbCHORUS = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AutomationInputCombobox = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.SynthOutputComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LvAutomation = new MidiApp.UIControls.ListViewEx();
            this.Parameter = new System.Windows.Forms.ColumnHeader();
            this.ControlChange = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStripAutomation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportAsTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboControlChange = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lbMIDIChannel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rdSynthTypeJX8P = new System.Windows.Forms.RadioButton();
            this.rdSynthTypeJX10 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSysexDelay = new System.Windows.Forms.Label();
            this.nUpDownDelay = new System.Windows.Forms.NumericUpDown();
            this.tooltipATP = new System.Windows.Forms.ToolTip(this.components);
            this.tooltipITP = new System.Windows.Forms.ToolTip(this.components);
            this.tooltipDelay = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipAutomationInput = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSynthOutput = new System.Windows.Forms.ToolTip(this.components);
            this.gbCHORUS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStripAutomation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.AccessibleDescription = "The okay button.";
            this.okButton.AccessibleName = "Okay";
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(553, 420);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AccessibleDescription = "The cancel button";
            this.cancelButton.AccessibleName = "Cancel";
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(634, 420);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // gbCHORUS
            // 
            this.gbCHORUS.Controls.Add(this.numericUpDown1);
            this.gbCHORUS.Controls.Add(this.label6);
            this.gbCHORUS.Controls.Add(this.lbMIDIChannel);
            this.gbCHORUS.Controls.Add(this.label5);
            this.gbCHORUS.Controls.Add(this.pictureBox1);
            this.gbCHORUS.Controls.Add(this.AutomationInputCombobox);
            this.gbCHORUS.Controls.Add(this.label49);
            this.gbCHORUS.Controls.Add(this.SynthOutputComboBox);
            this.gbCHORUS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCHORUS.ForeColor = System.Drawing.Color.White;
            this.gbCHORUS.Location = new System.Drawing.Point(8, 12);
            this.gbCHORUS.Name = "gbCHORUS";
            this.gbCHORUS.Size = new System.Drawing.Size(701, 140);
            this.gbCHORUS.TabIndex = 10;
            this.gbCHORUS.TabStop = false;
            this.gbCHORUS.Tag = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.label6.Location = new System.Drawing.Point(520, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "MIDI OUT:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.label5.Location = new System.Drawing.Point(9, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "MIDI IN (optional):";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(183, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 104);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // AutomationInputCombobox
            // 
            this.AutomationInputCombobox.AccessibleDescription = "Choose the MIDI input device to use for receiving CC messages (Midi channel is 1)" +
                "";
            this.AutomationInputCombobox.AccessibleName = "MIDI Device Input";
            this.AutomationInputCombobox.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.AutomationInputCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AutomationInputCombobox.FormattingEnabled = true;
            this.AutomationInputCombobox.Location = new System.Drawing.Point(12, 56);
            this.AutomationInputCombobox.Name = "AutomationInputCombobox";
            this.AutomationInputCombobox.Size = new System.Drawing.Size(165, 21);
            this.AutomationInputCombobox.TabIndex = 0;
            this.toolTipAutomationInput.SetToolTip(this.AutomationInputCombobox, "Choose the MIDI input device to use for receiving CC messages (Midi channel is 1)" +
                    "");
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(148)))), ((int)(((byte)(246)))));
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Black;
            this.label49.Location = new System.Drawing.Point(6, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(103, 18);
            this.label49.TabIndex = 21;
            this.label49.Text = "MIDI DEVICES";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SynthOutputComboBox
            // 
            this.SynthOutputComboBox.AccessibleDescription = "Choose the MIDI output device to use for sending SysEx messages (where your synth" +
                " is connected).";
            this.SynthOutputComboBox.AccessibleName = "MIDI Device Output";
            this.SynthOutputComboBox.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.SynthOutputComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(83)))), ((int)(((byte)(82)))));
            this.SynthOutputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SynthOutputComboBox.FormattingEnabled = true;
            this.SynthOutputComboBox.Location = new System.Drawing.Point(523, 56);
            this.SynthOutputComboBox.Name = "SynthOutputComboBox";
            this.SynthOutputComboBox.Size = new System.Drawing.Size(165, 21);
            this.SynthOutputComboBox.TabIndex = 1;
            this.toolTipSynthOutput.SetToolTip(this.SynthOutputComboBox, "Choose the MIDI output device to use for sending SysEx messages (where your synth" +
                    " is connected).s");
            this.SynthOutputComboBox.ValueMember = global::MidiApp.GB800.Properties.Settings.Default.SynthOutputDeviceName;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(189)))), ((int)(((byte)(41)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "AUTOMATION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LvAutomation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboControlChange);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(8, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 186);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.label2.Location = new System.Drawing.Point(586, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "(right-click to export)";
            // 
            // LvAutomation
            // 
            this.LvAutomation.AllowColumnReorder = true;
            this.LvAutomation.AutoArrange = false;
            this.LvAutomation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Parameter,
            this.ControlChange});
            this.LvAutomation.ContextMenuStrip = this.contextMenuStripAutomation;
            this.LvAutomation.DoubleClickActivation = false;
            this.LvAutomation.FullRowSelect = true;
            this.LvAutomation.GridLines = true;
            this.LvAutomation.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LvAutomation.LabelWrap = false;
            this.LvAutomation.Location = new System.Drawing.Point(12, 33);
            this.LvAutomation.MultiSelect = false;
            this.LvAutomation.Name = "LvAutomation";
            this.LvAutomation.ShowGroups = false;
            this.LvAutomation.Size = new System.Drawing.Size(676, 147);
            this.LvAutomation.TabIndex = 0;
            this.LvAutomation.UseCompatibleStateImageBehavior = false;
            this.LvAutomation.View = System.Windows.Forms.View.Details;
            this.LvAutomation.SubItemClicked += new MidiApp.UIControls.SubItemEventHandler(this.LvAutomation_SubItemClicked);
            // 
            // Parameter
            // 
            this.Parameter.Text = "Parameter";
            this.Parameter.Width = 120;
            // 
            // ControlChange
            // 
            this.ControlChange.Text = "Control change number";
            this.ControlChange.Width = 540;
            // 
            // contextMenuStripAutomation
            // 
            this.contextMenuStripAutomation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAsTextFileToolStripMenuItem});
            this.contextMenuStripAutomation.Name = "contextMenuStripAutomation";
            this.contextMenuStripAutomation.Size = new System.Drawing.Size(190, 26);
            // 
            // exportAsTextFileToolStripMenuItem
            // 
            this.exportAsTextFileToolStripMenuItem.Name = "exportAsTextFileToolStripMenuItem";
            this.exportAsTextFileToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.exportAsTextFileToolStripMenuItem.Text = "Export as HTML file...";
            this.exportAsTextFileToolStripMenuItem.Click += new System.EventHandler(this.exportAsTextFileToolStripMenuIte_Click);
            // 
            // comboControlChange
            // 
            this.comboControlChange.DropDownHeight = 200;
            this.comboControlChange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboControlChange.IntegralHeight = false;
            this.comboControlChange.Location = new System.Drawing.Point(183, 9);
            this.comboControlChange.Name = "comboControlChange";
            this.comboControlChange.Size = new System.Drawing.Size(175, 21);
            this.comboControlChange.TabIndex = 26;
            this.comboControlChange.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rdSynthTypeJX8P);
            this.groupBox2.Controls.Add(this.rdSynthTypeJX10);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbSysexDelay);
            this.groupBox2.Controls.Add(this.nUpDownDelay);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(8, 350);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(701, 60);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(621, 90);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown1.TabIndex = 32;
            this.tooltipDelay.SetToolTip(this.numericUpDown1, "Set the delay in ms between each sysex message sent to the synthetizer");
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbMIDIChannel
            // 
            this.lbMIDIChannel.AutoSize = true;
            this.lbMIDIChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMIDIChannel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.lbMIDIChannel.Location = new System.Drawing.Point(520, 97);
            this.lbMIDIChannel.Name = "lbMIDIChannel";
            this.lbMIDIChannel.Size = new System.Drawing.Size(101, 13);
            this.lbMIDIChannel.TabIndex = 31;
            this.lbMIDIChannel.Text = "MIDI OUT Channel:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(83)))), ((int)(((byte)(82)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "SYSEX";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdSynthTypeJX8P
            // 
            this.rdSynthTypeJX8P.AutoSize = true;
            this.rdSynthTypeJX8P.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSynthTypeJX8P.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.rdSynthTypeJX8P.Location = new System.Drawing.Point(204, 25);
            this.rdSynthTypeJX8P.Name = "rdSynthTypeJX8P";
            this.rdSynthTypeJX8P.Size = new System.Drawing.Size(53, 17);
            this.rdSynthTypeJX8P.TabIndex = 27;
            this.rdSynthTypeJX8P.Text = "JX-8P";
            this.rdSynthTypeJX8P.UseVisualStyleBackColor = true;
            // 
            // rdSynthTypeJX10
            // 
            this.rdSynthTypeJX10.AutoSize = true;
            this.rdSynthTypeJX10.Checked = true;
            this.rdSynthTypeJX10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSynthTypeJX10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.rdSynthTypeJX10.Location = new System.Drawing.Point(97, 25);
            this.rdSynthTypeJX10.Name = "rdSynthTypeJX10";
            this.rdSynthTypeJX10.Size = new System.Drawing.Size(101, 17);
            this.rdSynthTypeJX10.TabIndex = 26;
            this.rdSynthTypeJX10.TabStop = true;
            this.rdSynthTypeJX10.Text = "JX-10 / MKS-70";
            this.rdSynthTypeJX10.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Synthesizer type:";
            // 
            // lbSysexDelay
            // 
            this.lbSysexDelay.AutoSize = true;
            this.lbSysexDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSysexDelay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.lbSysexDelay.Location = new System.Drawing.Point(529, 27);
            this.lbSysexDelay.Name = "lbSysexDelay";
            this.lbSysexDelay.Size = new System.Drawing.Size(91, 13);
            this.lbSysexDelay.TabIndex = 28;
            this.lbSysexDelay.Text = "SysEx Delay (ms):";
            // 
            // nUpDownDelay
            // 
            this.nUpDownDelay.Location = new System.Drawing.Point(621, 25);
            this.nUpDownDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUpDownDelay.Name = "nUpDownDelay";
            this.nUpDownDelay.Size = new System.Drawing.Size(67, 20);
            this.nUpDownDelay.TabIndex = 27;
            this.tooltipDelay.SetToolTip(this.nUpDownDelay, "Set the delay in ms between each sysex message sent to the synthetizer");
            // 
            // tooltipATP
            // 
            this.tooltipATP.AutoPopDelay = 10000;
            this.tooltipATP.InitialDelay = 500;
            this.tooltipATP.ReshowDelay = 100;
            // 
            // tooltipITP
            // 
            this.tooltipITP.AutoPopDelay = 10000;
            this.tooltipITP.InitialDelay = 500;
            this.tooltipITP.ReshowDelay = 100;
            // 
            // tooltipDelay
            // 
            this.tooltipDelay.AutoPopDelay = 10000;
            this.tooltipDelay.InitialDelay = 500;
            this.tooltipDelay.ReshowDelay = 100;
            // 
            // toolTipAutomationInput
            // 
            this.toolTipAutomationInput.AutoPopDelay = 10000;
            this.toolTipAutomationInput.InitialDelay = 500;
            this.toolTipAutomationInput.ReshowDelay = 100;
            // 
            // toolTipSynthOutput
            // 
            this.toolTipSynthOutput.AutoPopDelay = 10000;
            this.toolTipSynthOutput.InitialDelay = 500;
            this.toolTipSynthOutput.ReshowDelay = 100;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(719, 455);
            this.Controls.Add(this.gbCHORUS);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.gbCHORUS.ResumeLayout(false);
            this.gbCHORUS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStripAutomation.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownDelay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox AutomationInputCombobox;
        private System.Windows.Forms.ComboBox SynthOutputComboBox;
        private System.Windows.Forms.GroupBox gbCHORUS;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private MidiApp.UIControls.ListViewEx LvAutomation;
        private System.Windows.Forms.ColumnHeader Parameter;
        private System.Windows.Forms.ColumnHeader ControlChange;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip tooltipATP;
        private System.Windows.Forms.ToolTip tooltipITP;
        private System.Windows.Forms.Label lbSysexDelay;
        private System.Windows.Forms.NumericUpDown nUpDownDelay;
        private System.Windows.Forms.ToolTip tooltipDelay;
        private System.Windows.Forms.ComboBox comboControlChange;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAutomation;
        private System.Windows.Forms.ToolStripMenuItem exportAsTextFileToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTipAutomationInput;
        private System.Windows.Forms.ToolTip toolTipSynthOutput;
        private System.Windows.Forms.RadioButton rdSynthTypeJX8P;
        private System.Windows.Forms.RadioButton rdSynthTypeJX10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lbMIDIChannel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}
