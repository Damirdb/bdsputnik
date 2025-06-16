using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bdsputniki
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client newForm = new Client();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            provaider newForm = new provaider();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chanel newForm = new Chanel();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Package newForm = new Package();
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            station newForm = new station();
            newForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            contract newForm = new contract();
            newForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            package_chanel newForm = new package_chanel();
            newForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            payment newForm = new payment();
            newForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tarif_count newForm = new tarif_count();
            newForm.Show();
        }
    }
}
