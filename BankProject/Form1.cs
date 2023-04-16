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
    public partial class Form1 : Form
    {
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DataBank.mdb";
        private OleDbConnection myConnect;

        public Form1()
        {
            InitializeComponent();
            myConnect = new OleDbConnection(connectString);

            myConnect.Open();
            name.Visible = false;
            surname.Visible = false;
            iin.Visible = false;
            credit_month.Visible = false;
            credit_month_count.Visible = false;
            credit_pay.Visible = false;
            credit_all.Visible = false;
            button2.Visible = false;
            d1.Visible = false;
            d2.Visible = false;
            d3.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnect.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string iins = textBox1.Text.ToString();
            string query = "SELECT w_name, w_surname, w_iin, w_credit_month, w_credit_month_count, w_credit_all FROM Credits WHERE w_iin = '"+iins + "'";

            OleDbCommand command = new OleDbCommand(query, myConnect);
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            if (textBox1.Text == iins)
            {
                name.Text = "Есімі " + reader[0].ToString();
                surname.Text = "Тегі " + reader[1].ToString();
                iin.Text = "ЖСН " + reader[2].ToString();
                credit_month.Text = reader[3].ToString();
                credit_pay.Text = "Төлеу керек " + reader[3].ToString();
                d1.Text = reader[3].ToString();
                d2.Text = reader[4].ToString();
                d3.Text = reader[5].ToString();
                credit_month_count.Text = "Қалған ай " + reader[4].ToString();
                credit_all.Text = "Толық қарыз " + reader[5].ToString();
                name.Visible = true;
                surname.Visible = true;
                iin.Visible = true;
                credit_month.Visible = true;
                credit_month_count.Visible = true;
                credit_pay.Visible = true;
                credit_all.Visible = true;
                button2.Visible = true;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string iins = textBox1.Text.ToString();
            int credit_alle = int.Parse(d3.Text);
            int credit_monthe = int.Parse(d1.Text);
            int credit_counte = int.Parse(d2.Text);
            string query;
            if (credit_alle - credit_monthe == 0)
            {
                credit_alle -= credit_monthe;
                credit_counte -= 1;
                credit_monthe = 0;
                query = $@"UPDATE Credits SET w_credit_month = {credit_monthe}, w_credit_all = {credit_alle}, w_credit_month_count = {credit_counte} WHERE w_iin = '" + iins + "'";
            } else
            {
                credit_alle -= credit_monthe;
                credit_counte -= 1;
                query = $@"UPDATE Credits SET w_credit_all = {credit_alle}, w_credit_month_count = {credit_counte} WHERE w_iin = '" + iins + "'";
            }
            OleDbCommand command = new OleDbCommand(query, myConnect);

            command.ExecuteNonQuery();
            this.Hide();
            uspe credit_tol = new uspe();
            credit_tol.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Choose credit_tol2 = new Choose();
            credit_tol2.Show();
        }
    }
}
