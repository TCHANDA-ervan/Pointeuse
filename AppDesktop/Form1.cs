using AppDesktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5084/");
            HttpResponseMessage response = client.GetAsync("api/Eleves").Result;
            var eleve = response.Content.ReadAsAsync<IEnumerable<Models.Eleve>>().Result;
            dataGridView1.DataSource = eleve;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedEleve = dataGridView1.SelectedRows[0].DataBoundItem as Eleve;
                textBoxID.Text = selectedEleve.Id.ToString();
                textBoxgroupe.Text = selectedEleve.IdGroupe.ToString();
                textBoxpromotion.Text = selectedEleve.IdPromotion.ToString();
                textBoxNom.Text = selectedEleve.Nom;
                textBoxprenom.Text = selectedEleve.Prenom;
                textBoxphone.Text = selectedEleve.Phone;
                textBoxemail.Text = selectedEleve.EMail;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5084/")
            };

            Eleve eleve = new Eleve();
            //eleve.Id = Int32.Parse(textBoxID.Text) ;
            eleve.IdGroupe = Int32.Parse( textBoxgroupe.Text);
           eleve.IdPromotion = Int32.Parse (textBoxpromotion.Text);
            eleve.Nom = textBoxNom.Text;
            eleve.Prenom = textBoxprenom.Text;
            eleve.EMail = textBoxemail.Text;
            eleve.Phone = textBoxphone.Text;

            HttpResponseMessage response = await client.PostAsJsonAsync("api/Eleves", eleve);
            dataGridView1.DataSource = eleve;

            if (response.IsSuccessStatusCode)
            {
               MessageBox.Show("Élève ajouté avec succès !");
            }
           else
           {
               MessageBox.Show("Erreur lors de l'ajout de l'élève : " + response.StatusCode);
                
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
