using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PFA
{
    public partial class FormAjouterFournisseur : Form
    {
        public FormAjouterFournisseur()
        {
            InitializeComponent();
            Numtxt.Text = "F"+Convert.ToString(connectbd.NumFotrnisseur());
            dataGridView1.DataSource = connectbd.RechercheFournisseur();
            dataGridView1.ColumnHeadersHeight = 25;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult result;
            if (dataGridView1.Rows.Count > 0)
            {
                result = MessageBox.Show("Il existe déjà un fournisseur de meme Nom Es-tu sur de vouloir Ajouter?", "Confirm", MessageBoxButtons.YesNo);
            }
            else
            {
                result = MessageBox.Show("Es-tu sur de vouloir Ajouter?", "Confirm", MessageBoxButtons.YesNo);
            }

            if (result == DialogResult.Yes)
            {
                if (nomfr.Text.Length > 2 && adressfr.Text.Length > 2)
                {
                    fournisseur fr = new fournisseur(Numtxt.Text, nomfr.Text.Trim(), adressfr.Text.Trim(), disc.Text.Trim());

                    connectbd.AjouterFournisseur(fr);

                    Numtxt.Text ="F"+ (connectbd.NumFotrnisseur()).ToString();
                    clear();
                }
                else MessageBox.Show("Svp Verifier les cordonner ");
            }
            else
            {
                clear();// The user clicked "No", so do something else here
            }

        }

        private void FormAjouterFournisseur_Load(object sender, EventArgs e)
        {


           // dataGridView1.DataSource = connectbd.RechercheFournisseur();
        }

        private void nomfr_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = connectbd.RechercheFournisseur(nomfr.Text.Trim());
            FormAjouterFournisseur_Load(sender, e);

        }

        private void adressfr_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                Numtxt.Text = row.Cells["Num"].Value.ToString();
                // numfrsResh.Text = row.Cells["num"].Value.ToString();
                disc.Text = row.Cells["description"].Value.ToString();
                adressfr.Text = row.Cells["Adresse"].Value.ToString();
                nomfr.Text = row.Cells["Nom"].Value.ToString();
            }
            FormAjouterFournisseur_Load(sender, e);
            recherche.Checked = false;

            button4.Enabled = true;
            numfrsResh.Visible = false;
            Numtxt.Visible = true;
            button2.Visible = false;


        }
        public void clear()
        {

            adressfr.Text = string.Empty;
            nomfr.Text = string.Empty;
            disc.Text = string.Empty;

            button4.Enabled = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            Numtxt.Text ="F"+ (connectbd.NumFotrnisseur()).ToString();
            recherche.Checked = false;
            button2.Visible = true;
            FormAjouterFournisseur_Load(sender, e);
        }

        private void recherche_CheckedChanged(object sender, EventArgs e)
        {
            if (recherche.Checked == true)
            {
                Numtxt.Visible = false;
                numfrsResh.Visible = true;

            }
            else
            {

                numfrsResh.Visible = false;
                Numtxt.Visible = true;
                numfrsResh.Text = string.Empty;


            }
            button2.Visible = false;
        }

        private void Numtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void numfrsResh_TextChanged(object sender, EventArgs e)
        {
            if (numfrsResh.Text != "")
            {
                int result;
                if (!int.TryParse(numfrsResh.Text, out result))
                {
                    MessageBox.Show("Please enter a valid number.");
                    numfrsResh.Text = String.Empty;

                }
                else
                {
                    dataGridView1.DataSource = connectbd.RechercheFournisseurNUM(Convert.ToInt32(numfrsResh.Text.Trim()));
                    FormAjouterFournisseur_Load(sender, e);
                    adressfr.Text = string.Empty;
                    nomfr.Text = string.Empty;
                    disc.Text = string.Empty;


                    button4.Enabled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(" Es-tu sur de vouloir Modifier?", "Confirm", MessageBoxButtons.YesNo);



            if (result == DialogResult.Yes)
            {
                if (nomfr.Text.Length > 2 && adressfr.Text.Length > 2)
                {
                    fournisseur fr = new fournisseur(Numtxt.Text.Trim(), nomfr.Text.Trim(), adressfr.Text.Trim(), disc.Text.Trim());

                    connectbd.ModifierFournisseur(fr);

                    Numtxt.Text = "F"+(connectbd.NumFotrnisseur()).ToString();
                    clear();
                }
                else MessageBox.Show("Svp Verifier les cordonner ");
            }
            else
            {
                clear();// The user clicked "No", so do something else here
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if (nomfr.Text != "" || adressfr.Text != "")
            {
                result = MessageBox.Show("Il y a des données non enregistré Es-tu sûr de vouloir Sortie?", "FAIRE ATTENTION", MessageBoxButtons.YesNo);
            }
            else
            {
                result = MessageBox.Show(" Es-tu sûr de vouloir Sortie?", "Confirm", MessageBoxButtons.YesNo);
            }
            if (result == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                Numtxt.Text = row.Cells["Num"].Value.ToString();
                // numfrsResh.Text = row.Cells["num"].Value.ToString();
                disc.Text = row.Cells["description"].Value.ToString();
                adressfr.Text = row.Cells["Adresse"].Value.ToString();
                nomfr.Text = row.Cells["Nom"].Value.ToString();
            }
            FormAjouterFournisseur_Load(sender, e);
            recherche.Checked = false;

            button4.Enabled = true;
            numfrsResh.Visible = false;
            Numtxt.Visible = true;
            button2.Visible = false;

        }
    }
}
