<<<<<<< Updated upstream
﻿using System;
=======
﻿using AppDesktop.Models;
using ExcelDataReader;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
>>>>>>> Stashed changes
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
<<<<<<< Updated upstream
=======
using System.Net.Http.Headers;
using System.Security.Policy;
>>>>>>> Stashed changes
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDesktop
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();

        public IEnumerable<Eleve> ListeEleve { get; private set; }

        public Form1()
        {
            client.BaseAddress = new Uri("http://localhost:5084/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );


            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5084/");
            HttpResponseMessage response = client.GetAsync("api/eleves").Result;
            var eleve = response.Content.ReadAsAsync<IEnumerable<Models.Eleve>>().Result;
            dataGridView1.DataSource = eleve;
=======
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:5084/");
            //HttpResponseMessage response = client.GetAsync("api/Eleves").Result;
            //var eleve= response.Content.ReadAsAsync<IEnumerable<Models.Eleve>>().Result;
            //dataGridView1.DataSource = eleve;
            this.GetEleve();

>>>>>>> Stashed changes
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            try
            {
<<<<<<< Updated upstream

=======
                var selectedEleve = dataGridView1.SelectedRows[0].DataBoundItem as Eleve;
                textBoxID.Text = selectedEleve.Id.ToString();
              textBoxgroupe.Text = selectedEleve.IdGroupe.ToString();
               textBoxpromotion.Text = selectedEleve.IdPromotion.ToString();
                textBoxNom.Text = selectedEleve.Nom;
                textBoxprenom.Text = selectedEleve.Prenom;
                textBoxphone.Text = selectedEleve.Phone;
               textBoxemail.Text = selectedEleve.EMail;
                
>>>>>>> Stashed changes
            }
            catch (Exception ex)
            {

                throw;
            }
        }
<<<<<<< Updated upstream
=======



        private async void button1_Click(object sender, EventArgs e)
        {
            var eleve = new Eleve()
            {
                Id = 0,
                IdGroupe = 0,
                IdPromotion = 0,
                Nom = "",
                Prenom = "",
                EMail = "",
                Phone = "",
            };

            if (!string.IsNullOrEmpty(textBoxID.Text) && int.TryParse(textBoxID.Text, out int id))
            {
                eleve.Id = id;
            }

            if (!string.IsNullOrEmpty(textBoxgroupe.Text) && int.TryParse(textBoxgroupe.Text, out int idGroupe))
            {
                eleve.IdGroupe = idGroupe;
            }

            if (!string.IsNullOrEmpty(textBoxpromotion.Text) && int.TryParse(textBoxpromotion.Text, out int idPromotion))
            {
                eleve.IdPromotion = idPromotion;
            }

            eleve.Nom = textBoxNom.Text;
            eleve.Prenom = textBoxprenom.Text;
            eleve.EMail = textBoxemail.Text;
            eleve.Phone = textBoxphone.Text;

            if (string.IsNullOrEmpty(eleve.Nom) || string.IsNullOrEmpty(eleve.Prenom) ||
                string.IsNullOrEmpty(eleve.EMail) ) //string.IsNullOrEmpty(eleve.Phone))
            {
                lb1Message.Text = "Veuillez remplir tous les champs";
            }
            else
            {
                if (eleve.Id == 0)
                {
                    this.SaveEleve(eleve);
                    lb1Message.Text = "Élève enregistré";
                }
                else
                {
                    this.UpdateEleve(eleve);
                    lb1Message.Text = "Élève modifié";
                }

                // Réinitialiser les champs de saisie
                textBoxID.Text = "0";
                textBoxgroupe.Text = "0";
                textBoxpromotion.Text = "0";
                textBoxNom.Text = "";
                textBoxprenom.Text = "";
                textBoxphone.Text = "";
                textBoxemail.Text = "";
            }



            // HttpClient client = new HttpClient
            // {
            //     BaseAddress = new Uri("http://localhost:5084/")
            // };

            // Groupe groupe = new Groupe();
            //// groupe.Id = Int32.Parse(textBoxID.Text) ;
            // //eleve.IdGroupe = Int32.Parse( textBoxgroupe.Text);
            ////eleve.IdPromotion = Int32.Parse (textBoxpromotion.Text);
            // groupe.Nom = textBoxNom.Text;
            // groupe.Formation = textBoxprenom.Text;
            // //eleve.EMail = textBoxemail.Text;
            // //eleve.Phone = textBoxphone.Text;

            // HttpResponseMessage response = await client.PostAsJsonAsync("api/Groupes", groupe);
            // dataGridView1.DataSource = groupe;

            // if (response.IsSuccessStatusCode)
            // {
            //    MessageBox.Show("Élève ajouté avec succès !");
            // }
            //else
            //{
            //    MessageBox.Show("Erreur lors de l'ajout de l'élève : " + response.StatusCode);

            // }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {

        }

        private async void GetEleve()
        {
            lb1Message.Text = "";

            var response = await client.GetStringAsync("api/Eleves");
            var eleves = JsonConvert.DeserializeObject<List<Eleve>>(response);
            dataGridView1.DataSource = eleves;
        }
        private async void SaveEleve(Eleve eleve)
        {
            await client.PostAsJsonAsync("api/Eleves", eleve);
        }
        private async void UpdateEleve(Eleve eleve)
        {
            await client.PutAsJsonAsync("api/Eleves/" + eleve.Id, eleve);
        }
        private async void DeleteEleve(int id)
        {
            // Envoyer une requête DELETE vers l'API pour supprimer l'élève
            HttpResponseMessage response = client.DeleteAsync($"api/Eleves/{id}").Result;

            // Vérifier si la suppression s'est effectuée avec succès
            if (response.IsSuccessStatusCode)
            {
                // Élève supprimé avec succès
               // MessageBox.Show("Élève supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Erreur lors de la suppression de l'élève
               // MessageBox.Show("Erreur lors de la suppression de l'élève.", "Erreur de suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer l'ID de l'élève à supprimer à partir du champ textBoxID
                int eleveId = int.Parse(textBoxID.Text);

                // Afficher une boîte de dialogue de confirmation
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élève ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Vérifier la réponse de l'utilisateur
                if (result == DialogResult.Yes)
                {
                    // Supprimer l'élève
                    DeleteEleve(eleveId);

                    // Effacer les champs de saisie après la suppression
                    textBoxID.Text = "";
                    textBoxgroupe.Text = "";
                    textBoxpromotion.Text = "";
                    textBoxNom.Text = "";
                    textBoxprenom.Text = "";
                    textBoxphone.Text = "";
                    textBoxemail.Text = "";

                    // Mettre à jour la liste des élèves (si nécessaire)

                    // Afficher un message de confirmation
                    MessageBox.Show("Élève supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "eleve.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                // En-têtes des colonnes
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    sb.Append(dataGridView1.Columns[i].HeaderText);
                    if (i < dataGridView1.Columns.Count - 1)
                    {
                        sb.Append(";");
                    }
                }
                sb.AppendLine();

                // Données des cellules
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    for (int j = 0; j < row.Cells.Count; j++)
                    {
                        sb.Append(row.Cells[j].Value);
                        if (j < row.Cells.Count - 1)
                        {
                            sb.Append(";");
                        }
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(sfd.FileName, sb.ToString());
                MessageBox.Show("Données exportées avec succès.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers CSV (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string cheminFichier = openFileDialog.FileName;

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                string[] lignes = File.ReadAllLines(cheminFichier);

                if (lignes.Length > 0)
                {
                    // Lecture de l'en-tête
                    string[] entetes = lignes[0].Split(',');

                    foreach (string entete in entetes)
                    {
                        dataGridView1.Columns.Add(entete, entete);
                    }

                    // Lecture des données
                    for (int i = 1; i < lignes.Length; i++)
                    {
                        string[] champs = lignes[i].Split(',');

                        if (champs.Length == entetes.Length)
                        {
                            dataGridView1.Rows.Add(champs);
                        }
                        else
                        {
                            // Le nombre de champs ne correspond pas au nombre d'en-têtes
                            MessageBox.Show("Le nombre de colonnes dans le fichier CSV ne correspond pas au nombre de colonnes du DataGridView.", "Erreur d'importation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    // Aucune donnée dans le fichier CSV
                    MessageBox.Show("Le fichier CSV est vide.", "Erreur d'importation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxgroupe.Text = "";
            textBoxpromotion.Text = "";
            textBoxNom.Text = "";
            textBoxprenom.Text = "";
            textBoxphone.Text = "";
            textBoxemail.Text = "";

        }

        private void TextGroupe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBoxpromotion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxprenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lb1Message_Click(object sender, EventArgs e)
        {

        }

        private void textBoxgroupe_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxpromotion_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Afficher une boîte de dialogue de confirmation
            DialogResult result = MessageBox.Show("Voulez vous vraiment vous deconnectez ?", "Confirmation de deconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form4 form = new Form4();
                form.Show();
                this.Hide();

            }
                
        }
>>>>>>> Stashed changes
    }
}
