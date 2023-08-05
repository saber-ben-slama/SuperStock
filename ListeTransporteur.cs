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
   
    public partial class ListeTransporteur : Form
    {
        public string SelectedItem { get; set; }
        public ListeTransporteur()
        {
            InitializeComponent();
            DataTable dataTable = connectbd.RecherchListeTransporrteur();
            foreach (DataRow row in dataTable.Rows)
            {
                // Concaténez les valeurs des deux colonnes avec un séparateur de votre choix (ici, une virgule)
                string itemText = row["code_trs"].ToString() + "  |  " + row["nom_trs"].ToString() ;
                Listetrs.Items.Add(itemText);
            }
        }

        private void ListeTransporteur_Load(object sender, EventArgs e)
        {

        }

        private void Listetrs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Listetrs.SelectedIndex >=0)
            {
                SelectedItem = Listetrs.SelectedItem.ToString();
                button1.Enabled = true;
            }
        }

        private void Recherch_TextChanged(object sender, EventArgs e)
        {
            Listetrs.Items.Clear();
            DataTable dataTable = connectbd.RechercheListetransporteur(Recherch.Text);
            foreach (DataRow row in dataTable.Rows)
            {
                // Concaténez les valeurs des deux colonnes avec un séparateur de votre choix (ici, une virgule)
                string itemText = row["code_trs"].ToString() + "  |  " + row["nom_trs"].ToString() ;
                Listetrs.Items.Add(itemText);
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
                string sousChaine = SelectedItem.Substring(0, index-2);
                form1.UpdateTextBoxTr(sousChaine);
                this.Close();
            }
            else
            {

                int index = SelectedItem.IndexOf('|') - 2; // Trouve la position de la première occurrence du caractère "|"
                string sousChaine = SelectedItem.Substring(0, index);
                form2.UpdateTextBoxTr(sousChaine);
                this.Close();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAjouterTransporteur f = new FormAjouterTransporteur();
            f.Show();
        }
    }
}
