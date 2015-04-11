namespace task1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_value = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.a_value = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.x_value = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bYotX = new System.Windows.Forms.Button();
            this.AnswerY = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_value);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.a_value);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Коэффициенты";
            // 
            // b_value
            // 
            this.b_value.Location = new System.Drawing.Point(128, 24);
            this.b_value.Name = "b_value";
            this.b_value.Size = new System.Drawing.Size(45, 20);
            this.b_value.TabIndex = 3;
            this.b_value.Text = "0";
            this.b_value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.a_value_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "b=";
            // 
            // a_value
            // 
            this.a_value.Location = new System.Drawing.Point(42, 27);
            this.a_value.Name = "a_value";
            this.a_value.Size = new System.Drawing.Size(45, 20);
            this.a_value.TabIndex = 1;
            this.a_value.Text = "0";
            this.a_value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.a_value_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "a=";
            // 
            // x_value
            // 
            this.x_value.Location = new System.Drawing.Point(41, 93);
            this.x_value.Name = "x_value";
            this.x_value.Size = new System.Drawing.Size(27, 20);
            this.x_value.TabIndex = 3;
            this.x_value.Text = "0";
            this.x_value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.a_value_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "x=";
            // 
            // bYotX
            // 
            this.bYotX.Location = new System.Drawing.Point(74, 93);
            this.bYotX.Name = "bYotX";
            this.bYotX.Size = new System.Drawing.Size(75, 23);
            this.bYotX.TabIndex = 4;
            this.bYotX.Text = "Вычислить";
            this.bYotX.UseVisualStyleBackColor = true;
            this.bYotX.Click += new System.EventHandler(this.bYotX_Click);
            // 
            // AnswerY
            // 
            this.AnswerY.AutoSize = true;
            this.AnswerY.Location = new System.Drawing.Point(155, 98);
            this.AnswerY.Name = "AnswerY";
            this.AnswerY.Size = new System.Drawing.Size(40, 13);
            this.AnswerY.TabIndex = 5;
            this.AnswerY.Text = "Ответ:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 137);
            this.Controls.Add(this.AnswerY);
            this.Controls.Add(this.bYotX);
            this.Controls.Add(this.x_value);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "y=ax+b";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox b_value;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox a_value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox x_value;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bYotX;
        private System.Windows.Forms.Label AnswerY;
    }
}

