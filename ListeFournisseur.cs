using ServiceStack;
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
    public partial class ListeFournisseur : Form
    {
        public string SelectedItem { get; set; }
        public ListeFournisseur()
        {
            InitializeComponent();
            DataTable dataTable = connectbd.RecherchListeFournisseur();
            foreach (DataRow row in dataTable.Rows)
            {
                // Concaténez les valeurs des deux colonnes avec un séparateur de votre choix (ici, une virgule)
                string itemText = row["code_frs"].ToString() + "  |  " + row["nom_frs"].ToString() + "  |  " + row["adresse"].ToString();
                Listefourn.Items.Add(itemText);
            }
        }

        private void Recherch_TextChanged(object sender, EventArgs e)
        {
            Listefourn.Items.Clear();
            DataTable dataTable = connectbd.RechercheListeFournisseur(Recherch.Text);
            foreach (DataRow row in dataTable.Rows)
            {
                // Concaténez les valeurs des deux colonnes avec un séparateur de votre choix (ici, une virgule)
                string itemText = row["code_frs"].ToString() + "  |  " + row["nom_frs"].ToString() + "  |  " + row["adresse"].ToString();
                Listefourn.Items.Add(itemText);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBoncs form1 = Application.OpenForms.OfType<FormBoncs>().FirstOrDefault();
            FormModification form2 = Application.OpenForms.OfType<FormModification>().FirstOrDefault();
            if (form1 != null)
            {
                // Utilisez une méthode ou une propriété de la Form1 pour envoyer l'élément sélectionné
                int index = SelectedItem.IndexOf('|'); // Trouve la position de la première occurrence du caractère "|"
                string sousChaine = SelectedItem.Substring(0, index);
               sousChaine = sousChaine.Replace(" ", "");
                form1.UpdateTextBoxFr(sousChaine);
                this.Close();
            }
            else
            {

                int index = SelectedItem.IndexOf('|') - 2; // Trouve la position de la première occurrence du caractère "|"
                string sousChaine = SelectedItem.Substring(0, index);
                form2.UpdateTextBoxFr(sousChaine);
                this.Close();


            }
        }

        private void Listefourn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Listefourn.SelectedIndex >= 0)
            {
                SelectedItem = Listefourn.SelectedItem.ToString();
                button1.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAjouterFournisseur f = new FormAjouterFournisseur();
            f.Show();
        }
    }
}
