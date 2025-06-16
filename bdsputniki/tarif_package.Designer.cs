namespace bdsputniki
{
    partial class tarif_package
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
            this.button1 = new System.Windows.Forms.Button();
            this.buttonchg = new System.Windows.Forms.Button();
            this.dataGridViewTarifPackage = new System.Windows.Forms.DataGridView();
            this.buttondel = new System.Windows.Forms.Button();
            this.buttonadd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPackage = new System.Windows.Forms.ComboBox();
            this.comboBoxtarif = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarifPackage)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonchg
            // 
            this.buttonchg.Location = new System.Drawing.Point(548, 288);
            this.buttonchg.Name = "buttonchg";
            this.buttonchg.Size = new System.Drawing.Size(127, 23);
            this.buttonchg.TabIndex = 35;
            this.buttonchg.Text = "Изменить";
            this.buttonchg.UseVisualStyleBackColor = true;
            this.buttonchg.Click += new System.EventHandler(this.buttonchg_Click);
            // 
            // dataGridViewTarifPackage
            // 
            this.dataGridViewTarifPackage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTarifPackage.Location = new System.Drawing.Point(12, 53);
            this.dataGridViewTarifPackage.Name = "dataGridViewTarifPackage";
            this.dataGridViewTarifPackage.RowHeadersWidth = 51;
            this.dataGridViewTarifPackage.RowTemplate.Height = 24;
            this.dataGridViewTarifPackage.Size = new System.Drawing.Size(776, 160);
            this.dataGridViewTarifPackage.TabIndex = 34;
            // 
            // buttondel
            // 
            this.buttondel.Location = new System.Drawing.Point(548, 335);
            this.buttondel.Name = "buttondel";
            this.buttondel.Size = new System.Drawing.Size(127, 23);
            this.buttondel.TabIndex = 33;
            this.buttondel.Text = "Удалить";
            this.buttondel.UseVisualStyleBackColor = true;
            this.buttondel.Click += new System.EventHandler(this.buttondel_Click);
            // 
            // buttonadd
            // 
            this.buttonadd.Location = new System.Drawing.Point(548, 237);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(127, 23);
            this.buttonadd.TabIndex = 32;
            this.buttonadd.Text = "Добавить";
            this.buttonadd.UseVisualStyleBackColor = true;
            this.buttonadd.Click += new System.EventHandler(this.buttonadd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Тариф";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Пакет";
            // 
            // comboBoxPackage
            // 
            this.comboBoxPackage.FormattingEnabled = true;
            this.comboBoxPackage.Location = new System.Drawing.Point(278, 273);
            this.comboBoxPackage.Name = "comboBoxPackage";
            this.comboBoxPackage.Size = new System.Drawing.Size(191, 24);
            this.comboBoxPackage.TabIndex = 29;
            // 
            // comboBoxtarif
            // 
            this.comboBoxtarif.FormattingEnabled = true;
            this.comboBoxtarif.Location = new System.Drawing.Point(12, 273);
            this.comboBoxtarif.Name = "comboBoxtarif";
            this.comboBoxtarif.Size = new System.Drawing.Size(201, 24);
            this.comboBoxtarif.TabIndex = 28;
            this.comboBoxtarif.SelectedIndexChanged += new System.EventHandler(this.comboBoxtarif_SelectedIndexChanged);
            // 
            // tarif_package
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 413);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonchg);
            this.Controls.Add(this.dataGridViewTarifPackage);
            this.Controls.Add(this.buttondel);
            this.Controls.Add(this.buttonadd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPackage);
            this.Controls.Add(this.comboBoxtarif);
            this.Name = "tarif_package";
            this.Text = "tarif_package";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarifPackage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonchg;
        private System.Windows.Forms.DataGridView dataGridViewTarifPackage;
        private System.Windows.Forms.Button buttondel;
        private System.Windows.Forms.Button buttonadd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPackage;
        private System.Windows.Forms.ComboBox comboBoxtarif;
    }
}