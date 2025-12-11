using OOP.FinalTerm.Exam.Utils;

namespace OOP.FinalTerm.Exam
{
    partial class MovieForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            lblTitle = new Label();
            panel2 = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panel3 = new Panel();
            btnSelectImage = new Button();
            cmbGenre = new ComboBox();
            dtpDateReleased = new DateTimePicker();
            numRatings = new NumericUpDown();
            txtCover = new TextBox();
            txtDescription = new TextBox();
            txtMovieTitle = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRatings).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 20, 20);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 50);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(102, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add Movie";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(20, 20, 20);
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnSave);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 470);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 60);
            panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(60, 60, 60);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(270, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(221, 0, 0);
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(130, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(30, 30, 30);
            panel3.Controls.Add(btnSelectImage);
            panel3.Controls.Add(cmbGenre);
            panel3.Controls.Add(dtpDateReleased);
            panel3.Controls.Add(numRatings);
            panel3.Controls.Add(txtCover);
            panel3.Controls.Add(txtDescription);
            panel3.Controls.Add(txtMovieTitle);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 50);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(15);
            panel3.Size = new Size(500, 420);
            panel3.TabIndex = 2;
            // 
            // btnSelectImage
            // 
            btnSelectImage.BackColor = Color.FromArgb(100, 100, 100);
            btnSelectImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSelectImage.ForeColor = Color.White;
            btnSelectImage.Location = new Point(400, 200);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(85, 23);
            btnSelectImage.TabIndex = 12;
            btnSelectImage.Text = "Browse...";
            btnSelectImage.UseVisualStyleBackColor = false;
            btnSelectImage.FlatStyle = FlatStyle.Flat;
            btnSelectImage.FlatAppearance.BorderSize = 0;
            btnSelectImage.Click += BtnSelectImage_Click;
            // 
            // cmbGenre
            // 
            cmbGenre.BackColor = Color.FromArgb(40, 40, 40);
            cmbGenre.ForeColor = Color.White;
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Items.AddRange(GenreHelper.GetGenresAsObjects());
            cmbGenre.Location = new Point(15, 330);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(470, 23);
            cmbGenre.TabIndex = 11;
            cmbGenre.FlatStyle = FlatStyle.Flat;
            // 
            // dtpDateReleased
            // 
            dtpDateReleased.BackColor = Color.FromArgb(40, 40, 40);
            dtpDateReleased.ForeColor = Color.White;
            dtpDateReleased.Location = new Point(15, 275);
            dtpDateReleased.Name = "dtpDateReleased";
            dtpDateReleased.Size = new Size(470, 23);
            dtpDateReleased.TabIndex = 10;
            // 
            // numRatings
            // 
            numRatings.BackColor = Color.FromArgb(40, 40, 40);
            numRatings.ForeColor = Color.White;
            numRatings.Location = new Point(15, 385);
            numRatings.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numRatings.Name = "numRatings";
            numRatings.Size = new Size(470, 23);
            numRatings.TabIndex = 9;
            // 
            // txtCover
            // 
            txtCover.BackColor = Color.FromArgb(40, 40, 40);
            txtCover.ForeColor = Color.White;
            txtCover.Location = new Point(15, 200);
            txtCover.Name = "txtCover";
            txtCover.PlaceholderText = "Image file path (will be converted to base64)";
            txtCover.ReadOnly = true;
            txtCover.Size = new Size(380, 23);
            txtCover.TabIndex = 8;
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.FromArgb(40, 40, 40);
            txtDescription.ForeColor = Color.White;
            txtDescription.Location = new Point(15, 120);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Movie description";
            txtDescription.Size = new Size(470, 60);
            txtDescription.TabIndex = 7;
            // 
            // txtMovieTitle
            // 
            txtMovieTitle.BackColor = Color.FromArgb(40, 40, 40);
            txtMovieTitle.ForeColor = Color.White;
            txtMovieTitle.Location = new Point(15, 40);
            txtMovieTitle.Name = "txtMovieTitle";
            txtMovieTitle.PlaceholderText = "Enter movie title";
            txtMovieTitle.Size = new Size(470, 23);
            txtMovieTitle.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(15, 367);
            label6.Name = "label6";
            label6.Size = new Size(60, 19);
            label6.TabIndex = 5;
            label6.Text = "Ratings";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(15, 312);
            label5.Name = "label5";
            label5.Size = new Size(52, 19);
            label5.TabIndex = 4;
            label5.Text = "Genre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(15, 257);
            label4.Name = "label4";
            label4.Size = new Size(98, 19);
            label4.TabIndex = 3;
            label4.Text = "Date Released";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(15, 182);
            label3.Name = "label3";
            label3.Size = new Size(50, 19);
            label3.TabIndex = 2;
            label3.Text = "Cover";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(15, 102);
            label2.Name = "label2";
            label2.Size = new Size(85, 19);
            label2.TabIndex = 1;
            label2.Text = "Description";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 22);
            label1.Name = "label1";
            label1.Size = new Size(36, 19);
            label1.TabIndex = 0;
            label1.Text = "Title";
            // 
            // MovieForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(500, 530);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MovieForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add/Edit Movie";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRatings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTitle;
        private Panel panel2;
        private Button btnCancel;
        private Button btnSave;
        private Panel panel3;
        private ComboBox cmbGenre;
        private DateTimePicker dtpDateReleased;
        private NumericUpDown numRatings;
        private TextBox txtCover;
        private TextBox txtDescription;
        private TextBox txtMovieTitle;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnSelectImage;
    }
}