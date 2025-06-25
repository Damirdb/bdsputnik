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
            this.buttonall = new System.Windows.Forms.Button();
            this.buttoncurrent = new System.Windows.Forms.Button();
            this.buttondisactive = new System.Windows.Forms.Button();
            this.buttonFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataclient)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonchg
            // 
            this.buttonchg.Location = new System.Drawing.Point(508, 340);
            this.buttonchg.Margin = new System.Windows.Forms.Padding(2);
            this.buttonchg.Name = "buttonchg";
            this.buttonchg.Size = new System.Drawing.Size(95, 19);
            this.buttonchg.TabIndex = 20;
            this.buttonchg.Text = "Изменить";
            this.buttonchg.UseVisualStyleBackColor = true;
            this.buttonchg.Click += new System.EventHandler(this.buttonchg_Click_1);
            // 
            // buttondel
            // 
            this.buttondel.Location = new System.Drawing.Point(508, 378);
            this.buttondel.Margin = new System.Windows.Forms.Padding(2);
            this.buttondel.Name = "buttondel";
            this.buttondel.Size = new System.Drawing.Size(95, 28);
            this.buttondel.TabIndex = 19;
            this.buttondel.Text = "Удалить";
            this.buttondel.UseVisualStyleBackColor = true;
            // 
            // buttonadd
            // 
            this.buttonadd.Location = new System.Drawing.Point(508, 298);
            this.buttonadd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(95, 19);
            this.buttonadd.TabIndex = 18;
            this.buttonadd.Text = "Добавить";
            this.buttonadd.UseVisualStyleBackColor = true;
            // 
            // dataclient
            // 
            this.dataclient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataclient.Location = new System.Drawing.Point(9, 34);
            this.dataclient.Margin = new System.Windows.Forms.Padding(2);
            this.dataclient.Name = "dataclient";
            this.dataclient.RowHeadersWidth = 51;
            this.dataclient.RowTemplate.Height = 24;
            this.dataclient.Size = new System.Drawing.Size(873, 245);
            this.dataclient.TabIndex = 17;
            // 
            // comboBoxtype
            // 
            this.comboBoxtype.FormattingEnabled = true;
            this.comboBoxtype.Location = new System.Drawing.Point(247, 297);
            this.comboBoxtype.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxtype.Name = "comboBoxtype";
            this.comboBoxtype.Size = new System.Drawing.Size(140, 21);
            this.comboBoxtype.TabIndex = 22;
            // 
            // comboBoxnameclient
            // 
            this.comboBoxnameclient.FormattingEnabled = true;
            this.comboBoxnameclient.Location = new System.Drawing.Point(247, 339);
            this.comboBoxnameclient.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxnameclient.Name = "comboBoxnameclient";
            this.comboBoxnameclient.Size = new System.Drawing.Size(140, 21);
            this.comboBoxnameclient.TabIndex = 23;
            // 
            // comboBoxnameprovaider
            // 
            this.comboBoxnameprovaider.FormattingEnabled = true;
            this.comboBoxnameprovaider.Location = new System.Drawing.Point(247, 378);
            this.comboBoxnameprovaider.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxnameprovaider.Name = "comboBoxnameprovaider";
            this.comboBoxnameprovaider.Size = new System.Drawing.Size(140, 21);
            this.comboBoxnameprovaider.TabIndex = 24;
            // 
            // comboBoxnametarif
            // 
            this.comboBoxnametarif.FormattingEnabled = true;
            this.comboBoxnametarif.Location = new System.Drawing.Point(247, 419);
            this.comboBoxnametarif.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxnametarif.Name = "comboBoxnametarif";
            this.comboBoxnametarif.Size = new System.Drawing.Size(140, 21);
            this.comboBoxnametarif.TabIndex = 25;
            // 
            // dateTimePickerdateofconclusion
            // 
            this.dateTimePickerdateofconclusion.Location = new System.Drawing.Point(20, 331);
            this.dateTimePickerdateofconclusion.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerdateofconclusion.Name = "dateTimePickerdateofconclusion";
            this.dateTimePickerdateofconclusion.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerdateofconclusion.TabIndex = 26;
            // 
            // dateTimePickertermofimprisonment
            // 
            this.dateTimePickertermofimprisonment.Location = new System.Drawing.Point(20, 379);
            this.dateTimePickertermofimprisonment.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickertermofimprisonment.Name = "dateTimePickertermofimprisonment";
            this.dateTimePickertermofimprisonment.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickertermofimprisonment.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 315);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 15);
            this.label1.TabIndex = 29;
            this.label1.Text = "Дата заключения договора";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 363);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "Срок";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 281);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "Тип оборудования";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 323);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 32;
            this.label4.Text = "ФИО Клиента";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 362);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "Наименование провайдера";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 404);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 15);
            this.label6.TabIndex = 34;
            this.label6.Text = "Название тарифа";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 19);
            this.button1.TabIndex = 35;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxsearch
            // 
            this.textBoxsearch.Location = new System.Drawing.Point(278, 10);
            this.textBoxsearch.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxsearch.Name = "textBoxsearch";
            this.textBoxsearch.Size = new System.Drawing.Size(199, 20);
            this.textBoxsearch.TabIndex = 36;
            this.textBoxsearch.TextChanged += new System.EventHandler(this.textBoxsearch_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(236, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 37;
            this.label7.Text = "Поиск:";
            // 
            // buttonall
            // 
            this.buttonall.Location = new System.Drawing.Point(492, 10);
            this.buttonall.Margin = new System.Windows.Forms.Padding(2);
            this.buttonall.Name = "buttonall";
            this.buttonall.Size = new System.Drawing.Size(89, 20);
            this.buttonall.TabIndex = 38;
            this.buttonall.Text = "Показать всё";
            this.buttonall.UseVisualStyleBackColor = true;
            this.buttonall.Click += new System.EventHandler(this.buttonall_Click);
            // 
            // buttoncurrent
            // 
            this.buttoncurrent.Location = new System.Drawing.Point(598, 10);
            this.buttoncurrent.Margin = new System.Windows.Forms.Padding(2);
            this.buttoncurrent.Name = "buttoncurrent";
            this.buttoncurrent.Size = new System.Drawing.Size(89, 20);
            this.buttoncurrent.TabIndex = 39;
            this.buttoncurrent.Text = "Действующие";
            this.buttoncurrent.UseVisualStyleBackColor = true;
            this.buttoncurrent.Click += new System.EventHandler(this.buttoncurrent_Click);
            // 
            // buttondisactive
            // 
            this.buttondisactive.Location = new System.Drawing.Point(701, 10);
            this.buttondisactive.Margin = new System.Windows.Forms.Padding(2);
            this.buttondisactive.Name = "buttondisactive";
            this.buttondisactive.Size = new System.Drawing.Size(89, 20);
            this.buttondisactive.TabIndex = 40;
            this.buttondisactive.Text = "Прошедшие";
            this.buttondisactive.UseVisualStyleBackColor = true;
            this.buttondisactive.Click += new System.EventHandler(this.buttondisactive_Click);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(130, 10);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 41;
            this.buttonFilter.Text = "Фильтр";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click_1);
            // 
            // contract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 459);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.buttondisactive);
            this.Controls.Add(this.buttoncurrent);
            this.Controls.Add(this.buttonall);
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
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button buttonall;
        private System.Windows.Forms.Button buttoncurrent;
        private System.Windows.Forms.Button buttondisactive;
        private System.Windows.Forms.Button buttonFilter;
    }
}
