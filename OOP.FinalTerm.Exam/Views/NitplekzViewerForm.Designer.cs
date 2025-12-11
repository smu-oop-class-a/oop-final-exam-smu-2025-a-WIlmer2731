namespace OOP.FinalTerm.Exam
{
    partial class NitplekzViewerForm
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
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            panel3 = new Panel();
            btnSettings = new Button();
            pictureBox1 = new PictureBox();
            movieListPanel = new FlowLayoutPanel();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 20, 20);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(192, 450);
            panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel3, 0, 2);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.3786411F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.62136F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(192, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = Color.FromArgb(20, 20, 20);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 54);
            panel2.Name = "panel2";
            panel2.Size = new Size(186, 355);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(20, 20, 20);
            panel3.Controls.Add(btnSettings);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 415);
            panel3.Name = "panel3";
            panel3.Size = new Size(186, 32);
            panel3.TabIndex = 1;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(20, 20, 20);
            btnSettings.Dock = DockStyle.Bottom;
            btnSettings.FlatAppearance.BorderColor = Color.FromArgb(221, 0, 0);
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(0, 0);
            btnSettings.Margin = new Padding(3, 3, 3, 20);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(186, 32);
            btnSettings.TabIndex = 9;
            btnSettings.Text = "⚙️";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.Nitplekz;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(186, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // movieListPanel
            // 
            movieListPanel.AutoScroll = true;
            movieListPanel.BackColor = Color.FromArgb(30, 30, 30);
            movieListPanel.Dock = DockStyle.Fill;
            movieListPanel.Location = new Point(192, 0);
            movieListPanel.Name = "movieListPanel";
            movieListPanel.Padding = new Padding(15);
            movieListPanel.Size = new Size(608, 450);
            movieListPanel.TabIndex = 2;
            // 
            // NitplekzViewerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(800, 450);
            Controls.Add(movieListPanel);
            Controls.Add(panel1);
            Name = "NitplekzViewerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nitplekz";
            WindowState = FormWindowState.Maximized;
            Load += NitplekzViewerForm_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel movieListPanel;
        private Panel panel2;
        private Panel panel3;
        private Button btnSettings;
        private PictureBox pictureBox1;
    }
}
