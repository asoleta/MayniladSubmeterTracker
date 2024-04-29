namespace MayniladSubmeterTracker
{
    partial class homepage
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
            this.mayniladLbl = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Label();
            this.entryBtn = new System.Windows.Forms.Button();
            this.viewDataBtn = new System.Windows.Forms.Button();
            this.graphBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mayniladLbl
            // 
            this.mayniladLbl.AutoSize = true;
            this.mayniladLbl.BackColor = System.Drawing.Color.Transparent;
            this.mayniladLbl.Font = new System.Drawing.Font("Yu Gothic Medium", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mayniladLbl.ForeColor = System.Drawing.Color.White;
            this.mayniladLbl.Location = new System.Drawing.Point(196, 98);
            this.mayniladLbl.Name = "mayniladLbl";
            this.mayniladLbl.Size = new System.Drawing.Size(410, 38);
            this.mayniladLbl.TabIndex = 0;
            this.mayniladLbl.Text = "Maynilad Submeter Tracker";
            // 
            // closeBtn
            // 
            this.closeBtn.AutoSize = true;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Font = new System.Drawing.Font("Yu Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(748, 9);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(40, 42);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "X";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // entryBtn
            // 
            this.entryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.entryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.entryBtn.Font = new System.Drawing.Font("Yu Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(59)))), ((int)(((byte)(80)))));
            this.entryBtn.Location = new System.Drawing.Point(275, 184);
            this.entryBtn.Name = "entryBtn";
            this.entryBtn.Size = new System.Drawing.Size(247, 76);
            this.entryBtn.TabIndex = 2;
            this.entryBtn.Text = "New Entry";
            this.entryBtn.UseVisualStyleBackColor = false;
            this.entryBtn.Click += new System.EventHandler(this.entryBtn_Click);
            // 
            // viewDataBtn
            // 
            this.viewDataBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(222)))), ((int)(((byte)(213)))));
            this.viewDataBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewDataBtn.Font = new System.Drawing.Font("Yu Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewDataBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(59)))), ((int)(((byte)(80)))));
            this.viewDataBtn.Location = new System.Drawing.Point(275, 285);
            this.viewDataBtn.Name = "viewDataBtn";
            this.viewDataBtn.Size = new System.Drawing.Size(247, 76);
            this.viewDataBtn.TabIndex = 3;
            this.viewDataBtn.Text = "View Data";
            this.viewDataBtn.UseVisualStyleBackColor = false;
            this.viewDataBtn.Click += new System.EventHandler(this.viewDataBtn_Click);
            // 
            // graphBtn
            // 
            this.graphBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(222)))), ((int)(((byte)(213)))));
            this.graphBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.graphBtn.Font = new System.Drawing.Font("Yu Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(59)))), ((int)(((byte)(80)))));
            this.graphBtn.Location = new System.Drawing.Point(275, 386);
            this.graphBtn.Name = "graphBtn";
            this.graphBtn.Size = new System.Drawing.Size(247, 76);
            this.graphBtn.TabIndex = 4;
            this.graphBtn.Text = "Generate Graph";
            this.graphBtn.UseVisualStyleBackColor = false;
            this.graphBtn.Click += new System.EventHandler(this.graphBtn_Click);
            // 
            // homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(154)))), ((int)(((byte)(164)))));
            this.BackgroundImage = global::MayniladSubmeterTracker.Properties.Resources.Homepage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 607);
            this.Controls.Add(this.graphBtn);
            this.Controls.Add(this.viewDataBtn);
            this.Controls.Add(this.entryBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.mayniladLbl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "homepage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mayniladLbl;
        private System.Windows.Forms.Label closeBtn;
        private System.Windows.Forms.Button entryBtn;
        private System.Windows.Forms.Button viewDataBtn;
        private System.Windows.Forms.Button graphBtn;
    }
}

