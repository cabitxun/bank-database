using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankProject
{
    public partial class Choose : Form
    {
        public Choose()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 credit_tol = new Form1();
            credit_tol.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 credit_tol2 = new Form2();
            credit_tol2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            aut admin = new aut();
            admin.Show();
        }
    }
}
