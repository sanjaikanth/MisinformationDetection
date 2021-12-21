namespace MisinformationCheck
{
    partial class Form1
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
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblResultType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNumberOfMatches = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.MediumPurple;
            this.btnCheck.Location = new System.Drawing.Point(358, 175);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // txtCheck
            // 
            this.txtCheck.Location = new System.Drawing.Point(25, 61);
            this.txtCheck.Multiline = true;
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.Size = new System.Drawing.Size(311, 233);
            this.txtCheck.TabIndex = 1;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(439, 61);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(311, 233);
            this.txtResult.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Best Match";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Result";
            // 
            // lblResultType
            // 
            this.lblResultType.AutoSize = true;
            this.lblResultType.Location = new System.Drawing.Point(444, 324);
            this.lblResultType.Name = "lblResultType";
            this.lblResultType.Size = new System.Drawing.Size(0, 13);
            this.lblResultType.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Number Of Matches";
            // 
            // lblNumberOfMatches
            // 
            this.lblNumberOfMatches.AutoSize = true;
            this.lblNumberOfMatches.Location = new System.Drawing.Point(436, 358);
            this.lblNumberOfMatches.Name = "lblNumberOfMatches";
            this.lblNumberOfMatches.Size = new System.Drawing.Size(0, 13);
            this.lblNumberOfMatches.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNumberOfMatches);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblResultType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtCheck);
            this.Controls.Add(this.btnCheck);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtCheck;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblResultType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNumberOfMatches;
    }
}

