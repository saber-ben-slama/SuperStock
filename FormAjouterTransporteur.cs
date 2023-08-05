using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFA
{
    public partial class FormAjouterTransporteur : Form
    {
        public FormAjouterTransporteur()
        {
            InitializeComponent();
            Numtxt.Text = "T"+Convert.ToString(connectbd.NumTronsporteur());
            dataGridView1.DataSource = connectbd.RechercheTRansport();


        }

        private void FormAjouterTransporteur_Load(object sender, EventArgs e)
        {

        }

        private void nomtr_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = connectbd.RechercheTransporteur(nomtr.Text.Trim());
            FormAjouterTransporteur_Load(sender, e);




        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result;

            if (dataGridView1.Rows.Count > 0)
            {
                result = MessageBox.Show("Il existe déjà un Tronsporteur de meme Nom Es-tu sur de vouloir Ajouter?", "Confirm", MessageBoxButtons.YesNo);
            }
            else
            {
                result = MessageBox.Show("Es-tu sur de vouloir Ajouter?", "Confirm", MessageBoxButtons.YesNo);
            }

            if (result == DialogResult.Yes)
            {
                if (nomtr.Text.Length > 2 && adresstr.Text.Length > 2)
                {
                    if (!connectbd.DoesTransporteurExist(Numtxt.Text))
                    {
                        transporteur tr = new transporteur(Numtxt.Text.Trim(), nomtr.Text.Trim(), adresstr.Text.Trim(), disc.Text.Trim());
                        foreach (var item in ListeChauff.Items)
                        {
                            Chauffeur chauffeur = new Chauffeur(Numtxt.Text.Trim(), item.ToString().Trim());
                            connectbd.AjouterChauffeur(chauffeur);


                        }
                        ListeChauff.Items.Clear();
                        connectbd.AjouterTronsporteur(tr);



                        Numtxt.Text = "T" + (connectbd.NumTronsporteur()).ToString();
                        clear();
                    }
                    else MessageBox.Show("Svp Verifier les cordonner ");
                }
                else
                {
                    foreach (var item in ListeChauff.Items)
                    {
                        Chauffeur chauffeur = new Chauffeur(Numtxt.Text.Trim(), item.ToString().Trim());
                        if (!connectbd.DoesChauffeurExiste(chauffeur))
                            connectbd.AjouterChauffeur(chauffeur);
                        
                          

                    }
                    ListeChauff.Items.Clear();
                    transporteur tr = new transporteur(Numtxt.Text.Trim(), nomtr.Text.Trim(), adresstr.Text.Trim(), disc.Text.Trim());
                    connectbd.UpdateTransporteur(tr);


                }
            }
            else
            {
                clear();// The user clicked "No", so do something else here
            }
        }
        public void clear()
        {

            adresstr.Text = string.Empty;
            nomtr.Text = string.Empty;
            disc.Text = string.Empty;

           


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void AddbtnChauffeur_Click(object sender, EventArgs e)
        {
            bool existe = false;
            foreach (var item in ListeChauff.Items)
            {
                if (item.ToString() == TextChauffeur.Text)
                {
                    existe= true;
                }
            }





            if (!existe)
            {
                ListeChauff.Items.Add(TextChauffeur.Text);
               
            }
            else
                MessageBox.Show("Cette cauffeur existe deja ");
            TextChauffeur.Text = string.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListeChauff.Items.Remove(ListeChauff.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Affiche un message de dialogue avec des boutons "Oui" et "Non"
            DialogResult result = MessageBox.Show("vous voulez vous enregistrer?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Vérifie la réponse de l'utilisateur
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Vous avez répondu Oui !");
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Vous avez répondu Non !");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void Numtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                Numtxt.Text = row.Cells["code_trs"].Value.ToString();
                // numfrsResh.Text = row.Cells["num"].Value.ToString();
                disc.Text = row.Cells["description"].Value.ToString();
                adresstr.Text = row.Cells["adresse"].Value.ToString();
                nomtr.Text = row.Cells["nom_trs"].Value.ToString();



                button2.Enabled = false;


                ListeChauff.Items.AddRange(connectbd.RechercheChauffeur(Numtxt.Text).ToArray());

            }

            FormAjouterTransporteur_Load(sender, e);


        }
    }
}
