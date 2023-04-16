using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankProject
{
    public partial class aut : Form
    {
        public aut()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string passk = textBox1.Text;
            if (passk == "777")
            {
                this.Hide();
                ta credit_tol = new ta();
                credit_tol.Show();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Choose credit_tol2 = new Choose();
            credit_tol2.Show();
        }
    }
}
