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
    public partial class ListeProdruit : Form
    {
        public string SelectedItem { get; set; }
        public ListeProdruit()
        {
            InitializeComponent();
            DataTable dataTable = connectbd.RecherchListeProduit();
            foreach (DataRow row in dataTable.Rows)
            {
                // Concaténez les valeurs des deux colonnes avec un séparateur de votre choix (ici, une virgule)
                string itemText = row["code_prd"].ToString() + "  |  " + row["nom_prd"].ToString();
                Listeprd.Items.Add(itemText);
            }
        }

        private void Listeprd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Listeprd.SelectedIndex >= 0)
            {
                SelectedItem = Listeprd.SelectedItem.ToString();
                button1.Enabled = true;
            }
        }

        private void Recherch_TextChanged(object sender, EventArgs e)
        {
            Listeprd.Items.Clear();
            DataTable dataTable = connectbd.RechercheListeProduit(Recherch.Text);
            foreach (DataRow row in dataTable.Rows)
            {
                // Concaténez les valeurs des deux colonnes avec un séparateur de votre choix (ici, une virgule)
                string itemText = row["code_prd"].ToString() + "  |  " + row["nom_prd"].ToString();
                Listeprd.Items.Add(itemText);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RechercheProduit form = Application.OpenForms.OfType<RechercheProduit>().FirstOrDefault();
            FormBoncs form1 = Application.OpenForms.OfType<FormBoncs>().FirstOrDefault();
            FormModification form2 = Application.OpenForms.OfType<FormModification>().FirstOrDefault();
            if (form1 != null)
            {
                // Utilisez une méthode ou une propriété de la Form1 pour envoyer l'élément sélectionné
                int index = SelectedItem.IndexOf('|'); // Trouve la position de la première occurrence du caractère "|"
                string sousChaine = SelectedItem.Substring(0, index-2);
                form1.UpdateTextBoxPr(sousChaine);
                this.Close();
            }
            else if (form2 != null)
            {

                int index = SelectedItem.IndexOf('|') - 2; // Trouve la position de la première occurrence du caractère "|"
                string sousChaine = SelectedItem.Substring(0, index);
                form2.UpdateTextBoxPr(sousChaine);
                this.Close();


            }
            else if (form != null)
            {

                int index = SelectedItem.IndexOf('|') - 2; // Trouve la position de la première occurrence du caractère "|"
                string sousChaine = SelectedItem.Substring(0, index);
                form.UpdateTextBoxPr(sousChaine);
                this.Close();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormProduit f = new FormProduit();
            f.Show();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            Listeprd.Items.Clear();
            DataTable dataTable = connectbd.RechercheListeProduit(Recherch.Text);
            foreach (DataRow row in dataTable.Rows)
            {
                // Concaténez les valeurs des deux colonnes avec un séparateur de votre choix (ici, une virgule)
                string itemText = row["code_prd"].ToString() + "  |  " + row["nom_prd"].ToString();
                Listeprd.Items.Add(itemText);
            }
        }
    }
}
