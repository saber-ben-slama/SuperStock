using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFA
{
    public partial class FormCamion : Form
    {
        public FormCamion()
        {
            InitializeComponent();
            guna2DataGridView1.ColumnHeadersHeight = 25;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAjouterTransporteur f = new FormAjouterTransporteur();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FormAjouterFournisseur f = new FormAjouterFournisseur();
            f.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            NomTrLabel.Text=connectbd.RechercheTransportCamion("T"+NumTr.Text);
        }

        private void NomTrLabel_Click(object sender, EventArgs e)
        {

        }

       

        private void Ajouter_Click(object sender, EventArgs e)
        {


            if (mat.Text.Length > 0&&NumTr.Text.Length>0)

            {
                Camion c = new Camion(mat.Text, ("T"+NumTr.Text),("F"+NumFr.Text));
                connectbd.AjouterCamion(c);
            }
            else
            {

                MessageBox.Show("Verifier les cordonner svp");

            }
        }

        private void mat_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = connectbd.RechercheCamion(mat.Text.Trim());

            guna2DataGridView1.Columns["mat"].HeaderText = "Matricule";
            guna2DataGridView1.Columns["nom_frs"].HeaderText = "Fournisseur";
            guna2DataGridView1.Columns["nom_trs"].HeaderText = "Transporteur";
            
            FormCamion_Load(sender, e);
        }
       

        private void FormCamion_Load(object sender, EventArgs e)
        {

        }

     

        private void button2_Click_1(object sender, EventArgs e)
        {
            FormAjouterFournisseur f = new FormAjouterFournisseur();
            f.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NomFrLabel.Text = connectbd.RechercheFornisseurCamion(NumFr.Text);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.guna2DataGridView1.Rows[e.RowIndex];
                mat.Text = row.Cells["mat"].Value.ToString();
                NumFr.Text = connectbd.RechercheCodFrCamion(mat.Text).ToString();
                NumTr.Text = connectbd.RechercheCodTrsCamion(mat.Text).ToString();


            }
            FormCamion_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
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
    }
}
