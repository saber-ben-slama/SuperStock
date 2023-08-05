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
    public partial class RechercheProduit : Form
    {
        public RechercheProduit()
        {

            InitializeComponent();
            datagrid.ColumnHeadersHeight = 25;
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

        private void RechercheProduit_Load(object sender, EventArgs e)
        {

        }
        public void UpdateTextBoxPr(string text)
        {
            // Mettez à jour le texte du TextBox nommé "mat"
            codepr.Text = text;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(checkboks.SelectedIndex==0)
            {
                pr.Enabled = true;
                codepr.Enabled = true;
                pr.Enabled = true;
                nompr.Enabled = true;
                codetr.Enabled = false;
                tr.Enabled = false;
                 nomtr.Enabled = false;
                mat.Enabled = false;
                codemat.Enabled = false;
                codefr.Enabled = false;
                fr.Enabled = false;
                nomfr.Enabled = false;
                textboxBon.Enabled = false;




            }
            else if (checkboks.SelectedIndex == 1)
            {
                codepr.Enabled = true;
                pr.Enabled = true;
                nompr.Enabled = true;
                codetr.Enabled = true;
                tr.Enabled = true;
                nomtr.Enabled = true;
                mat.Enabled = true;
                codemat.Enabled = true;
                codefr.Enabled = true;
                fr.Enabled = true;
                nomfr.Enabled = true;
                textboxBon.Enabled = false;




            }
            else if (checkboks.SelectedIndex == 4)
            {
                codepr.Enabled = false;
                pr.Enabled = false;
                nompr.Enabled = false;
                codetr.Enabled = false;
                tr.Enabled = false;
                nomtr.Enabled = false;
                mat.Enabled = false;
                codemat.Enabled = false;
                codefr.Enabled = false;
                fr.Enabled = false;
                nomfr.Enabled = false;
                textboxBon.Enabled = true;




            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (checkboks.SelectedIndex == 0)
            {
                if (nompr.Text == "")
                    MessageBox.Show("SVP Remplire Le Champ Produit");
                else
                {
                    if (ch1.Checked == true && ch2.Checked == false)
                    {
                        DateTime selectedDate = date1.Value;
                        DataTable maDataTable = connectbd.RechercheProduit(codepr.Text.Trim(), selectedDate);
                        datagrid.DataSource = maDataTable;


                    }
                    else if (ch2.Checked == true && ch1.Checked == false)
                    {
                        DateTime selectedDate = date2.Value;
                        DataTable maDataTable = connectbd.RechercheProduit1(codepr.Text.Trim(), selectedDate);
                        datagrid.DataSource = maDataTable;


                    }
                    else if (ch2.Checked == true && ch1.Checked == true)
                    {
                        DateTime selectedDate = date1.Value;
                        DateTime selectedDate2 = date2.Value;
                        DataTable maDataTable = connectbd.RechercheProduit1(codepr.Text.Trim(), selectedDate, selectedDate2);
                        datagrid.DataSource = maDataTable;



                    }
                    else
                    {

                        DataTable maDataTable = connectbd.RechercheProduit(codepr.Text.Trim());
                        datagrid.DataSource = maDataTable;



                    }




                }
            }
            else if (checkboks.SelectedIndex == 4)
            {
                DataTable maDataTable = connectbd.RechercheMatBon(textboxBon.Text.Trim());
                datagrid.DataSource = maDataTable;
            }

        }
    }
}
