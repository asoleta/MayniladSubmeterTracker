namespace MayniladSubmeterTracker
{
    partial class filterDataForm
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
            this.titleLbl = new System.Windows.Forms.Label();
            this.monthLbl = new System.Windows.Forms.Label();
            this.yearLbl = new System.Windows.Forms.Label();
            this.monthTB = new System.Windows.Forms.TextBox();
            this.yearTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.backBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Yu Gothic Medium", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.ForeColor = System.Drawing.Color.White;
            this.titleLbl.Location = new System.Drawing.Point(98, 109);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(401, 45);
            this.titleLbl.TabIndex = 1;
            this.titleLbl.Text = "Enter Month and Year:";
            // 
            // monthLbl
            // 
            this.monthLbl.AutoSize = true;
            this.monthLbl.Font = new System.Drawing.Font("Yu Gothic Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthLbl.ForeColor = System.Drawing.Color.White;
            this.monthLbl.Location = new System.Drawing.Point(113, 186);
            this.monthLbl.Name = "monthLbl";
            this.monthLbl.Size = new System.Drawing.Size(98, 31);
            this.monthLbl.TabIndex = 2;
            this.monthLbl.Text = "Month:";
            // 
            // yearLbl
            // 
            this.yearLbl.AutoSize = true;
            this.yearLbl.Font = new System.Drawing.Font("Yu Gothic Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearLbl.ForeColor = System.Drawing.Color.White;
            this.yearLbl.Location = new System.Drawing.Point(284, 186);
            this.yearLbl.Name = "yearLbl";
            this.yearLbl.Size = new System.Drawing.Size(75, 31);
            this.yearLbl.TabIndex = 3;
            this.yearLbl.Text = "Year:";
            // 
            // monthTB
            // 
            this.monthTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthTB.Location = new System.Drawing.Point(217, 186);
            this.monthTB.Name = "monthTB";
            this.monthTB.Size = new System.Drawing.Size(46, 31);
            this.monthTB.TabIndex = 4;
            // 
            // yearTB
            // 
            this.yearTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearTB.Location = new System.Drawing.Point(365, 187);
            this.yearTB.Name = "yearTB";
            this.yearTB.Size = new System.Drawing.Size(79, 31);
            this.yearTB.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(222)))), ((int)(((byte)(213)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Yu Gothic Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(59)))), ((int)(((byte)(80)))));
            this.button1.Location = new System.Drawing.Point(199, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 57);
            this.button1.TabIndex = 6;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backBtn
            // 
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.Image = global::MayniladSubmeterTracker.Properties.Resources.back_arrow_1;
            this.backBtn.Location = new System.Drawing.Point(12, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(44, 43);
            this.backBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backBtn.TabIndex = 7;
            this.backBtn.TabStop = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // filterDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(154)))), ((int)(((byte)(164)))));
            this.ClientSize = new System.Drawing.Size(575, 389);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.yearTB);
            this.Controls.Add(this.monthTB);
            this.Controls.Add(this.yearLbl);
            this.Controls.Add(this.monthLbl);
            this.Controls.Add(this.titleLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "filterDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "calculatedValuesForm";
            ((System.ComponentModel.ISupportInitialize)(this.backBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label monthLbl;
        private System.Windows.Forms.Label yearLbl;
        private System.Windows.Forms.TextBox monthTB;
        private System.Windows.Forms.TextBox yearTB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox backBtn;
    }
}