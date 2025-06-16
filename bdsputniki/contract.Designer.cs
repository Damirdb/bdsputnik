namespace bdsputniki
{
    partial class contract
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
            this.buttonchg = new System.Windows.Forms.Button();
            this.buttondel = new System.Windows.Forms.Button();
            this.buttonadd = new System.Windows.Forms.Button();
            this.dataclient = new System.Windows.Forms.DataGridView();
            this.comboBoxtype = new System.Windows.Forms.ComboBox();
            this.comboBoxnameclient = new System.Windows.Forms.ComboBox();
            this.comboBoxnameprovaider = new System.Windows.Forms.ComboBox();
            this.comboBoxnametarif = new System.Windows.Forms.ComboBox();
            this.dateTimePickerdateofconclusion = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickertermofimprisonment = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxsearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataclient)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonchg
            // 
            this.buttonchg.Location = new System.Drawing.Point(677, 418);
            this.buttonchg.Name = "buttonchg";
            this.buttonchg.Size = new System.Drawing.Size(127, 23);
            this.buttonchg.TabIndex = 20;
            this.buttonchg.Text = "Изменить";
            this.buttonchg.UseVisualStyleBackColor = true;
            this.buttonchg.Click += new System.EventHandler(this.buttonchg_Click_1);
            // 
            // buttondel
            // 
            this.buttondel.Location = new System.Drawing.Point(677, 465);
            this.buttondel.Name = "buttondel";
            this.buttondel.Size = new System.Drawing.Size(127, 23);
            this.buttondel.TabIndex = 19;
            this.buttondel.Text = "Удалить";
            this.buttondel.UseVisualStyleBackColor = true;
            // 
            // buttonadd
            // 
            this.buttonadd.Location = new System.Drawing.Point(677, 367);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(127, 23);
            this.buttonadd.TabIndex = 18;
            this.buttonadd.Text = "Добавить";
            this.buttonadd.UseVisualStyleBackColor = true;
            // 
            // dataclient
            // 
            this.dataclient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataclient.Location = new System.Drawing.Point(12, 42);
            this.dataclient.Name = "dataclient";
            this.dataclient.RowHeadersWidth = 51;
            this.dataclient.RowTemplate.Height = 24;
            this.dataclient.Size = new System.Drawing.Size(1164, 301);
            this.dataclient.TabIndex = 17;
            // 
            // comboBoxtype
            // 
            this.comboBoxtype.FormattingEnabled = true;
            this.comboBoxtype.Location = new System.Drawing.Point(329, 365);
            this.comboBoxtype.Name = "comboBoxtype";
            this.comboBoxtype.Size = new System.Drawing.Size(186, 24);
            this.comboBoxtype.TabIndex = 22;
            // 
            // comboBoxnameclient
            // 
            this.comboBoxnameclient.FormattingEnabled = true;
            this.comboBoxnameclient.Location = new System.Drawing.Point(329, 417);
            this.comboBoxnameclient.Name = "comboBoxnameclient";
            this.comboBoxnameclient.Size = new System.Drawing.Size(186, 24);
            this.comboBoxnameclient.TabIndex = 23;
            // 
            // comboBoxnameprovaider
            // 
            this.comboBoxnameprovaider.FormattingEnabled = true;
            this.comboBoxnameprovaider.Location = new System.Drawing.Point(329, 465);
            this.comboBoxnameprovaider.Name = "comboBoxnameprovaider";
            this.comboBoxnameprovaider.Size = new System.Drawing.Size(186, 24);
            this.comboBoxnameprovaider.TabIndex = 24;
            // 
            // comboBoxnametarif
            // 
            this.comboBoxnametarif.FormattingEnabled = true;
            this.comboBoxnametarif.Location = new System.Drawing.Point(329, 516);
            this.comboBoxnametarif.Name = "comboBoxnametarif";
            this.comboBoxnametarif.Size = new System.Drawing.Size(186, 24);
            this.comboBoxnametarif.TabIndex = 25;
            // 
            // dateTimePickerdateofconclusion
            // 
            this.dateTimePickerdateofconclusion.Location = new System.Drawing.Point(26, 407);
            this.dateTimePickerdateofconclusion.Name = "dateTimePickerdateofconclusion";
            this.dateTimePickerdateofconclusion.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerdateofconclusion.TabIndex = 26;
            // 
            // dateTimePickertermofimprisonment
            // 
            this.dateTimePickertermofimprisonment.Location = new System.Drawing.Point(26, 466);
            this.dateTimePickertermofimprisonment.Name = "dateTimePickertermofimprisonment";
            this.dateTimePickertermofimprisonment.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickertermofimprisonment.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Дата заключения договора";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Срок";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "Тип оборудования";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "ФИО Клиента";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(326, 446);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "Наименование провайдера";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 497);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 16);
            this.label6.TabIndex = 34;
            this.label6.Text = "Название тарифа";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxsearch
            // 
            this.textBoxsearch.Location = new System.Drawing.Point(371, 12);
            this.textBoxsearch.Name = "textBoxsearch";
            this.textBoxsearch.Size = new System.Drawing.Size(264, 22);
            this.textBoxsearch.TabIndex = 36;
            this.textBoxsearch.TextChanged += new System.EventHandler(this.textBoxsearch_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "Поиск:";
            // 
            // contract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 552);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxsearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickertermofimprisonment);
            this.Controls.Add(this.dateTimePickerdateofconclusion);
            this.Controls.Add(this.comboBoxnametarif);
            this.Controls.Add(this.comboBoxnameprovaider);
            this.Controls.Add(this.comboBoxnameclient);
            this.Controls.Add(this.comboBoxtype);
            this.Controls.Add(this.buttonchg);
            this.Controls.Add(this.buttondel);
            this.Controls.Add(this.buttonadd);
            this.Controls.Add(this.dataclient);
            this.Name = "contract";
            this.Text = "contract";
            ((System.ComponentModel.ISupportInitialize)(this.dataclient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonchg;
        private System.Windows.Forms.Button buttondel;
        private System.Windows.Forms.Button buttonadd;
        private System.Windows.Forms.DataGridView dataclient;
        private System.Windows.Forms.ComboBox comboBoxtype;
        private System.Windows.Forms.ComboBox comboBoxnameclient;
        private System.Windows.Forms.ComboBox comboBoxnameprovaider;
        private System.Windows.Forms.ComboBox comboBoxnametarif;
        private System.Windows.Forms.DateTimePicker dateTimePickerdateofconclusion;
        private System.Windows.Forms.DateTimePicker dateTimePickertermofimprisonment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxsearch;
        private System.Windows.Forms.Label label7;
    }
}