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
    public partial class Form2 : Form
    {
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DataBank.mdb";
        private OleDbConnection myConnect;
        public Form2()
        {
            InitializeComponent();
            myConnect = new OleDbConnection(connectString);

            myConnect.Open();
            credit_summal.Visible = false;
            percentl2.Visible = false;
            pereplatal.Visible = false;
            button2.Visible = false;
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnect.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int credit_month_count = int.Parse(monthb.Text);
            int credit = int.Parse(creditb.Text);
            int percent = int.Parse(percentb.Text);
            double credit_alls = credit + ((credit * percent / 100) * (credit_month_count / 12));
            int credit_all = Convert.ToInt32(credit_alls);
            int credit_month = credit_all / 12;
            double pereplata = credit_all - credit;

            credit_summal.Text = "Барлығы " + credit_all.ToString();
            percentl2.Text = "Айына " + credit_month.ToString();
            pereplatal.Text = "Переплата " + pereplata.ToString();

            credit_summal.Visible = true;
            percentl2.Visible = true;
            pereplatal.Visible = true;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = nameb.Text;
            string surname = nameb.Text;
            string iin = iinb.Text;
            int credit_month_count = int.Parse(monthb.Text);
            int credit = int.Parse(creditb.Text);
            int percent = int.Parse(percentb.Text);
            double credit_alls = credit + ((credit * percent / 100) * (credit_month_count / 12));
            int credit_all = Convert.ToInt32(credit_alls);
            int credit_month = credit_all / 12;
            double pereplata = credit_all - credit;
            string query = "INSERT INTO Credits (w_name, w_surname, w_iin, w_credit_month, w_credit_month_count, w_credit_all, w_percent) VALUES (" + "'" + name + "', " + "'" + surname + "', " + "'" + iin + "', " + credit_month.ToString() + ", " + credit_month_count.ToString() + ", " + credit_all.ToString() + ", " + percent.ToString() + ")";
            OleDbCommand command = new OleDbCommand(query, myConnect);
            command.ExecuteNonQuery();
            this.Hide();
            uspe credit_tol = new uspe();
            credit_tol.Show();
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Choose credit_tol2 = new Choose();
            credit_tol2.Show();
        }
    }
}
