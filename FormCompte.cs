using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.BunifuCheckBox.Transitions;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PFA
{
    public partial class FormCompte : Form
    {
        public FormCompte()
        {
            InitializeComponent();

        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            login lg = new login(adresse.Text, mp.Text, Convert.ToString(typee.Value), nom.Text);
            if (adresse.Text == "" || mp.Text == "" | nom.Text == "")
                MessageBox.Show("Il y a une champ Vide ");
            else
            if (connectbd.DoesCompteExiste(adresse.Text))
            {
                connectbd.UpdateCompte(lg);
                adresse.Text = "";
                mp.Text = "";
                nom.Text = "";

                FormCompte_Load(sender, e);


            }
            else
            {
                connectbd.AjouterCompte(lg);
                adresse.Text = "";
                mp.Text = "";
                nom.Text = "";

                FormCompte_Load(sender, e);

            }

        }

        private void FormCompte_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.ColumnHeadersHeight = 25;
            guna2DataGridView1.DataSource = connectbd.Comptes();
            guna2DataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);
            guna2DataGridView1.Columns[0].HeaderText = "Adresse";
            guna2DataGridView1.Columns[1].HeaderText = "MotPasse";
            guna2DataGridView1.Columns[2].HeaderText = "Type";
            guna2DataGridView1.Columns[3].HeaderText = "Nom";
        }

        private void Exit_Click(object sender, EventArgs e)
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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.guna2DataGridView1.Rows[e.RowIndex];
                adresse.Text = row.Cells["Adresse"].Value.ToString();
                mp.Text = row.Cells["MotPasse"].Value.ToString();
                typee.Value = Convert.ToInt32(row.Cells["Type"].Value);
                nom.Text = row.Cells["Nom"].Value.ToString();




            }
        } 
        
    }
}
