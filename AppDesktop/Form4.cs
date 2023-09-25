using AppDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AppDesktop
{
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();


        }
        SqlConnection conn = new SqlConnection (@"Data Source=HP_pavillon\SQLEXPRESS;Initial Catalog=DB3il;Integrated Security=True");

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void connexion_Click(object sender, EventArgs e)
        {

            String login, password;
            
            login = textBoxlogin.Text;
            password = textBoxpassword.Text;


            try
            {
                String querry = "SELECT * FROM utilisateur WHERE Login = '"+textBoxlogin.Text+"' AND Password = '"+textBoxpassword.Text+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(querry , conn);

                DataTable dt = new DataTable(); 
                adapter.Fill(dt);
                if(dt.Rows.Count > 0 )
                {
                    login = textBoxlogin.Text;
                    password = textBoxpassword.Text;

                    Form1 form = new Form1();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("login ou password incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxlogin.Clear();
                    textBoxpassword.Clear();

                    textBoxlogin.Focus();

                }
            }
           catch
            {
                MessageBox.Show("Error");
            }
            finally { conn.Close(); }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez vous vraiment vous Quittez ?", "Confirmation de deconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void textBoxlogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBoxpassword.UseSystemPasswordChar = false;
            else
                textBoxpassword.UseSystemPasswordChar = true;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}


