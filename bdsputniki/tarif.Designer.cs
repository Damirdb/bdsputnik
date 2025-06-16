namespace bdsputniki
{
    partial class tarif
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
            this.datatarif = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxname = new System.Windows.Forms.TextBox();
            this.textBoxdesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datatarif)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonchg
            // 
            this.buttonchg.Location = new System.Drawing.Point(247, 412);
            this.buttonchg.Name = "buttonchg";
            this.buttonchg.Size = new System.Drawing.Size(127, 23);
            this.buttonchg.TabIndex = 19;
            this.buttonchg.Text = "Изменить";
            this.buttonchg.UseVisualStyleBackColor = true;
            // 
            // buttondel
            // 
            this.buttondel.Location = new System.Drawing.Point(247, 459);
            this.buttondel.Name = "buttondel";
            this.buttondel.Size = new System.Drawing.Size(127, 23);
            this.buttondel.TabIndex = 18;
            this.buttondel.Text = "Удалить";
            this.buttondel.UseVisualStyleBackColor = true;
            // 
            // buttonadd
            // 
            this.buttonadd.Location = new System.Drawing.Point(247, 361);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(127, 23);
            this.buttonadd.TabIndex = 17;
            this.buttonadd.Text = "Добавить";
            this.buttonadd.UseVisualStyleBackColor = true;
            // 
            // datatarif
            // 
            this.datatarif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datatarif.Location = new System.Drawing.Point(12, 43);
            this.datatarif.Name = "datatarif";
            this.datatarif.RowHeadersWidth = 51;
            this.datatarif.RowTemplate.Height = 24;
            this.datatarif.Size = new System.Drawing.Size(705, 291);
            this.datatarif.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Название";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBoxname
            // 
            this.textBoxname.Location = new System.Drawing.Point(12, 362);
            this.textBoxname.Name = "textBoxname";
            this.textBoxname.Size = new System.Drawing.Size(200, 22);
            this.textBoxname.TabIndex = 28;
            // 
            // textBoxdesc
            // 
            this.textBoxdesc.Location = new System.Drawing.Point(12, 420);
            this.textBoxdesc.Name = "textBoxdesc";
            this.textBoxdesc.Size = new System.Drawing.Size(200, 22);
            this.textBoxdesc.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Описание";
            // 
            // tarif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 513);
            this.Controls.Add(this.textBoxdesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxname);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonchg);
            this.Controls.Add(this.buttondel);
            this.Controls.Add(this.buttonadd);
            this.Controls.Add(this.datatarif);
            this.Name = "tarif";
            this.Text = "tarif";
            ((System.ComponentModel.ISupportInitialize)(this.datatarif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonchg;
        private System.Windows.Forms.Button buttondel;
        private System.Windows.Forms.Button buttonadd;
        private System.Windows.Forms.DataGridView datatarif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxname;
        private System.Windows.Forms.TextBox textBoxdesc;
        private System.Windows.Forms.Label label2;
    }
}