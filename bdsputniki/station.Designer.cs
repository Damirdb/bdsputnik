namespace bdsputniki
{
    partial class station
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dateTimePickerInstall;

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
            this.datapackage = new System.Windows.Forms.DataGridView();
            this.buttonchg = new System.Windows.Forms.Button();
            this.buttondel = new System.Windows.Forms.Button();
            this.buttonadd = new System.Windows.Forms.Button();
            this.textBoxcoordinat = new System.Windows.Forms.TextBox();
            this.textBoxdataset = new System.Windows.Forms.TextBox();
            this.comboBoxstatus = new System.Windows.Forms.ComboBox();
            this.textBoxtimescl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerInstall = new System.Windows.Forms.DateTimePicker();
            this.comboBoxtype = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datapackage)).BeginInit();
            this.SuspendLayout();
            // 
            // datapackage
            // 
            this.datapackage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datapackage.Location = new System.Drawing.Point(12, 34);
            this.datapackage.Name = "datapackage";
            this.datapackage.RowHeadersWidth = 51;
            this.datapackage.RowTemplate.Height = 24;
            this.datapackage.Size = new System.Drawing.Size(1020, 218);
            this.datapackage.TabIndex = 2;
            // 
            // buttonchg
            // 
            this.buttonchg.Location = new System.Drawing.Point(585, 339);
            this.buttonchg.Name = "buttonchg";
            this.buttonchg.Size = new System.Drawing.Size(127, 23);
            this.buttonchg.TabIndex = 24;
            this.buttonchg.Text = "Изменить";
            this.buttonchg.UseVisualStyleBackColor = true;
            this.buttonchg.Click += new System.EventHandler(this.buttonchg_Click);
            // 
            // buttondel
            // 
            this.buttondel.Location = new System.Drawing.Point(585, 386);
            this.buttondel.Name = "buttondel";
            this.buttondel.Size = new System.Drawing.Size(127, 23);
            this.buttondel.TabIndex = 23;
            this.buttondel.Text = "Удалить";
            this.buttondel.UseVisualStyleBackColor = true;
            this.buttondel.Click += new System.EventHandler(this.buttondel_Click);
            // 
            // buttonadd
            // 
            this.buttonadd.Location = new System.Drawing.Point(585, 288);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(127, 23);
            this.buttonadd.TabIndex = 22;
            this.buttonadd.Text = "Добавить";
            this.buttonadd.UseVisualStyleBackColor = true;
            this.buttonadd.Click += new System.EventHandler(this.buttonadd_Click);
            // 
            // textBoxcoordinat
            // 
            this.textBoxcoordinat.Location = new System.Drawing.Point(13, 288);
            this.textBoxcoordinat.Name = "textBoxcoordinat";
            this.textBoxcoordinat.Size = new System.Drawing.Size(235, 22);
            this.textBoxcoordinat.TabIndex = 25;
            this.textBoxcoordinat.TextChanged += new System.EventHandler(this.textBoxcoordinat_TextChanged);
            // 
            // textBoxdataset
            // 
            this.textBoxdataset.Location = new System.Drawing.Point(13, 339);
            this.textBoxdataset.Name = "textBoxdataset";
            this.textBoxdataset.Size = new System.Drawing.Size(235, 22);
            this.textBoxdataset.TabIndex = 26;
            // 
            // comboBoxstatus
            // 
            this.comboBoxstatus.FormattingEnabled = true;
            this.comboBoxstatus.Location = new System.Drawing.Point(13, 384);
            this.comboBoxstatus.Name = "comboBoxstatus";
            this.comboBoxstatus.Size = new System.Drawing.Size(235, 24);
            this.comboBoxstatus.TabIndex = 27;
            this.comboBoxstatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxstatus_SelectedIndexChanged);
            // 
            // textBoxtimescl
            // 
            this.textBoxtimescl.Location = new System.Drawing.Point(269, 340);
            this.textBoxtimescl.Name = "textBoxtimescl";
            this.textBoxtimescl.Size = new System.Drawing.Size(235, 22);
            this.textBoxtimescl.TabIndex = 29;
            this.textBoxtimescl.TextChanged += new System.EventHandler(this.textBoxtimescl_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Координаты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Тип оборудования";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "Дата установки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Часовой пояс";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "Статус";
            // 
            // dateTimePickerInstall
            // 
            this.dateTimePickerInstall.Location = new System.Drawing.Point(13, 339);
            this.dateTimePickerInstall.Name = "dateTimePickerInstall";
            this.dateTimePickerInstall.Size = new System.Drawing.Size(235, 22);
            this.dateTimePickerInstall.TabIndex = 30;
            // 
            // comboBoxtype
            // 
            this.comboBoxtype.FormattingEnabled = true;
            this.comboBoxtype.Location = new System.Drawing.Point(269, 288);
            this.comboBoxtype.Name = "comboBoxtype";
            this.comboBoxtype.Size = new System.Drawing.Size(235, 24);
            this.comboBoxtype.TabIndex = 35;
            this.comboBoxtype.SelectedIndexChanged += new System.EventHandler(this.comboBoxtype_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // station
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxtype);
            this.Controls.Add(this.dateTimePickerInstall);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxtimescl);
            this.Controls.Add(this.comboBoxstatus);
            this.Controls.Add(this.textBoxdataset);
            this.Controls.Add(this.textBoxcoordinat);
            this.Controls.Add(this.buttonchg);
            this.Controls.Add(this.buttondel);
            this.Controls.Add(this.buttonadd);
            this.Controls.Add(this.datapackage);
            this.Name = "station";
            this.Text = "Спутниковая станция";
            this.Load += new System.EventHandler(this.station_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datapackage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datapackage;
        private System.Windows.Forms.Button buttonchg;
        private System.Windows.Forms.Button buttondel;
        private System.Windows.Forms.Button buttonadd;
        private System.Windows.Forms.TextBox textBoxcoordinat;
        private System.Windows.Forms.TextBox textBoxdataset;
        private System.Windows.Forms.ComboBox comboBoxstatus;
        private System.Windows.Forms.TextBox textBoxtimescl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxtype;
        private System.Windows.Forms.Button button1;
    }
}