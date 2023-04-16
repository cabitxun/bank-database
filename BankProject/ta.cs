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
    public partial class ta : Form
    {
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DataBank.mdb";
        private OleDbConnection myConnect;
        public ta()
        {
            InitializeComponent();
            myConnect = new OleDbConnection(connectString);
            myConnect.Open();
        }

        private void ta_Load(object sender, EventArgs e)
        {
            string query = "SELECT w_name, w_surname, w_iin, w_credit_month, w_credit_month_count, w_credit_all, w_percent FROM Credits ORDER BY w_id";

            OleDbCommand command = new OleDbCommand(query, myConnect);

            OleDbDataReader reader = command.ExecuteReader();

            listBox1.Items.Clear();

            while (reader.Read())
            {
                listBox1.Items.Add("Есімі: " + reader[0].ToString() + "; Тегі: " + reader[1].ToString() + "; ЖСН: " + reader[2].ToString() + "; Төлейтін сумма: " + reader[3].ToString() + "; Қанша ай " + reader[4].ToString() + "; Барлық сумма: " + reader[5].ToString() + "; Процент: " + reader[6].ToString());
            }

            reader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Choose credit_tol = new Choose();
            credit_tol.Show();
        }
    }
}
