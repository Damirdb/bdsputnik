namespace bdsputniki
{
    partial class package_chanel
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
            this.comboBoxChannel = new System.Windows.Forms.ComboBox();
            this.comboBoxPackage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttondel = new System.Windows.Forms.Button();
            this.buttonadd = new System.Windows.Forms.Button();
            this.datapackagechannel = new System.Windows.Forms.DataGridView();
            this.buttonchg = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datapackagechannel)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxChannel
            // 
            this.comboBoxChannel.FormattingEnabled = true;
            this.comboBoxChannel.Location = new System.Drawing.Point(234, 286);
            this.comboBoxChannel.Name = "comboBoxChannel";
            this.comboBoxChannel.Size = new System.Drawing.Size(201, 24);
            this.comboBoxChannel.TabIndex = 4;
            // 
            // comboBoxPackage
            // 
            this.comboBoxPackage.FormattingEnabled = true;
            this.comboBoxPackage.Location = new System.Drawing.Point(12, 286);
            this.comboBoxPackage.Name = "comboBoxPackage";
            this.comboBoxPackage.Size = new System.Drawing.Size(191, 24);
            this.comboBoxPackage.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Пакет";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Канал";
            // 
            // buttondel
            // 
            this.buttondel.Location = new System.Drawing.Point(548, 344);
            this.buttondel.Name = "buttondel";
            this.buttondel.Size = new System.Drawing.Size(127, 23);
            this.buttondel.TabIndex = 23;
            this.buttondel.Text = "Удалить";
            this.buttondel.UseVisualStyleBackColor = true;
            this.buttondel.Click += new System.EventHandler(this.buttondel_Click);
            // 
            // buttonadd
            // 
            this.buttonadd.Location = new System.Drawing.Point(548, 246);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(127, 23);
            this.buttonadd.TabIndex = 22;
            this.buttonadd.Text = "Добавить";
            this.buttonadd.UseVisualStyleBackColor = true;
            this.buttonadd.Click += new System.EventHandler(this.buttonadd_Click);
            // 
            // datapackagechannel
            // 
            this.datapackagechannel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datapackagechannel.Location = new System.Drawing.Point(12, 62);
            this.datapackagechannel.Name = "datapackagechannel";
            this.datapackagechannel.RowHeadersWidth = 51;
            this.datapackagechannel.RowTemplate.Height = 24;
            this.datapackagechannel.Size = new System.Drawing.Size(776, 160);
            this.datapackagechannel.TabIndex = 25;
            // 
            // buttonchg
            // 
            this.buttonchg.Location = new System.Drawing.Point(548, 297);
            this.buttonchg.Name = "buttonchg";
            this.buttonchg.Size = new System.Drawing.Size(127, 23);
            this.buttonchg.TabIndex = 26;
            this.buttonchg.Text = "Изменить";
            this.buttonchg.UseVisualStyleBackColor = true;
            this.buttonchg.Click += new System.EventHandler(this.buttonchg_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // package_chanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 387);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonchg);
            this.Controls.Add(this.datapackagechannel);
            this.Controls.Add(this.buttondel);
            this.Controls.Add(this.buttonadd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPackage);
            this.Controls.Add(this.comboBoxChannel);
            this.Name = "package_chanel";
            this.Text = "package_chanel";
            ((System.ComponentModel.ISupportInitialize)(this.datapackagechannel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxChannel;
        private System.Windows.Forms.ComboBox comboBoxPackage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttondel;
        private System.Windows.Forms.Button buttonadd;
        private System.Windows.Forms.DataGridView datapackagechannel;
        private System.Windows.Forms.Button buttonchg;
        private System.Windows.Forms.Button button1;
    }
}