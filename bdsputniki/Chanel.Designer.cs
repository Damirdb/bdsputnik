namespace bdsputniki
{
    partial class Chanel
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
            this.datachannels = new System.Windows.Forms.DataGridView();
            this.textBoxnbr = new System.Windows.Forms.TextBox();
            this.textBoxtype = new System.Windows.Forms.TextBox();
            this.textBoxname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonchg = new System.Windows.Forms.Button();
            this.buttondel = new System.Windows.Forms.Button();
            this.buttonadd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datachannels)).BeginInit();
            this.SuspendLayout();
            // 
            // datachannels
            // 
            this.datachannels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datachannels.Location = new System.Drawing.Point(12, 33);
            this.datachannels.Name = "datachannels";
            this.datachannels.RowHeadersWidth = 51;
            this.datachannels.RowTemplate.Height = 24;
            this.datachannels.Size = new System.Drawing.Size(776, 218);
            this.datachannels.TabIndex = 1;
            this.datachannels.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datapackage_CellContentClick_1);
            // 
            // textBoxnbr
            // 
            this.textBoxnbr.Location = new System.Drawing.Point(12, 273);
            this.textBoxnbr.Name = "textBoxnbr";
            this.textBoxnbr.Size = new System.Drawing.Size(223, 22);
            this.textBoxnbr.TabIndex = 2;
            this.textBoxnbr.TextChanged += new System.EventHandler(this.textBoxnbr_TextChanged);
            // 
            // textBoxtype
            // 
            this.textBoxtype.Location = new System.Drawing.Point(12, 316);
            this.textBoxtype.Name = "textBoxtype";
            this.textBoxtype.Size = new System.Drawing.Size(223, 22);
            this.textBoxtype.TabIndex = 3;
            // 
            // textBoxname
            // 
            this.textBoxname.Location = new System.Drawing.Point(12, 360);
            this.textBoxname.Name = "textBoxname";
            this.textBoxname.Size = new System.Drawing.Size(223, 22);
            this.textBoxname.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Номер канала";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Тип контента";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Название";
            // 
            // buttonchg
            // 
            this.buttonchg.Location = new System.Drawing.Point(337, 315);
            this.buttonchg.Name = "buttonchg";
            this.buttonchg.Size = new System.Drawing.Size(127, 23);
            this.buttonchg.TabIndex = 21;
            this.buttonchg.Text = "Изменить";
            this.buttonchg.UseVisualStyleBackColor = true;
            this.buttonchg.Click += new System.EventHandler(this.buttonchg_Click);
            // 
            // buttondel
            // 
            this.buttondel.Location = new System.Drawing.Point(337, 362);
            this.buttondel.Name = "buttondel";
            this.buttondel.Size = new System.Drawing.Size(127, 23);
            this.buttondel.TabIndex = 20;
            this.buttondel.Text = "Удалить";
            this.buttondel.UseVisualStyleBackColor = true;
            this.buttondel.Click += new System.EventHandler(this.buttondel_Click);
            // 
            // buttonadd
            // 
            this.buttonadd.Location = new System.Drawing.Point(337, 264);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(127, 23);
            this.buttonadd.TabIndex = 19;
            this.buttonadd.Text = "Добавить";
            this.buttonadd.UseVisualStyleBackColor = true;
            this.buttonadd.Click += new System.EventHandler(this.buttonadd_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Chanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonchg);
            this.Controls.Add(this.buttondel);
            this.Controls.Add(this.buttonadd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxname);
            this.Controls.Add(this.textBoxtype);
            this.Controls.Add(this.textBoxnbr);
            this.Controls.Add(this.datachannels);
            this.Name = "Chanel";
            this.Text = "Телеканал";
            this.Load += new System.EventHandler(this.Chanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datachannels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datachannels;
        private System.Windows.Forms.TextBox textBoxnbr;
        private System.Windows.Forms.TextBox textBoxtype;
        private System.Windows.Forms.TextBox textBoxname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonchg;
        private System.Windows.Forms.Button buttondel;
        private System.Windows.Forms.Button buttonadd;
        private System.Windows.Forms.Button button1;
    }
}