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
    public partial class FormProduit : Form
    {
        public FormProduit()
        {
            InitializeComponent();
            
        }

        private void AddbtnChauffeur_Click(object sender, EventArgs e)
        {
            bool existe = false;
            if (nom_prd.Text.Length > 0)
            {
                foreach (var item in Lsproduit.Items)
                {
                    if (item.ToString() == nom_prd.Text)
                    {
                        existe = true;
                    }
                }





                if (!existe)
                {
                    Lsproduit.Items.Add(nom_prd.Text);
                    Produit pr = new Produit(code_prd.Text, nom_prd.Text);
                    connectbd.AjouterProduit(pr);
                    code_prd.Text = Convert.ToString(connectbd.NumProduit());
                    nom_prd.Text = String.Empty;
                   
                }
                else
                    MessageBox.Show("Cette Produit existe deja ");
              
            }else
                MessageBox.Show("Nom de Produit est Vide ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (connectbd.DoesproduitExist2(Lsproduit.SelectedItem.ToString()))
            {

                MessageBox.Show("Il y a des Bon contian cette Produit impossible de supprimer");

            }
            else
            {
                connectbd.supprimerProduit(Lsproduit.SelectedItem.ToString());
                Lsproduit.Items.Clear();
                FormProduit_Load(sender, e);
            }
        }

        private void FormProduit_Load(object sender, EventArgs e)
        {
            List<string> produits = connectbd.NomProduit();
            foreach (string produit in produits)
            {
                Lsproduit.Items.Add(produit);
            }
            code_prd.Text = Convert.ToString(connectbd.NumProduit());

        }
    }
}
