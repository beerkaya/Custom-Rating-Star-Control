
namespace Custom_Rating_Star_Control
{
    partial class RatingStarTest
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
            this.myStarRatingBar1 = new Custom_Rating_Star_Control.MyStarRatingBar();
            this.SuspendLayout();
            // 
            // myStarRatingBar1
            // 
            this.myStarRatingBar1.Location = new System.Drawing.Point(137, 121);
            this.myStarRatingBar1.Name = "myStarRatingBar1";
            this.myStarRatingBar1.Size = new System.Drawing.Size(455, 67);
            this.myStarRatingBar1.StartPoint = 0;
            this.myStarRatingBar1.TabIndex = 0;
            this.myStarRatingBar1.Text = "myStarRatingBar1";
            // 
            // RatingStarTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.myStarRatingBar1);
            this.Name = "RatingStarTest";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MyStarRatingBar myStarRatingBar1;
    }
}

