namespace OOP.FinalTerm.Exam
{
    partial class MovieControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method or the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pBoxMovie = new PictureBox();
            lblMovieTitle = new Label();
            lblMovieYear = new Label();
            lblRating = new Label();
            ((System.ComponentModel.ISupportInitialize)pBoxMovie).BeginInit();
            SuspendLayout();
            // 
            // pBoxMovie
            // 
            pBoxMovie.Dock = DockStyle.Top;
            pBoxMovie.Location = new Point(0, 0);
            pBoxMovie.Name = "pBoxMovie";
            pBoxMovie.Size = new Size(250, 209);
            pBoxMovie.TabIndex = 0;
            pBoxMovie.TabStop = false;
            pBoxMovie.SizeMode = PictureBoxSizeMode.StretchImage;
            // 
            // lblMovieTitle
            // 
            lblMovieTitle.Dock = DockStyle.Top;
            lblMovieTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMovieTitle.Location = new Point(0, 209);
            lblMovieTitle.Name = "lblMovieTitle";
            lblMovieTitle.Size = new Size(250, 30);
            lblMovieTitle.TabIndex = 1;
            lblMovieTitle.Text = "Captain America";
            lblMovieTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblMovieTitle.ForeColor = Color.White;
            lblMovieTitle.BackColor = Color.FromArgb(40, 40, 40);
            // 
            // lblMovieYear
            // 
            lblMovieYear.Dock = DockStyle.Top;
            lblMovieYear.Font = new Font("Segoe UI", 10F, (FontStyle)GraphicsUnit.Point, 0);
            lblMovieYear.Location = new Point(0, 239);
            lblMovieYear.Name = "lblMovieYear";
            lblMovieYear.Size = new Size(250, 17);
            lblMovieYear.TabIndex = 2;
            lblMovieYear.Text = "2016";
            lblMovieYear.TextAlign = ContentAlignment.MiddleCenter;
            lblMovieYear.ForeColor = Color.FromArgb(200, 200, 200);
            lblMovieYear.BackColor = Color.FromArgb(40, 40, 40);
            // 
            // lblRating
            // 
            lblRating.Dock = DockStyle.Top;
            lblRating.Font = new Font("Segoe UI", 10F, (FontStyle)GraphicsUnit.Point, 0);
            lblRating.Location = new Point(0, 256);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(250, 30);
            lblRating.TabIndex = 3;
            lblRating.Text = "Rating: 3/5";
            lblRating.TextAlign = ContentAlignment.MiddleCenter;
            lblRating.ForeColor = Color.FromArgb(221, 0, 0);
            lblRating.BackColor = Color.FromArgb(40, 40, 40);
            // 
            // MovieControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblRating);
            Controls.Add(lblMovieYear);
            Controls.Add(lblMovieTitle);
            Controls.Add(pBoxMovie);
            Name = "MovieControl";
            Size = new Size(250, 300);
            BackColor = Color.FromArgb(30, 30, 30);
            ((System.ComponentModel.ISupportInitialize)pBoxMovie).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pBoxMovie;
        private Label lblMovieTitle;
        private Label lblMovieYear;
        private Label lblRating;
    }
}
