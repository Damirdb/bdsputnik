namespace bdsputniki
{
    partial class tarif_count
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxtarif = new System.Windows.Forms.ComboBox();
            this.buttonchg = new System.Windows.Forms.Button();
            this.buttondel = new System.Windows.Forms.Button();
            this.buttonadd = new System.Windows.Forms.Button();
            this.datatarifcount = new System.Windows.Forms.DataGridView();
            this.buttonaddpck = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datatarifcount)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Название";
            // 
            // comboBoxtarif
            // 
            this.comboBoxtarif.FormattingEnabled = true;
            this.comboBoxtarif.Location = new System.Drawing.Point(12, 362);
            this.comboBoxtarif.Name = "comboBoxtarif";
            this.comboBoxtarif.Size = new System.Drawing.Size(200, 24);
            this.comboBoxtarif.TabIndex = 31;
            // 
            // buttonchg
            // 
            this.buttonchg.Location = new System.Drawing.Point(247, 410);
            this.buttonchg.Name = "buttonchg";
            this.buttonchg.Size = new System.Drawing.Size(127, 23);
            this.buttonchg.TabIndex = 30;
            this.buttonchg.Text = "Изменить";
            this.buttonchg.UseVisualStyleBackColor = true;
            // 
            // buttondel
            // 
            this.buttondel.Location = new System.Drawing.Point(247, 457);
            this.buttondel.Name = "buttondel";
            this.buttondel.Size = new System.Drawing.Size(127, 23);
            this.buttondel.TabIndex = 29;
            this.buttondel.Text = "Удалить";
            this.buttondel.UseVisualStyleBackColor = true;
            // 
            // buttonadd
            // 
            this.buttonadd.Location = new System.Drawing.Point(247, 359);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(127, 23);
            this.buttonadd.TabIndex = 28;
            this.buttonadd.Text = "Добавить";
            this.buttonadd.UseVisualStyleBackColor = true;
            // 
            // datatarifcount
            // 
            this.datatarifcount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datatarifcount.Location = new System.Drawing.Point(12, 41);
            this.datatarifcount.Name = "datatarifcount";
            this.datatarifcount.RowHeadersWidth = 51;
            this.datatarifcount.RowTemplate.Height = 24;
            this.datatarifcount.Size = new System.Drawing.Size(705, 291);
            this.datatarifcount.TabIndex = 27;
            // 
            // buttonaddpck
            // 
            this.buttonaddpck.Location = new System.Drawing.Point(481, 405);
            this.buttonaddpck.Name = "buttonaddpck";
            this.buttonaddpck.Size = new System.Drawing.Size(149, 33);
            this.buttonaddpck.TabIndex = 34;
            this.buttonaddpck.Text = "Добавить пакет";
            this.buttonaddpck.UseVisualStyleBackColor = true;
            this.buttonaddpck.Click += new System.EventHandler(this.buttonaddpck_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(481, 357);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 33);
            this.button2.TabIndex = 35;
            this.button2.Text = "Добавить тариф";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tarif_count
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 500);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonaddpck);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxtarif);
            this.Controls.Add(this.buttonchg);
            this.Controls.Add(this.buttondel);
            this.Controls.Add(this.buttonadd);
            this.Controls.Add(this.datatarifcount);
            this.Name = "tarif_count";
            this.Text = "tarif_count";
            ((System.ComponentModel.ISupportInitialize)(this.datatarifcount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxtarif;
        private System.Windows.Forms.Button buttonchg;
        private System.Windows.Forms.Button buttondel;
        private System.Windows.Forms.Button buttonadd;
        private System.Windows.Forms.DataGridView datatarifcount;
        private System.Windows.Forms.Button buttonaddpck;
        private System.Windows.Forms.Button button2;
    }
}