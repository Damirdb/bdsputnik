namespace bdsputniki
{
    partial class Package
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
            this.datapackage = new System.Windows.Forms.DataGridView();
            this.textBoxname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonchg = new System.Windows.Forms.Button();
            this.buttondel = new System.Windows.Forms.Button();
            this.buttonadd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonaddchn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datapackage)).BeginInit();
            this.SuspendLayout();
            // 
            // datapackage
            // 
            this.datapackage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datapackage.Location = new System.Drawing.Point(12, 33);
            this.datapackage.Name = "datapackage";
            this.datapackage.RowHeadersWidth = 51;
            this.datapackage.RowTemplate.Height = 24;
            this.datapackage.Size = new System.Drawing.Size(776, 218);
            this.datapackage.TabIndex = 0;
            this.datapackage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datapackage_CellContentClick);
            // 
            // textBoxname
            // 
            this.textBoxname.Location = new System.Drawing.Point(12, 300);
            this.textBoxname.Name = "textBoxname";
            this.textBoxname.Size = new System.Drawing.Size(247, 22);
            this.textBoxname.TabIndex = 1;
            this.textBoxname.TextChanged += new System.EventHandler(this.textBoxname_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название";
            // 
            // buttonchg
            // 
            this.buttonchg.Location = new System.Drawing.Point(345, 318);
            this.buttonchg.Name = "buttonchg";
            this.buttonchg.Size = new System.Drawing.Size(127, 23);
            this.buttonchg.TabIndex = 18;
            this.buttonchg.Text = "Изменить";
            this.buttonchg.UseVisualStyleBackColor = true;
            this.buttonchg.Click += new System.EventHandler(this.buttonchg_Click);
            // 
            // buttondel
            // 
            this.buttondel.Location = new System.Drawing.Point(345, 365);
            this.buttondel.Name = "buttondel";
            this.buttondel.Size = new System.Drawing.Size(127, 23);
            this.buttondel.TabIndex = 17;
            this.buttondel.Text = "Удалить";
            this.buttondel.UseVisualStyleBackColor = true;
            this.buttondel.Click += new System.EventHandler(this.buttondel_Click);
            // 
            // buttonadd
            // 
            this.buttonadd.Location = new System.Drawing.Point(345, 267);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(127, 23);
            this.buttonadd.TabIndex = 16;
            this.buttonadd.Text = "Добавить";
            this.buttonadd.UseVisualStyleBackColor = true;
            this.buttonadd.Click += new System.EventHandler(this.buttonadd_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonaddchn
            // 
            this.buttonaddchn.Location = new System.Drawing.Point(535, 267);
            this.buttonaddchn.Name = "buttonaddchn";
            this.buttonaddchn.Size = new System.Drawing.Size(149, 33);
            this.buttonaddchn.TabIndex = 20;
            this.buttonaddchn.Text = "Добавить канал";
            this.buttonaddchn.UseVisualStyleBackColor = true;
            this.buttonaddchn.Click += new System.EventHandler(this.buttonaddchn_Click);
            // 
            // Package
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 413);
            this.Controls.Add(this.buttonaddchn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonchg);
            this.Controls.Add(this.buttondel);
            this.Controls.Add(this.buttonadd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxname);
            this.Controls.Add(this.datapackage);
            this.Name = "Package";
            this.Text = "Пакет";
            this.Load += new System.EventHandler(this.Package_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datapackage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datapackage;
        private System.Windows.Forms.TextBox textBoxname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonchg;
        private System.Windows.Forms.Button buttondel;
        private System.Windows.Forms.Button buttonadd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonaddchn;
    }
}