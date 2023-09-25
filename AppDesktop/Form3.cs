using AppDesktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDesktop
{
    public partial class Form3 : Form
    {
        HttpClient client = new HttpClient();

        public IEnumerable<Promotion> ListePromotion { get; private set; }
        public Form3()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:5084/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.GetPromotion();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        private async void GetPromotion()
        {
            lb1Message.Text = "";

            var response = await client.GetStringAsync("api/Promotions");
            var promotions = JsonConvert.DeserializeObject<List<Promotion>>(response);
            dataGridView1.DataSource = promotions;
        }
        private async void SavePromotion(Promotion promotion)
        {
            await client.PostAsJsonAsync("api/Promotions", promotion);
        }
        private async void UpdatePromotion(Promotion promotion)
        {
            await client.PutAsJsonAsync("api/Promotions/" + promotion.Id, promotion);
        }
        private async void DeletePromotion(int id)
        {
            // Envoyer une requête DELETE vers l'API pour supprimer l'élève
            HttpResponseMessage response = client.DeleteAsync($"api/Promotions/{id}").Result;

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

        private void button1_Click(object sender, EventArgs e)
        {
            var promotion = new Promotion()
            {
                Id = 0,
                Nom = "",
                Annee = 2023,
                Niveau= 1,
            };

            if (!string.IsNullOrEmpty(textBoxID.Text) && int.TryParse(textBoxID.Text, out int id))
            {
                promotion.Id = id;
            }
            if (!string.IsNullOrEmpty(textBoxan.Text) && int.TryParse(textBoxan.Text, out int annee))
            {
                promotion.Annee = annee;
            }
            if (!string.IsNullOrEmpty(textBoxni.Text) && int.TryParse(textBoxni.Text, out int niveau))
            {
                promotion.Niveau = niveau;
            }
            promotion.Nom = comboBoxgroup.Text;
           

            if (string.IsNullOrEmpty(promotion.Nom) )
            {
                lb1Message.Text = "Veuillez remplir tous les champs";
            }
            else
            {
                if (promotion.Id == 0)
                {
                    this.SavePromotion(promotion);
                    lb1Message.Text = "Promotion enregistré";
                }
                else
                {
                    // Supprimer la valeur existante de la combobox
                    comboBoxgroup.Items.Remove(comboBoxgroup.Text);

                    this.UpdatePromotion(promotion);
                    lb1Message.Text = "Promotion modifié";
                }

                // Ajouter la nouvelle valeur à la combobox
                comboBoxgroup.Items.Add(promotion.Nom);

                // Réinitialiser les champs de saisie
                textBoxID.Text = "0";
                comboBoxgroup.Text = "";
                textBoxni.Text = "1";
                textBoxan.Text = "2023";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer l'ID de l'élève à supprimer à partir du champ textBoxID
                int promotionId = int.Parse(textBoxID.Text);

                // Afficher une boîte de dialogue de confirmation
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette promotion ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Vérifier la réponse de l'utilisateur
                if (result == DialogResult.Yes)
                {
                    // Supprimer l'élève
                    DeletePromotion(promotionId);

                    // Effacer les champs de saisie après la suppression
                    textBoxID.Text = "";

                    comboBoxgroup.Text = "";
                    textBoxni.Text = "";
                    textBoxan.Text = "";

                    // Mettre à jour la liste des élèves (si nécessaire)

                    // Afficher un message de confirmation
                    MessageBox.Show("promotion supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBoxgroup.Text = "";
             textBoxni.Text = "1";
            textBoxan.Text = "2023";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "promotion.csv";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedGroupe = dataGridView1.SelectedRows[0].DataBoundItem as Promotion;
                textBoxID.Text = selectedGroupe.Id.ToString();

                comboBoxgroup.Text = selectedGroupe.Nom;
                textBoxan.Text = selectedGroupe.Annee.ToString();
                textBoxni.Text = selectedGroupe.Niveau.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez vous vraiment vous deconnectez ?", "Confirmation de deconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form4 form = new Form4();
                form.Show();
                this.Hide();
            }
                
        }
    }
}
