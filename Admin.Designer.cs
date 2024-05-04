namespace ProcessAdmin_19._08
{
    partial class Admin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ExistingProcesses = new ListBox();
            ProcessesWithRules = new ListBox();
            Block_btn = new Button();
            Unblock_btn = new Button();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            ProcessName_tb = new TextBox();
            Run_btn = new Button();
            TimeLeft_tb = new TextBox();
            TimePicker_dtp = new DateTimePicker();
            ProcessName_lb = new Label();
            SuspendLayout();
            // 
            // ExistingProcesses
            // 
            ExistingProcesses.FormattingEnabled = true;
            ExistingProcesses.ItemHeight = 20;
            ExistingProcesses.Location = new Point(12, 16);
            ExistingProcesses.Margin = new Padding(3, 4, 3, 4);
            ExistingProcesses.Name = "ExistingProcesses";
            ExistingProcesses.Size = new Size(277, 564);
            ExistingProcesses.TabIndex = 0;
            // 
            // ProcessesWithRules
            // 
            ProcessesWithRules.FormattingEnabled = true;
            ProcessesWithRules.ItemHeight = 20;
            ProcessesWithRules.Location = new Point(494, 19);
            ProcessesWithRules.Margin = new Padding(3, 4, 3, 4);
            ProcessesWithRules.Name = "ProcessesWithRules";
            ProcessesWithRules.Size = new Size(277, 564);
            ProcessesWithRules.TabIndex = 1;
            ProcessesWithRules.SelectedIndexChanged += AllowedTimeSelectedChanged;
            // 
            // Block_btn
            // 
            Block_btn.Location = new Point(298, 16);
            Block_btn.Margin = new Padding(3, 4, 3, 4);
            Block_btn.Name = "Block_btn";
            Block_btn.Size = new Size(189, 59);
            Block_btn.TabIndex = 2;
            Block_btn.Text = "Block process";
            Block_btn.UseVisualStyleBackColor = true;
            Block_btn.Click += BlockProcessClick;
            // 
            // Unblock_btn
            // 
            Unblock_btn.Location = new Point(297, 394);
            Unblock_btn.Margin = new Padding(3, 4, 3, 4);
            Unblock_btn.Name = "Unblock_btn";
            Unblock_btn.Size = new Size(189, 59);
            Unblock_btn.TabIndex = 3;
            Unblock_btn.Text = "Remove rules";
            Unblock_btn.UseVisualStyleBackColor = true;
            Unblock_btn.Click += UnblockProcessClick;
            // 
            // button1
            // 
            button1.Location = new Point(298, 83);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(189, 59);
            button1.TabIndex = 4;
            button1.Text = "Block process exe";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BlockProcessExeClick;
            // 
            // button2
            // 
            button2.Location = new Point(297, 327);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(189, 59);
            button2.TabIndex = 6;
            button2.Text = "Set boundaries";
            button2.UseVisualStyleBackColor = true;
            button2.Click += SetBoundariesClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(298, 270);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 10;
            label2.Text = "Blocked until";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(298, 203);
            label3.Name = "label3";
            label3.Size = new Size(148, 20);
            label3.TabIndex = 12;
            label3.Text = "Work time left today:";
            // 
            // ProcessName_tb
            // 
            ProcessName_tb.Location = new Point(297, 169);
            ProcessName_tb.Margin = new Padding(3, 4, 3, 4);
            ProcessName_tb.Name = "ProcessName_tb";
            ProcessName_tb.ReadOnly = true;
            ProcessName_tb.Size = new Size(114, 27);
            ProcessName_tb.TabIndex = 13;
            // 
            // Run_btn
            // 
            Run_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            Run_btn.Location = new Point(297, 480);
            Run_btn.Margin = new Padding(3, 4, 3, 4);
            Run_btn.Name = "Run_btn";
            Run_btn.Size = new Size(189, 97);
            Run_btn.TabIndex = 15;
            Run_btn.Text = "Run in background";
            Run_btn.UseVisualStyleBackColor = true;
            Run_btn.Click += RunClick;
            // 
            // TimeLeft_tb
            // 
            TimeLeft_tb.Location = new Point(298, 227);
            TimeLeft_tb.Margin = new Padding(3, 4, 3, 4);
            TimeLeft_tb.Name = "TimeLeft_tb";
            TimeLeft_tb.ReadOnly = true;
            TimeLeft_tb.Size = new Size(114, 27);
            TimeLeft_tb.TabIndex = 17;
            // 
            // TimePicker_dtp
            // 
            TimePicker_dtp.Format = DateTimePickerFormat.Time;
            TimePicker_dtp.Location = new Point(298, 293);
            TimePicker_dtp.Name = "TimePicker_dtp";
            TimePicker_dtp.ShowUpDown = true;
            TimePicker_dtp.Size = new Size(189, 27);
            TimePicker_dtp.TabIndex = 18;
            TimePicker_dtp.Value = new DateTime(2024, 5, 4, 0, 0, 0, 0);
            // 
            // ProcessName_lb
            // 
            ProcessName_lb.AutoSize = true;
            ProcessName_lb.Location = new Point(297, 145);
            ProcessName_lb.Name = "ProcessName_lb";
            ProcessName_lb.Size = new Size(102, 20);
            ProcessName_lb.TabIndex = 14;
            ProcessName_lb.Text = "Process name:";
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 600);
            Controls.Add(TimePicker_dtp);
            Controls.Add(TimeLeft_tb);
            Controls.Add(Run_btn);
            Controls.Add(ProcessName_lb);
            Controls.Add(ProcessName_tb);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Unblock_btn);
            Controls.Add(Block_btn);
            Controls.Add(ProcessesWithRules);
            Controls.Add(ExistingProcesses);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Admin";
            Text = "Admin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ExistingProcesses;
        private ListBox ProcessesWithRules;
        private Button Block_btn;
        private Button Unblock_btn;
        private Button button1;
        private Button button2;
        private Label label2;
        private Label label3;
        private TextBox ProcessName_tb;
        private Button Run_btn;
        private TextBox TimeLeft_tb;
        private DateTimePicker TimePicker_dtp;
        private Label ProcessName_lb;
    }
}