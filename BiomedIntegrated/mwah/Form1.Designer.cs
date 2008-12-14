namespace mwah {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btn_UpdateAll = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_ResetAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_CLK = new System.Windows.Forms.Button();
            this.lbl_CLK = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_UpdateAll
            // 
            this.btn_UpdateAll.Location = new System.Drawing.Point(477, 12);
            this.btn_UpdateAll.Name = "btn_UpdateAll";
            this.btn_UpdateAll.Size = new System.Drawing.Size(129, 80);
            this.btn_UpdateAll.TabIndex = 0;
            this.btn_UpdateAll.Text = "Update All";
            this.btn_UpdateAll.UseVisualStyleBackColor = true;
            this.btn_UpdateAll.Click += new System.EventHandler(this.btn_UpdateAll_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(612, 51);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(80, 41);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_ResetAll
            // 
            this.btn_ResetAll.Location = new System.Drawing.Point(612, 12);
            this.btn_ResetAll.Name = "btn_ResetAll";
            this.btn_ResetAll.Size = new System.Drawing.Size(80, 41);
            this.btn_ResetAll.TabIndex = 2;
            this.btn_ResetAll.Text = "Reset All";
            this.btn_ResetAll.UseVisualStyleBackColor = true;
            this.btn_ResetAll.Click += new System.EventHandler(this.btn_ResetAll_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(545, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "INPUT VALUES ARE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 521);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "IN PERCENTAGES";
            // 
            // btn_CLK
            // 
            this.btn_CLK.Location = new System.Drawing.Point(436, 12);
            this.btn_CLK.Name = "btn_CLK";
            this.btn_CLK.Size = new System.Drawing.Size(31, 79);
            this.btn_CLK.TabIndex = 5;
            this.btn_CLK.Text = " C   L   K";
            this.btn_CLK.UseVisualStyleBackColor = true;
            this.btn_CLK.Click += new System.EventHandler(this.btn_CLK_Click);
            // 
            // lbl_CLK
            // 
            this.lbl_CLK.AutoSize = true;
            this.lbl_CLK.Location = new System.Drawing.Point(445, 94);
            this.lbl_CLK.Name = "lbl_CLK";
            this.lbl_CLK.Size = new System.Drawing.Size(13, 13);
            this.lbl_CLK.TabIndex = 6;
            this.lbl_CLK.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(702, 552);
            this.Controls.Add(this.lbl_CLK);
            this.Controls.Add(this.btn_CLK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ResetAll);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_UpdateAll);
            this.Name = "Form1";
            this.Text = "George and Chris\' Ultra Super Controller Program of Doom";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_UpdateAll;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_ResetAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_CLK;
        private System.Windows.Forms.Label lbl_CLK;

    }
}

