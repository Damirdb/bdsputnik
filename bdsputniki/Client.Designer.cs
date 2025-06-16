namespace bdsputniki
{
    partial class Client
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataclient = new System.Windows.Forms.DataGridView();
            this.textBoxfio = new System.Windows.Forms.TextBox();
            this.textBoxaddrs = new System.Windows.Forms.TextBox();
            this.textBoxphn = new System.Windows.Forms.TextBox();
            this.textBoxmail = new System.Windows.Forms.TextBox();
            this.textBoxsrlpasp = new System.Windows.Forms.TextBox();
            this.textBoxnmbrpasp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonadd = new System.Windows.Forms.Button();
            this.buttondel = new System.Windows.Forms.Button();
            this.buttonchg = new System.Windows.Forms.Button();
            this.buttonrep = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataclient)).BeginInit();
            this.SuspendLayout();
            // 
            // dataclient
            // 
            this.dataclient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataclient.Location = new System.Drawing.Point(12, 34);
            this.dataclient.Name = "dataclient";
            this.dataclient.RowHeadersWidth = 51;
            this.dataclient.RowTemplate.Height = 24;
            this.dataclient.Size = new System.Drawing.Size(1164, 320);
            this.dataclient.TabIndex = 0;
            this.dataclient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataclient_CellContentClick);
            // 
            // textBoxfio
            // 
            this.textBoxfio.Location = new System.Drawing.Point(64, 379);
            this.textBoxfio.Name = "textBoxfio";
            this.textBoxfio.Size = new System.Drawing.Size(258, 22);
            this.textBoxfio.TabIndex = 1;
            this.textBoxfio.TextChanged += new System.EventHandler(this.textBoxfio_TextChanged);
            // 
            // textBoxaddrs
            // 
            this.textBoxaddrs.Location = new System.Drawing.Point(64, 431);
            this.textBoxaddrs.Name = "textBoxaddrs";
            this.textBoxaddrs.Size = new System.Drawing.Size(258, 22);
            this.textBoxaddrs.TabIndex = 2;
            this.textBoxaddrs.TextChanged += new System.EventHandler(this.textBoxaddrs_TextChanged);
            // 
            // textBoxphn
            // 
            this.textBoxphn.Location = new System.Drawing.Point(345, 379);
            this.textBoxphn.Name = "textBoxphn";
            this.textBoxphn.Size = new System.Drawing.Size(258, 22);
            this.textBoxphn.TabIndex = 3;
            this.textBoxphn.TextChanged += new System.EventHandler(this.textBoxphn_TextChanged);
            // 
            // textBoxmail
            // 
            this.textBoxmail.Location = new System.Drawing.Point(345, 431);
            this.textBoxmail.Name = "textBoxmail";
            this.textBoxmail.Size = new System.Drawing.Size(258, 22);
            this.textBoxmail.TabIndex = 4;
            this.textBoxmail.TextChanged += new System.EventHandler(this.textBoxmail_TextChanged);
            // 
            // textBoxsrlpasp
            // 
            this.textBoxsrlpasp.Location = new System.Drawing.Point(64, 478);
            this.textBoxsrlpasp.Name = "textBoxsrlpasp";
            this.textBoxsrlpasp.Size = new System.Drawing.Size(258, 22);
            this.textBoxsrlpasp.TabIndex = 5;
            this.textBoxsrlpasp.TextChanged += new System.EventHandler(this.textBoxsrlpasp_TextChanged);
            // 
            // textBoxnmbrpasp
            // 
            this.textBoxnmbrpasp.Location = new System.Drawing.Point(345, 478);
            this.textBoxnmbrpasp.Name = "textBoxnmbrpasp";
            this.textBoxnmbrpasp.Size = new System.Drawing.Size(258, 22);
            this.textBoxnmbrpasp.TabIndex = 6;
            this.textBoxnmbrpasp.TextChanged += new System.EventHandler(this.textBoxnmbrpasp_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Телефон";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 412);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Адрес";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Почта";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 459);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Серия паспорта";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 459);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Номер паспорта";
            // 
            // buttonadd
            // 
            this.buttonadd.Location = new System.Drawing.Point(654, 379);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(127, 23);
            this.buttonadd.TabIndex = 13;
            this.buttonadd.Text = "Добавить";
            this.buttonadd.UseVisualStyleBackColor = true;
            this.buttonadd.Click += new System.EventHandler(this.buttonadd_Click);
            // 
            // buttondel
            // 
            this.buttondel.Location = new System.Drawing.Point(654, 477);
            this.buttondel.Name = "buttondel";
            this.buttondel.Size = new System.Drawing.Size(127, 23);
            this.buttondel.TabIndex = 14;
            this.buttondel.Text = "Удалить";
            this.buttondel.UseVisualStyleBackColor = true;
            this.buttondel.Click += new System.EventHandler(this.buttondel_Click);
            // 
            // buttonchg
            // 
            this.buttonchg.Location = new System.Drawing.Point(654, 430);
            this.buttonchg.Name = "buttonchg";
            this.buttonchg.Size = new System.Drawing.Size(127, 23);
            this.buttonchg.TabIndex = 15;
            this.buttonchg.Text = "Изменить";
            this.buttonchg.UseVisualStyleBackColor = true;
            this.buttonchg.Click += new System.EventHandler(this.buttonchg_Click);
            // 
            // buttonrep
            // 
            this.buttonrep.Location = new System.Drawing.Point(843, 408);
            this.buttonrep.Name = "buttonrep";
            this.buttonrep.Size = new System.Drawing.Size(97, 69);
            this.buttonrep.TabIndex = 16;
            this.buttonrep.Text = "Отчет";
            this.buttonrep.UseVisualStyleBackColor = true;
            this.buttonrep.Click += new System.EventHandler(this.buttonrep_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(843, 380);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(143, 22);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 525);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonrep);
            this.Controls.Add(this.buttonchg);
            this.Controls.Add(this.buttondel);
            this.Controls.Add(this.buttonadd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxnmbrpasp);
            this.Controls.Add(this.textBoxsrlpasp);
            this.Controls.Add(this.textBoxmail);
            this.Controls.Add(this.textBoxphn);
            this.Controls.Add(this.textBoxaddrs);
            this.Controls.Add(this.textBoxfio);
            this.Controls.Add(this.dataclient);
            this.Name = "Client";
            this.Text = "Клиенты";
            this.Load += new System.EventHandler(this.Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataclient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataclient;
        private System.Windows.Forms.TextBox textBoxfio;
        private System.Windows.Forms.TextBox textBoxaddrs;
        private System.Windows.Forms.TextBox textBoxphn;
        private System.Windows.Forms.TextBox textBoxmail;
        private System.Windows.Forms.TextBox textBoxsrlpasp;
        private System.Windows.Forms.TextBox textBoxnmbrpasp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonadd;
        private System.Windows.Forms.Button buttondel;
        private System.Windows.Forms.Button buttonchg;
        private System.Windows.Forms.Button buttonrep;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

