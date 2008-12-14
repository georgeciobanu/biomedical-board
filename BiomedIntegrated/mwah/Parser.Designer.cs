namespace mwah
{
    partial class Parser
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
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Parse = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(218, 230);
            this.textBox1.TabIndex = 0;
            // 
            // btn_Parse
            // 
            this.btn_Parse.Location = new System.Drawing.Point(3, 239);
            this.btn_Parse.Name = "btn_Parse";
            this.btn_Parse.Size = new System.Drawing.Size(218, 42);
            this.btn_Parse.TabIndex = 2;
            this.btn_Parse.Text = "Run";
            this.btn_Parse.UseVisualStyleBackColor = true;
            this.btn_Parse.Click += new System.EventHandler(this.btn_Parse_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(3, 287);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(218, 109);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "Syntax for writing code:";
            // 
            // Parser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btn_Parse);
            this.Controls.Add(this.textBox1);
            this.Name = "Parser";
            this.Size = new System.Drawing.Size(225, 399);
            this.Load += new System.EventHandler(this.Parser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Parse;
        private System.Windows.Forms.TextBox textBox2;
    }
}
