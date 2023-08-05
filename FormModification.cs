using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PFA
{
    public partial class FormModification : Form
    {
        public FormModification()
        {
            InitializeComponent();
           
        }

        private void FormAnnulation_Load(object sender, EventArgs e)
        {
            mat.Enabled = false;
            codemat.Enabled = false;
            tr.Enabled = false;
            codetr.Enabled = false;
            nomtr.Enabled = false;
            pr.Enabled = false;
            codepr.Enabled = false;
            nompr.Enabled = false;
            brut.Enabled = false;
            tare.Enabled = false;
            net.Enabled = false;
            enreg.Enabled = false;

            etat.Enabled = false;
            chauffeur.Enabled = false;
            fr.Enabled = false;
            codefr.Enabled = false;
            nomfr.Enabled = false;





            codemat.Text = "";

            codetr.Text = "";
            nomtr.Text = "";

            codepr.Text = "";
            nompr.Text = "";
           // brut.Text = "";
           // tare.Text = "";
           // net.Text = "";



            chauffeur.Items.Clear();

            codefr.Text = "";
            nomfr.Text = "";

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string texte = textboxBon.Text;
            texte = texte.Replace(" ", "");
            if (connectbd.DoesBonExist(texte))
            {
                mat.Enabled = true;
                codemat.Enabled = true;
                tr.Enabled = true;
                codetr.Enabled = true;
                nomtr.Enabled = true;
                pr.Enabled = true;
                codepr.Enabled = true;
                nompr.Enabled = true;
                brut.Enabled = true;
                tare.Enabled = true;
                
                enreg.Enabled = true;

                etat.Enabled = true;
                chauffeur.Enabled = true;
                fr.Enabled = true;
                codefr.Enabled = true;
                nomfr.Enabled = true;


                DataTable maDataTable = connectbd.RechercheMatBon(textboxBon.Text.Trim());
                DataRow dr = maDataTable.Rows[0];
                codemat.Text = dr["mat"].ToString();
                codefr.Text = dr["code_frs"].ToString();
                codetr.Text = dr["code_trs"].ToString();
                codepr.Text = dr["code_prd"].ToString();
                string etate = dr["etat"].ToString();
                if (etate == "Annuler")
                    etat.SelectedIndex = 1;
                else etat.SelectedIndex = 0;

                chauffeur.SelectedItem = dr["nom_ch"].ToString();

                tare.Text = dr["poid_tare"].ToString();
                brut.Text = dr["poid_brut"].ToString();
                //net.Text = dr["poid_net"].ToString();

            }
            else
            {
                mat.Enabled = false;
                codemat.Enabled = false;
                tr.Enabled = false;
                codetr.Enabled = false;
                nomtr.Enabled = false;
                pr.Enabled = false;
                codepr.Enabled = false;
                nompr.Enabled = false;
                brut.Enabled = false;
                tare.Enabled = false;
             
                enreg.Enabled = false;

                etat.Enabled = false;
                chauffeur.Enabled = false;
                fr.Enabled = false;
                codefr.Enabled = false;
                nomfr.Enabled = false;


                MessageBox.Show("Cette Bon n'existe Pas ");

            }
          

        }

        private void textboxBon_TextChanged(object sender, EventArgs e)
        {
            FormAnnulation_Load(sender, e);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void UpdateTextBox(string text)
        {
            // Mettez à jour le texte du TextBox nommé "mat"
            codemat.Text = text;
        }
        public void UpdateTextBoxPr(string text)
        {
            // Mettez à jour le texte du TextBox nommé "mat"
            codepr.Text = text;
        }
        public void UpdateTextBoxTr(string text)
        {
            // Mettez à jour le texte du TextBox nommé "mat"
            codetr.Text = text;
        }

        private void mat_Click(object sender, EventArgs e)
        {
            ListCamion l = new ListCamion();
            l.Show();
        }

        private void pr_Click(object sender, EventArgs e)
        {
            ListeProdruit l = new ListeProdruit();
            l.Show();

        }

        private void codepr_TextChanged(object sender, EventArgs e)
        {

            if (codepr.Text.Length > 0 && connectbd.DoesproduitExist(codepr.Text))
            {
                nompr.Text = connectbd.RemplireBonNomPrd(codepr.Text);

            }
            else
            {
                nompr.Text = String.Empty;

            }
        }

        private void tr_Click(object sender, EventArgs e)
        {
            ListeTransporteur l = new ListeTransporteur();
            l.Show();
        }

        private void codefr_TextChanged(object sender, EventArgs e)
        {
            nomfr.Text = connectbd.RechercheBonNomFornisseur(codefr.Text);
        }
        public void UpdateTextBoxFr(string text)
        {
            // Mettez à jour le texte du TextBox nommé "mat"
            codefr.Text = text;
        }


        private void fr_Click(object sender, EventArgs e)
        {
            ListeFournisseur l = new ListeFournisseur();
            l.Show();
        }

        private void codetr_TextChanged(object sender, EventArgs e)
        {
            if (codetr.Text.Length > 0 && connectbd.DoesTransporteurExist(codetr.Text))
            {
                nomtr.Text = connectbd.RemplireBonNomTrs(codetr.Text);
                chauffeur.Items.Clear();
                foreach (string s in connectbd.RechercheChauffeur(codetr.Text))

                    chauffeur.Items.Add(s);




            }
            else
            {
                nomtr.Text = String.Empty;
                chauffeur.Items.Clear();
            }
        }

        private void enreg_Click(object sender, EventArgs e)
        {
            codetr.FillColor = Color.White;
            codefr.FillColor = Color.White;
            codepr.FillColor = Color.White;
            codemat.FillColor= Color.White;
            if (codemat.Text == "" || !connectbd.DoesMatriculeExist(codemat.Text.Trim()))
            {
                codemat.Text = "";
                MessageBox.Show("Matricule N'existe pas ou Vide", "Erreur de saisie");
                codemat.Focus();
                codemat.FillColor = Color.LightCoral;
            }
            else if (codetr.Text == "" || !connectbd.DoesTransporteurExist(codetr.Text.Trim()))
            {
                codetr.FillColor = Color.White;
                codetr.Text = "";
                codetr.Focus();
                codetr.FillColor = Color.LightCoral;
                MessageBox.Show("Transporteur N'existe pas ou Vide", "Erreur de saisie");

            }
            else if (codefr.Text == "" || !connectbd.DoesFournisseurExist(codefr.Text.Trim()))
            {
                codetr.FillColor = Color.White;
                codefr.FillColor = Color.White;
                codefr.Text = "";
                codefr.Focus();
                codefr.FillColor = Color.LightCoral;
                MessageBox.Show("Fournisseur N'existe pas ou Vide", "Erreur de saisie");


            }
            else if (codepr.Text == "" || !connectbd.DoesproduitExist(codepr.Text.Trim()))
            {
                codetr.FillColor = Color.White;
                codefr.FillColor = Color.White;
                codepr.FillColor = Color.White;
                codepr.Text = "";

                codepr.Focus();
                codepr.FillColor = Color.LightCoral;
                MessageBox.Show("Produit N'existe pas ou Vide", "Erreur de saisie");

            }
            else
            {

                string type = "Achat";



                Bon bn = new Bon(textboxBon.Text, codemat.Text, codefr.Text, codetr.Text, codepr.Text, brut.Text, tare.Text, net.Text, chauffeur.SelectedItem.ToString(), etat.SelectedItem.ToString(), type, "", "", Convert.ToDateTime("20/11/2022"));
                connectbd.UpdateBonModification(bn);
            }

        }

        private void brut_TextChanged(object sender, EventArgs e)
        {if (brut.Text.Length == 0)
                brut.Text = "0";
            if (tare.Text != "")
                if (Convert.ToDouble(tare.Text) > Convert.ToDouble(brut.Text))
                    net.Text = Convert.ToString(Convert.ToDouble(tare.Text) - Convert.ToDouble(brut.Text));
                else
                    net.Text = Convert.ToString(Convert.ToDouble(brut.Text) - Convert.ToDouble(tare.Text));
            else
                net.Text = Convert.ToString(brut.Text);
        }

        private void tare_TextChanged(object sender, EventArgs e)
        {
            if (tare.Text.Length == 0)
                tare.Text = "0";
           


                if (brut.Text != "")
                if (Convert.ToDouble(tare.Text) > Convert.ToDouble(brut.Text))
                    net.Text = Convert.ToString(Convert.ToDouble(tare.Text) - Convert.ToDouble(brut.Text));
                else
                    net.Text = Convert.ToString(Convert.ToDouble(brut.Text) - Convert.ToDouble(tare.Text));
            else
                net.Text = Convert.ToString(tare.Text);
        }

        private void nompr_TextChanged(object sender, EventArgs e)
        {

        }
    }
}