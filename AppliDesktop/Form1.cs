using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Formatting;

namespace AppliDesktop
{
    public partial class Form1 : Form
    {
        public bool IsInitEnd= false;
        public Form1()
        {
            InitializeComponent();
            IsInitEnd=true; 
            dataGridView1.SelectionMode= DataGridViewSelectionMode.FullRowSelect;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5084/");
            HttpResponseMessage response = client.GetAsync("api/eleves").Result;
            //var Eleve = response.Content.ReadAsAsync<IEnumerable<Eleve>>().Result;
           // dataGridView1.DataSource = Eleve;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
           if ( IsInitEnd == true)
            {

                int IdSelectedRow = e.Row.Index;
            }
            int i = 0;
        }
    }
}
