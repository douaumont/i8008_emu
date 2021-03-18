﻿
namespace i8008_emu_GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MemoryGroupBox = new System.Windows.Forms.GroupBox();
            this.InputPortsGroupBox = new System.Windows.Forms.GroupBox();
            this.InputPortSelection = new System.Windows.Forms.ComboBox();
            this.ReadFromInputPortButton = new System.Windows.Forms.Button();
            this.WriteToInputPortButton = new System.Windows.Forms.Button();
            this.InputValueForPort = new System.Windows.Forms.TextBox();
            this.OutputPortsGroupBox = new System.Windows.Forms.GroupBox();
            this.OutputPortsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.PageNumberTextBox = new System.Windows.Forms.TextBox();
            this.NextPageButton = new System.Windows.Forms.Button();
            this.PreviousPageButton = new System.Windows.Forms.Button();
            this.MemoryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.MainClock = new System.Windows.Forms.Timer(this.components);
            this.ProcessorStatusGroupBox = new System.Windows.Forms.GroupBox();
            this.StackGroupBox = new System.Windows.Forms.GroupBox();
            this.StackRichTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CyclesLabel = new System.Windows.Forms.Label();
            this.SP_Label = new System.Windows.Forms.Label();
            this.DisassembledLabel = new System.Windows.Forms.Label();
            this.PC_Label = new System.Windows.Forms.Label();
            this.HaltedLabel = new System.Windows.Forms.Label();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FlagsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RegistersRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ControlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.RunButton = new System.Windows.Forms.Button();
            this.StepButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.OpenInputBinaryFile = new System.Windows.Forms.OpenFileDialog();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.LoadMemoryButton = new System.Windows.Forms.ToolStripButton();
            this.ResetMemoryButton = new System.Windows.Forms.ToolStripButton();
            this.ResetPortsButton = new System.Windows.Forms.ToolStripButton();
            this.MemoryGroupBox.SuspendLayout();
            this.InputPortsGroupBox.SuspendLayout();
            this.OutputPortsGroupBox.SuspendLayout();
            this.ProcessorStatusGroupBox.SuspendLayout();
            this.StackGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ControlButtons.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MemoryGroupBox
            // 
            this.MemoryGroupBox.Controls.Add(this.InputPortsGroupBox);
            this.MemoryGroupBox.Controls.Add(this.OutputPortsGroupBox);
            this.MemoryGroupBox.Controls.Add(this.PageNumberTextBox);
            this.MemoryGroupBox.Controls.Add(this.NextPageButton);
            this.MemoryGroupBox.Controls.Add(this.PreviousPageButton);
            this.MemoryGroupBox.Controls.Add(this.MemoryRichTextBox);
            this.MemoryGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MemoryGroupBox.Location = new System.Drawing.Point(12, 28);
            this.MemoryGroupBox.Name = "MemoryGroupBox";
            this.MemoryGroupBox.Size = new System.Drawing.Size(388, 524);
            this.MemoryGroupBox.TabIndex = 0;
            this.MemoryGroupBox.TabStop = false;
            this.MemoryGroupBox.Text = "Memory";
            // 
            // InputPortsGroupBox
            // 
            this.InputPortsGroupBox.Controls.Add(this.InputPortSelection);
            this.InputPortsGroupBox.Controls.Add(this.ReadFromInputPortButton);
            this.InputPortsGroupBox.Controls.Add(this.WriteToInputPortButton);
            this.InputPortsGroupBox.Controls.Add(this.InputValueForPort);
            this.InputPortsGroupBox.Location = new System.Drawing.Point(6, 315);
            this.InputPortsGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InputPortsGroupBox.Name = "InputPortsGroupBox";
            this.InputPortsGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InputPortsGroupBox.Size = new System.Drawing.Size(183, 204);
            this.InputPortsGroupBox.TabIndex = 5;
            this.InputPortsGroupBox.TabStop = false;
            this.InputPortsGroupBox.Text = "Input Ports";
            // 
            // InputPortSelection
            // 
            this.InputPortSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InputPortSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputPortSelection.FormattingEnabled = true;
            this.InputPortSelection.Location = new System.Drawing.Point(4, 19);
            this.InputPortSelection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InputPortSelection.Name = "InputPortSelection";
            this.InputPortSelection.Size = new System.Drawing.Size(175, 26);
            this.InputPortSelection.TabIndex = 3;
            // 
            // ReadFromInputPortButton
            // 
            this.ReadFromInputPortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReadFromInputPortButton.Location = new System.Drawing.Point(99, 83);
            this.ReadFromInputPortButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReadFromInputPortButton.Name = "ReadFromInputPortButton";
            this.ReadFromInputPortButton.Size = new System.Drawing.Size(80, 26);
            this.ReadFromInputPortButton.TabIndex = 2;
            this.ReadFromInputPortButton.Text = "Read";
            this.ReadFromInputPortButton.UseVisualStyleBackColor = true;
            this.ReadFromInputPortButton.Click += new System.EventHandler(this.ReadFromInputPortButton_Click);
            // 
            // WriteToInputPortButton
            // 
            this.WriteToInputPortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WriteToInputPortButton.Location = new System.Drawing.Point(4, 83);
            this.WriteToInputPortButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WriteToInputPortButton.Name = "WriteToInputPortButton";
            this.WriteToInputPortButton.Size = new System.Drawing.Size(80, 26);
            this.WriteToInputPortButton.TabIndex = 1;
            this.WriteToInputPortButton.Text = "Write";
            this.WriteToInputPortButton.UseVisualStyleBackColor = true;
            this.WriteToInputPortButton.Click += new System.EventHandler(this.WriteToInputPortButton_Click);
            // 
            // InputValueForPort
            // 
            this.InputValueForPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputValueForPort.Location = new System.Drawing.Point(4, 52);
            this.InputValueForPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InputValueForPort.Name = "InputValueForPort";
            this.InputValueForPort.Size = new System.Drawing.Size(175, 24);
            this.InputValueForPort.TabIndex = 0;
            this.InputValueForPort.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InputValueForPort_KeyUp);
            // 
            // OutputPortsGroupBox
            // 
            this.OutputPortsGroupBox.Controls.Add(this.OutputPortsRichTextBox);
            this.OutputPortsGroupBox.Location = new System.Drawing.Point(200, 315);
            this.OutputPortsGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OutputPortsGroupBox.Name = "OutputPortsGroupBox";
            this.OutputPortsGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OutputPortsGroupBox.Size = new System.Drawing.Size(183, 204);
            this.OutputPortsGroupBox.TabIndex = 4;
            this.OutputPortsGroupBox.TabStop = false;
            this.OutputPortsGroupBox.Text = "Output Ports";
            // 
            // OutputPortsRichTextBox
            // 
            this.OutputPortsRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutputPortsRichTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.OutputPortsRichTextBox.Location = new System.Drawing.Point(4, 19);
            this.OutputPortsRichTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OutputPortsRichTextBox.Name = "OutputPortsRichTextBox";
            this.OutputPortsRichTextBox.ReadOnly = true;
            this.OutputPortsRichTextBox.Size = new System.Drawing.Size(177, 192);
            this.OutputPortsRichTextBox.TabIndex = 0;
            this.OutputPortsRichTextBox.Text = "";
            // 
            // PageNumberTextBox
            // 
            this.PageNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PageNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PageNumberTextBox.Location = new System.Drawing.Point(168, 279);
            this.PageNumberTextBox.Name = "PageNumberTextBox";
            this.PageNumberTextBox.Size = new System.Drawing.Size(50, 24);
            this.PageNumberTextBox.TabIndex = 3;
            this.PageNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PageNumberTextBox_KeyPress);
            // 
            // NextPageButton
            // 
            this.NextPageButton.FlatAppearance.BorderSize = 0;
            this.NextPageButton.Location = new System.Drawing.Point(222, 279);
            this.NextPageButton.Name = "NextPageButton";
            this.NextPageButton.Size = new System.Drawing.Size(40, 24);
            this.NextPageButton.TabIndex = 2;
            this.NextPageButton.Text = "→";
            this.NextPageButton.UseVisualStyleBackColor = true;
            this.NextPageButton.Click += new System.EventHandler(this.NextMemoryPageButton_Click);
            // 
            // PreviousPageButton
            // 
            this.PreviousPageButton.FlatAppearance.BorderSize = 0;
            this.PreviousPageButton.Location = new System.Drawing.Point(123, 279);
            this.PreviousPageButton.Name = "PreviousPageButton";
            this.PreviousPageButton.Size = new System.Drawing.Size(40, 24);
            this.PreviousPageButton.TabIndex = 1;
            this.PreviousPageButton.Text = "←";
            this.PreviousPageButton.UseVisualStyleBackColor = true;
            this.PreviousPageButton.Click += new System.EventHandler(this.PriviuosMemoryPageButton_Click);
            // 
            // MemoryRichTextBox
            // 
            this.MemoryRichTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MemoryRichTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MemoryRichTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MemoryRichTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MemoryRichTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.MemoryRichTextBox.Location = new System.Drawing.Point(6, 23);
            this.MemoryRichTextBox.Name = "MemoryRichTextBox";
            this.MemoryRichTextBox.ReadOnly = true;
            this.MemoryRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.MemoryRichTextBox.Size = new System.Drawing.Size(376, 247);
            this.MemoryRichTextBox.TabIndex = 0;
            this.MemoryRichTextBox.Text = "";
            // 
            // MainClock
            // 
            this.MainClock.Interval = 1;
            this.MainClock.Tick += new System.EventHandler(this.MainClock_Tick);
            // 
            // ProcessorStatusGroupBox
            // 
            this.ProcessorStatusGroupBox.Controls.Add(this.StackGroupBox);
            this.ProcessorStatusGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.ProcessorStatusGroupBox.Controls.Add(this.groupBox2);
            this.ProcessorStatusGroupBox.Controls.Add(this.groupBox1);
            this.ProcessorStatusGroupBox.Controls.Add(this.ControlButtons);
            this.ProcessorStatusGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProcessorStatusGroupBox.Location = new System.Drawing.Point(406, 28);
            this.ProcessorStatusGroupBox.Name = "ProcessorStatusGroupBox";
            this.ProcessorStatusGroupBox.Size = new System.Drawing.Size(366, 524);
            this.ProcessorStatusGroupBox.TabIndex = 1;
            this.ProcessorStatusGroupBox.TabStop = false;
            this.ProcessorStatusGroupBox.Text = "Processor";
            // 
            // StackGroupBox
            // 
            this.StackGroupBox.Controls.Add(this.StackRichTextBox);
            this.StackGroupBox.Location = new System.Drawing.Point(0, 294);
            this.StackGroupBox.Name = "StackGroupBox";
            this.StackGroupBox.Size = new System.Drawing.Size(366, 166);
            this.StackGroupBox.TabIndex = 12;
            this.StackGroupBox.TabStop = false;
            this.StackGroupBox.Text = "Stack";
            // 
            // StackRichTextBox
            // 
            this.StackRichTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.StackRichTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.StackRichTextBox.Enabled = false;
            this.StackRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StackRichTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.StackRichTextBox.Location = new System.Drawing.Point(9, 21);
            this.StackRichTextBox.Name = "StackRichTextBox";
            this.StackRichTextBox.ReadOnly = true;
            this.StackRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.StackRichTextBox.Size = new System.Drawing.Size(353, 136);
            this.StackRichTextBox.TabIndex = 1;
            this.StackRichTextBox.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.CyclesLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SP_Label, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DisassembledLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.PC_Label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.HaltedLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.FrequencyLabel, 1, 2);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 228);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(366, 62);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // CyclesLabel
            // 
            this.CyclesLabel.AutoSize = true;
            this.CyclesLabel.Location = new System.Drawing.Point(4, 1);
            this.CyclesLabel.Name = "CyclesLabel";
            this.CyclesLabel.Size = new System.Drawing.Size(52, 16);
            this.CyclesLabel.TabIndex = 7;
            this.CyclesLabel.Text = "Cycles:";
            // 
            // SP_Label
            // 
            this.SP_Label.AutoSize = true;
            this.SP_Label.Location = new System.Drawing.Point(186, 21);
            this.SP_Label.Name = "SP_Label";
            this.SP_Label.Size = new System.Drawing.Size(26, 16);
            this.SP_Label.TabIndex = 10;
            this.SP_Label.Text = "SP";
            // 
            // DisassembledLabel
            // 
            this.DisassembledLabel.AutoSize = true;
            this.DisassembledLabel.Location = new System.Drawing.Point(186, 1);
            this.DisassembledLabel.Name = "DisassembledLabel";
            this.DisassembledLabel.Size = new System.Drawing.Size(99, 16);
            this.DisassembledLabel.TabIndex = 8;
            this.DisassembledLabel.Text = "Disassembled:";
            // 
            // PC_Label
            // 
            this.PC_Label.AutoSize = true;
            this.PC_Label.Location = new System.Drawing.Point(4, 21);
            this.PC_Label.Name = "PC_Label";
            this.PC_Label.Size = new System.Drawing.Size(26, 16);
            this.PC_Label.TabIndex = 9;
            this.PC_Label.Text = "PC";
            // 
            // HaltedLabel
            // 
            this.HaltedLabel.AutoSize = true;
            this.HaltedLabel.Location = new System.Drawing.Point(4, 41);
            this.HaltedLabel.Name = "HaltedLabel";
            this.HaltedLabel.Size = new System.Drawing.Size(54, 16);
            this.HaltedLabel.TabIndex = 11;
            this.HaltedLabel.Text = "Halted: ";
            this.HaltedLabel.TextChanged += new System.EventHandler(this.HaltedLabel_TextChanged);
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.AutoSize = true;
            this.FrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FrequencyLabel.Location = new System.Drawing.Point(186, 41);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(72, 16);
            this.FrequencyLabel.TabIndex = 12;
            this.FrequencyLabel.Text = "Frequency";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FlagsRichTextBox);
            this.groupBox2.Location = new System.Drawing.Point(0, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 63);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Flags";
            // 
            // FlagsRichTextBox
            // 
            this.FlagsRichTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FlagsRichTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.FlagsRichTextBox.Enabled = false;
            this.FlagsRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FlagsRichTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.FlagsRichTextBox.Location = new System.Drawing.Point(6, 21);
            this.FlagsRichTextBox.Name = "FlagsRichTextBox";
            this.FlagsRichTextBox.ReadOnly = true;
            this.FlagsRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.FlagsRichTextBox.Size = new System.Drawing.Size(355, 36);
            this.FlagsRichTextBox.TabIndex = 1;
            this.FlagsRichTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RegistersRichTextBox);
            this.groupBox1.Location = new System.Drawing.Point(0, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 79);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registers";
            // 
            // RegistersRichTextBox
            // 
            this.RegistersRichTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RegistersRichTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.RegistersRichTextBox.Enabled = false;
            this.RegistersRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistersRichTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.RegistersRichTextBox.Location = new System.Drawing.Point(5, 21);
            this.RegistersRichTextBox.Name = "RegistersRichTextBox";
            this.RegistersRichTextBox.ReadOnly = true;
            this.RegistersRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.RegistersRichTextBox.Size = new System.Drawing.Size(357, 53);
            this.RegistersRichTextBox.TabIndex = 0;
            this.RegistersRichTextBox.Text = "";
            // 
            // ControlButtons
            // 
            this.ControlButtons.ColumnCount = 4;
            this.ControlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ControlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ControlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ControlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ControlButtons.Controls.Add(this.RunButton, 0, 0);
            this.ControlButtons.Controls.Add(this.StepButton, 3, 0);
            this.ControlButtons.Controls.Add(this.StopButton, 1, 0);
            this.ControlButtons.Controls.Add(this.ResetButton, 2, 0);
            this.ControlButtons.Location = new System.Drawing.Point(6, 21);
            this.ControlButtons.Name = "ControlButtons";
            this.ControlButtons.RowCount = 1;
            this.ControlButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ControlButtons.Size = new System.Drawing.Size(354, 47);
            this.ControlButtons.TabIndex = 4;
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(3, 3);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(82, 40);
            this.RunButton.TabIndex = 0;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // StepButton
            // 
            this.StepButton.Location = new System.Drawing.Point(267, 3);
            this.StepButton.Name = "StepButton";
            this.StepButton.Size = new System.Drawing.Size(84, 40);
            this.StepButton.TabIndex = 3;
            this.StepButton.Text = "Step";
            this.StepButton.UseVisualStyleBackColor = true;
            this.StepButton.Click += new System.EventHandler(this.StepButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(91, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(82, 40);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(179, 3);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(82, 40);
            this.ResetButton.TabIndex = 2;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // OpenInputBinaryFile
            // 
            this.OpenInputBinaryFile.Filter = "Binary Files|*.bin|All files|*.*";
            // 
            // ToolStrip
            // 
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadMemoryButton,
            this.ResetMemoryButton,
            this.ResetPortsButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolStrip.Size = new System.Drawing.Size(784, 25);
            this.ToolStrip.TabIndex = 2;
            this.ToolStrip.Text = "ToolStrip";
            // 
            // LoadMemoryButton
            // 
            this.LoadMemoryButton.BackColor = System.Drawing.SystemColors.Control;
            this.LoadMemoryButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadMemoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadMemoryButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadMemoryButton.Image")));
            this.LoadMemoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadMemoryButton.Name = "LoadMemoryButton";
            this.LoadMemoryButton.Size = new System.Drawing.Size(87, 22);
            this.LoadMemoryButton.Text = "Load Memory";
            this.LoadMemoryButton.ToolTipText = "Load Memory";
            this.LoadMemoryButton.Click += new System.EventHandler(this.LoadMemoryButton_Click);
            // 
            // ResetMemoryButton
            // 
            this.ResetMemoryButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ResetMemoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetMemoryButton.Image = ((System.Drawing.Image)(resources.GetObject("ResetMemoryButton.Image")));
            this.ResetMemoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResetMemoryButton.Name = "ResetMemoryButton";
            this.ResetMemoryButton.Size = new System.Drawing.Size(91, 22);
            this.ResetMemoryButton.Text = "Reset Memory";
            this.ResetMemoryButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.ResetMemoryButton.Click += new System.EventHandler(this.ResetMemoryButton_Click);
            // 
            // ResetPortsButton
            // 
            this.ResetPortsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ResetPortsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetPortsButton.Image = ((System.Drawing.Image)(resources.GetObject("ResetPortsButton.Image")));
            this.ResetPortsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResetPortsButton.Name = "ResetPortsButton";
            this.ResetPortsButton.Size = new System.Drawing.Size(74, 22);
            this.ResetPortsButton.Text = "Reset Ports";
            this.ResetPortsButton.Click += new System.EventHandler(this.ResetPortsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.ProcessorStatusGroupBox);
            this.Controls.Add(this.MemoryGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intel 8008 Emulator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MemoryGroupBox.ResumeLayout(false);
            this.MemoryGroupBox.PerformLayout();
            this.InputPortsGroupBox.ResumeLayout(false);
            this.InputPortsGroupBox.PerformLayout();
            this.OutputPortsGroupBox.ResumeLayout(false);
            this.ProcessorStatusGroupBox.ResumeLayout(false);
            this.StackGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ControlButtons.ResumeLayout(false);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox MemoryGroupBox;
        private System.Windows.Forms.RichTextBox MemoryRichTextBox;
        private System.Windows.Forms.TextBox PageNumberTextBox;
        private System.Windows.Forms.Button NextPageButton;
        private System.Windows.Forms.Button PreviousPageButton;
        private System.Windows.Forms.Timer MainClock;
        private System.Windows.Forms.GroupBox ProcessorStatusGroupBox;
        private System.Windows.Forms.OpenFileDialog OpenInputBinaryFile;
        private System.Windows.Forms.TableLayoutPanel ControlButtons;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button StepButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton LoadMemoryButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox RegistersRichTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox FlagsRichTextBox;
        private System.Windows.Forms.Label CyclesLabel;
        private System.Windows.Forms.Label DisassembledLabel;
        private System.Windows.Forms.Label PC_Label;
        private System.Windows.Forms.Label SP_Label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label HaltedLabel;
        private System.Windows.Forms.GroupBox StackGroupBox;
        private System.Windows.Forms.RichTextBox StackRichTextBox;
        private System.Windows.Forms.Label FrequencyLabel;
        private System.Windows.Forms.ToolStripButton ResetMemoryButton;
        private System.Windows.Forms.GroupBox InputPortsGroupBox;
        private System.Windows.Forms.GroupBox OutputPortsGroupBox;
        private System.Windows.Forms.RichTextBox OutputPortsRichTextBox;
        private System.Windows.Forms.Button ReadFromInputPortButton;
        private System.Windows.Forms.Button WriteToInputPortButton;
        private System.Windows.Forms.ComboBox InputPortSelection;
        private System.Windows.Forms.TextBox InputValueForPort;
        private System.Windows.Forms.ToolStripButton ResetPortsButton;
    }
}

