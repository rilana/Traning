namespace task2
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
            this.bFill_arrayList = new System.Windows.Forms.Button();
            this.bsum_class = new System.Windows.Forms.Button();
            this.grClass = new System.Windows.Forms.GroupBox();
            this.tBname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBNelement = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBcount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBCost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBtotalCost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bSaveClass = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bSaveStruct = new System.Windows.Forms.Button();
            this.tBtotalCostS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBCostS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBcountS = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBnameS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tBNelementS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bSum_struct = new System.Windows.Forms.Button();
            this.bfillArrayL_struct = new System.Windows.Forms.Button();
            this.grClass.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bFill_arrayList
            // 
            this.bFill_arrayList.Location = new System.Drawing.Point(6, 18);
            this.bFill_arrayList.Name = "bFill_arrayList";
            this.bFill_arrayList.Size = new System.Drawing.Size(75, 35);
            this.bFill_arrayList.TabIndex = 0;
            this.bFill_arrayList.Text = "Заполнить ArrayList";
            this.bFill_arrayList.UseVisualStyleBackColor = true;
            this.bFill_arrayList.Click += new System.EventHandler(this.bFill_arrayList_Click);
            // 
            // bsum_class
            // 
            this.bsum_class.Location = new System.Drawing.Point(6, 59);
            this.bsum_class.Name = "bsum_class";
            this.bsum_class.Size = new System.Drawing.Size(75, 35);
            this.bsum_class.TabIndex = 1;
            this.bsum_class.Text = "Сумма стоимостей";
            this.bsum_class.UseVisualStyleBackColor = true;
            this.bsum_class.Click += new System.EventHandler(this.bsum_class_Click);
            // 
            // grClass
            // 
            this.grClass.Controls.Add(this.bSaveClass);
            this.grClass.Controls.Add(this.tBtotalCost);
            this.grClass.Controls.Add(this.label5);
            this.grClass.Controls.Add(this.tBCost);
            this.grClass.Controls.Add(this.label4);
            this.grClass.Controls.Add(this.tBcount);
            this.grClass.Controls.Add(this.label3);
            this.grClass.Controls.Add(this.tBname);
            this.grClass.Controls.Add(this.label2);
            this.grClass.Controls.Add(this.tBNelement);
            this.grClass.Controls.Add(this.label1);
            this.grClass.Controls.Add(this.bsum_class);
            this.grClass.Controls.Add(this.bFill_arrayList);
            this.grClass.Location = new System.Drawing.Point(12, 12);
            this.grClass.Name = "grClass";
            this.grClass.Size = new System.Drawing.Size(293, 180);
            this.grClass.TabIndex = 2;
            this.grClass.TabStop = false;
            this.grClass.Text = "Класс";
            // 
            // tBname
            // 
            this.tBname.Location = new System.Drawing.Point(177, 43);
            this.tBname.Name = "tBname";
            this.tBname.Size = new System.Drawing.Size(87, 20);
            this.tBname.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Наименование";
            // 
            // tBNelement
            // 
            this.tBNelement.Location = new System.Drawing.Point(177, 17);
            this.tBNelement.Name = "tBNelement";
            this.tBNelement.Size = new System.Drawing.Size(55, 20);
            this.tBNelement.TabIndex = 4;
            this.tBNelement.Text = "0";
            this.tBNelement.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBNelement_KeyPress);
            this.tBNelement.Leave += new System.EventHandler(this.tBNelement_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "№ товара";
            // 
            // tBcount
            // 
            this.tBcount.Location = new System.Drawing.Point(177, 69);
            this.tBcount.Name = "tBcount";
            this.tBcount.Size = new System.Drawing.Size(41, 20);
            this.tBcount.TabIndex = 8;
            this.tBcount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBNelement_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Количество";
            // 
            // tBCost
            // 
            this.tBCost.Location = new System.Drawing.Point(177, 92);
            this.tBCost.Name = "tBCost";
            this.tBCost.Size = new System.Drawing.Size(67, 20);
            this.tBCost.TabIndex = 10;
            this.tBCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBNelement_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Стоимость";
            // 
            // tBtotalCost
            // 
            this.tBtotalCost.Enabled = false;
            this.tBtotalCost.Location = new System.Drawing.Point(177, 118);
            this.tBtotalCost.Name = "tBtotalCost";
            this.tBtotalCost.Size = new System.Drawing.Size(110, 20);
            this.tBtotalCost.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Сумма";
            // 
            // bSaveClass
            // 
            this.bSaveClass.Location = new System.Drawing.Point(143, 151);
            this.bSaveClass.Name = "bSaveClass";
            this.bSaveClass.Size = new System.Drawing.Size(75, 23);
            this.bSaveClass.TabIndex = 13;
            this.bSaveClass.Text = "Cохранить";
            this.bSaveClass.UseVisualStyleBackColor = true;
            this.bSaveClass.Click += new System.EventHandler(this.bSaveClass_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bSaveStruct);
            this.groupBox1.Controls.Add(this.tBtotalCostS);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tBCostS);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tBcountS);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tBnameS);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tBNelementS);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.bSum_struct);
            this.groupBox1.Controls.Add(this.bfillArrayL_struct);
            this.groupBox1.Location = new System.Drawing.Point(326, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 180);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Структура";
            // 
            // bSaveStruct
            // 
            this.bSaveStruct.Location = new System.Drawing.Point(143, 151);
            this.bSaveStruct.Name = "bSaveStruct";
            this.bSaveStruct.Size = new System.Drawing.Size(75, 23);
            this.bSaveStruct.TabIndex = 13;
            this.bSaveStruct.Text = "Cохранить";
            this.bSaveStruct.UseVisualStyleBackColor = true;
            this.bSaveStruct.Click += new System.EventHandler(this.bSaveStruct_Click);
            // 
            // tBtotalCostS
            // 
            this.tBtotalCostS.Enabled = false;
            this.tBtotalCostS.Location = new System.Drawing.Point(177, 118);
            this.tBtotalCostS.Name = "tBtotalCostS";
            this.tBtotalCostS.Size = new System.Drawing.Size(110, 20);
            this.tBtotalCostS.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(115, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Сумма";
            // 
            // tBCostS
            // 
            this.tBCostS.Location = new System.Drawing.Point(177, 92);
            this.tBCostS.Name = "tBCostS";
            this.tBCostS.Size = new System.Drawing.Size(67, 20);
            this.tBCostS.TabIndex = 10;
            this.tBCostS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBNelement_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(115, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Стоимость";
            // 
            // tBcountS
            // 
            this.tBcountS.Location = new System.Drawing.Point(177, 69);
            this.tBcountS.Name = "tBcountS";
            this.tBcountS.Size = new System.Drawing.Size(41, 20);
            this.tBcountS.TabIndex = 8;
            this.tBcountS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBNelement_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(105, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Количество";
            // 
            // tBnameS
            // 
            this.tBnameS.Location = new System.Drawing.Point(177, 43);
            this.tBnameS.Name = "tBnameS";
            this.tBnameS.Size = new System.Drawing.Size(87, 20);
            this.tBnameS.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(88, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Наименование";
            // 
            // tBNelementS
            // 
            this.tBNelementS.Location = new System.Drawing.Point(177, 17);
            this.tBNelementS.Name = "tBNelementS";
            this.tBNelementS.Size = new System.Drawing.Size(55, 20);
            this.tBNelementS.TabIndex = 4;
            this.tBNelementS.Text = "0";
            this.tBNelementS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBNelement_KeyPress);
            this.tBNelementS.Leave += new System.EventHandler(this.tBNelementS_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(115, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "№ товара";
            // 
            // bSum_struct
            // 
            this.bSum_struct.Location = new System.Drawing.Point(6, 59);
            this.bSum_struct.Name = "bSum_struct";
            this.bSum_struct.Size = new System.Drawing.Size(75, 35);
            this.bSum_struct.TabIndex = 1;
            this.bSum_struct.Text = "Сумма стоимостей";
            this.bSum_struct.UseVisualStyleBackColor = true;
            this.bSum_struct.Click += new System.EventHandler(this.bSum_struct_Click);
            // 
            // bfillArrayL_struct
            // 
            this.bfillArrayL_struct.Location = new System.Drawing.Point(6, 18);
            this.bfillArrayL_struct.Name = "bfillArrayL_struct";
            this.bfillArrayL_struct.Size = new System.Drawing.Size(75, 35);
            this.bfillArrayL_struct.TabIndex = 0;
            this.bfillArrayL_struct.Text = "Заполнить ArrayList";
            this.bfillArrayL_struct.UseVisualStyleBackColor = true;
            this.bfillArrayL_struct.Click += new System.EventHandler(this.bfillArrayL_struct_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 225);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grClass);
            this.Name = "Form1";
            this.Text = "Task2";
            this.grClass.ResumeLayout(false);
            this.grClass.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bFill_arrayList;
        private System.Windows.Forms.Button bsum_class;
        private System.Windows.Forms.GroupBox grClass;
        private System.Windows.Forms.TextBox tBname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBNelement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bSaveClass;
        private System.Windows.Forms.TextBox tBtotalCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBcount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bSaveStruct;
        private System.Windows.Forms.TextBox tBtotalCostS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBCostS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBcountS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tBnameS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBNelementS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bSum_struct;
        private System.Windows.Forms.Button bfillArrayL_struct;
    }
}

