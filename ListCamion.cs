using MySqlX.XDevAPI.Relational;
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
    public partial class ListCamion : Form
    {
        public string SelectedItem { get; set; }
        public ListCamion()
        {
            InitializeComponent();
            DataTable dataTable = connectbd.RechercheCamion();
            foreach (DataRow row in dataTable.Rows)
{
                // Concaténez les valeurs des deux colonnes avec un séparateur de votre choix (ici, une virgule)
                string itemText = row["mat"].ToString() + "  |  " + row["nom_trs"].ToString();
                listBox1.Items.Add(itemText);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DataTable dataTable = connectbd.RechercheListeCamion(Recherch.Text);
            foreach (DataRow row in dataTable.Rows)
            {
                // Concaténez les valeurs des deux colonnes avec un séparateur de votre choix (ici, une virgule)
                string itemText = row["mat"].ToString() + "  |  " + row["nom_trs"].ToString();
                listBox1.Items.Add(itemText);
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                SelectedItem = listBox1.SelectedItem.ToString();
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCamion f = new FormCamion();
            f.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormBoncs form1 = Application.OpenForms.OfType<FormBoncs>().FirstOrDefault();
            FormModification form2 = Application.OpenForms.OfType<FormModification>().FirstOrDefault();
            if (form1 != null)
            {
                // Utilisez une méthode ou une propriété de la Form1 pour envoyer l'élément sélectionné
                int index = SelectedItem.IndexOf('|') - 2; // Trouve la position de la première occurrence du caractère "|"
                string sousChaine = SelectedItem.Substring(0, index);
                form1.UpdateTextBox(sousChaine);
                this.Close();
            }
            else
            {

                int index = SelectedItem.IndexOf('|') - 2; // Trouve la position de la première occurrence du caractère "|"
                string sousChaine = SelectedItem.Substring(0, index);
                form2.UpdateTextBox(sousChaine);
                this.Close();


            }
        }

       

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DataTable dataTable = connectbd.RechercheListeCamion(Recherch.Text);
            foreach (DataRow row in dataTable.Rows)
            {
                // Concaténez les valeurs des deux colonnes avec un séparateur de votre choix (ici, une virgule)
                string itemText = row["mat"].ToString() + "  |  " + row["nom_trs"].ToString();
                listBox1.Items.Add(itemText);
            }
        }
    }
}
