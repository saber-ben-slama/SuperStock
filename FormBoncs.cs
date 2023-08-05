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
    public partial class FormBoncs : Form
    {
        public FormBoncs()
        {
            InitializeComponent();
          
        }
        public void UpdateTextBox(string text)
        {
            // Mettez à jour le texte du TextBox nommé "mat"
            mat.Text = text;
        }
        public void Updateps2(string text)
        {
            // Mettez à jour le texte du TextBox nommé "mat"
            poid2.Text = text;
            date2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            poid2.Enabled = false;
           
            button6.Enabled = false;
            if (poids.Text == "")
                poids.Text = text;
            else
            {
                if (Convert.ToDouble(poids.Text) > Convert.ToDouble(poid2.Text))
                    poids.Text = Convert.ToString(Convert.ToDouble(poids.Text) - Convert.ToDouble(poid2.Text));
                else
                    poids.Text = Convert.ToString(Convert.ToDouble(poid2.Text) - Convert.ToDouble(poids.Text));

            }
        }
        public void Updateps1(string text)
        {
            // Mettez à jour le texte du TextBox nommé "mat"
            poid1.Text = text;
            date1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            poid1.Enabled = false;
           
            button1.Enabled = false;
            if (poids.Text == "")
                poids.Text = text;
            else
            {
                if (Convert.ToDouble(poids.Text) > Convert.ToDouble(poid1.Text))
                    poids.Text = Convert.ToString(Convert.ToDouble(poids.Text) - Convert.ToDouble(poid1.Text));
                else
                    poids.Text = Convert.ToString(Convert.ToDouble(poid1.Text)- Convert.ToDouble(poids.Text) );

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Pesage f = new Pesage();
            f.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListCamion l = new ListCamion();
            l.Show();
        }

        private void mat_TextChanged(object sender, EventArgs e)
        {
            Codetrs.Text = connectbd.RemplireBonAvec(mat.Text).ToString();
            Codefrs.Text = connectbd.RechercheBonCodeFornisseur(mat.Text);

        }

        private void Codetrs_TextChanged(object sender, EventArgs e)
        {
          
            if (Codetrs.Text.Length > 0 && connectbd.DoesTransporteurExist(Codetrs.Text))
            {
                NomTrs.Text = connectbd.RemplireBonNomTrs(Codetrs.Text);
                comboBoxCh.Items.Clear();
                foreach (string s in connectbd.RechercheChauffeur(Codetrs.Text))
                    
                comboBoxCh.Items.Add(s);

                
                
               
            }
            else
            {
                NomTrs.Text = String.Empty;
                comboBoxCh.Items.Clear();
            }

        }

        private void Codefrs_TextChanged(object sender, EventArgs e)
        {
            Nomfrs.Text = connectbd.RechercheBonNomFornisseur(Codefrs.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListeFournisseur f = new ListeFournisseur();
            f.ShowDialog();
        }
        public void UpdateTextBoxFr(string text)
        {
            // Mettez à jour le texte du TextBox nommé "mat"
            Codefrs.Text = text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListeTransporteur f = new ListeTransporteur();
            f.ShowDialog();
        }
        public void UpdateTextBoxTr(string text)
        {
            // Mettez à jour le texte du TextBox nommé "mat"
            Codetrs.Text = text;
        }
        public void UpdateTextBoxPr(string text)
        {
            // Mettez à jour le texte du TextBox nommé "mat"
            codepr.Text = text;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ListeProdruit f = new ListeProdruit();
            f.ShowDialog();
        }

        private void codepr_TextChanged(object sender, EventArgs e)
        {

            if (codepr.Text.Length > 0 &&   connectbd.DoesproduitExist(codepr.Text))
            {
                nomprd.Text = connectbd.RemplireBonNomPrd(codepr.Text);
                
            }
            else
            {
                nomprd.Text = String.Empty;
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pesage2 p = new Pesage2();
            p.ShowDialog();
          
            
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typebon.SelectedIndex == 1)
            {
                groupBox2.BackColor = Color.Red;
                groupBox1.BackColor = Color.Crimson;
                groupBox3.BackColor = Color.LightCoral;


            }
            else
            {
                groupBox2.BackColor = Color.GreenYellow;
                groupBox1.BackColor = Color.Green;
                groupBox3.BackColor = Color.MediumSeaGreen;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FormBoncs_Load(sender, e);
            mat.Text = "";
            Codefrs.Text = "";
            Codetrs.Text = "";
            codepr.Text = "";
            poid1.Text = "";
            poid2.Text = "";
            date1.Text = "";
            date2.Text = "";
            button1.Enabled = true;
            button6.Enabled = true;
            poids.Text = "";
        }

        private void FormBoncs_Load(object sender, EventArgs e)
        {
         
            Datejour.Text = DateTime.Now.ToString("dd - MM - yyyy");
            etat.SelectedIndex = 0;
            code.Text = "B" + Convert.ToString(connectbd.NumBon());

            typebon.SelectedIndex = 0;
            guna2DataGridView1.DataSource = connectbd.BonNonTerminer();
            guna2DataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);
           guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            guna2DataGridView1.Columns[0].HeaderText = "Bon N°";
            guna2DataGridView1.Columns[1].HeaderText = "Maricule";
            guna2DataGridView1.Columns[2].HeaderText = "Nom Fornusseur";
            guna2DataGridView1.Columns[3].HeaderText = "Poids";
            guna2DataGridView1.Columns[4].HeaderText = "Produit";
            guna2DataGridView1.Columns[5].HeaderText = "Type";
            guna2DataGridView1.ColumnHeadersHeight = 25;
        }

     

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                button6.Enabled = true;
                button1.Enabled = true;
                poid1.Text = "";
                poid2.Text = "";
                date1.Text = "";
                date2.Text = "";
                DataGridViewRow row = this.guna2DataGridView1.Rows[e.RowIndex];
                code.Text = row.Cells["code_bon"].Value.ToString();
                DataTable maDataTable = connectbd.RechercheMatBon(code.Text.Trim());
                DataRow dr = maDataTable.Rows[0];
                mat.Text = dr["mat"].ToString();
                Codefrs.Text=dr["code_frs"].ToString();
                Codetrs.Text = dr["code_trs"].ToString();
               codepr.Text = dr["code_prd"].ToString();
                string type= dr["type"].ToString();
                if (type == "Achat")
                    typebon.SelectedIndex = 0;
                else typebon.SelectedIndex = 1;
                string etate = dr["etat"].ToString();
                if (etate == "Annuler")
                    etat.SelectedIndex = 1;
                else etat.SelectedIndex = 0;

                comboBoxCh.SelectedItem = dr["nom_ch"].ToString();


                string poidBrut= dr["poid_brut"].ToString();
                if (poidBrut.Length > 0)
                {
                    date1.Text = dr["date_ent"].ToString();
                    poid1.Text = poidBrut;
                    button1.Enabled = false;
                }
                else {
                    date2.Text = dr["date_sor"].ToString();
                    poid2.Text = dr["poid_tare"].ToString();
                    button6.Enabled = false;


                }
                poids.Text= dr["poid_net"].ToString();

                Datejour.Text= dr["date"].ToString();

            }
            
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
           

        }

        private void guna2Button2_Click(object sender, EventArgs e)
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string type = "Achat";
            if (typebon.SelectedIndex == 1)
                type = "vente";
            if (connectbd.DoesBonExist(code.Text.Trim()))
            {

                Bon bn = new Bon(code.Text, mat.Text, Codefrs.Text, Codetrs.Text, codepr.Text, poid1.Text, poid2.Text, poids.Text, comboBoxCh.SelectedItem.ToString(), etat.SelectedItem.ToString(), type, date2.Text, date1.Text, Convert.ToDateTime(Datejour.Text.Trim()));
                connectbd.UpdateBon(bn);
                FormBoncs_Load(sender, e);
                mat.Text = "";
                Codefrs.Text = "";
                Codetrs.Text = "";
                codepr.Text = "";
                poid1.Text = "";
                poid2.Text = "";
                date1.Text = "";
                date2.Text = "";
                button1.Enabled = true;
                button6.Enabled = true;
                poids.Text = "";
            }
            else
            {

                if (connectbd.DoesTransporteurExist(Codetrs.Text.Trim()) && connectbd.DoesFournisseurExist(Codefrs.Text) && (poid1.Text.Length > 0 || poid2.Text.Length > 0) && connectbd.DoesMatriculeExist(mat.Text.Trim()) && connectbd.DoesproduitExist(codepr.Text.Trim()))
                {
                    Bon bn = new Bon(code.Text, mat.Text, Codefrs.Text, Codetrs.Text, codepr.Text, poid1.Text, poid2.Text, poids.Text, comboBoxCh.SelectedItem.ToString(), etat.SelectedItem.ToString(), type, date2.Text, date1.Text, Convert.ToDateTime(Datejour.Text.Trim()));
                    connectbd.AjouterBon(bn);
                    FormBoncs_Load(sender, e);
                    mat.Text = "";
                    Codefrs.Text = "";
                    Codetrs.Text = "";
                    codepr.Text = "";
                    poid1.Text = "";
                    poid2.Text = "";
                    date1.Text = "";
                    date2.Text = "";
                    button1.Enabled = true;
                    button6.Enabled = true;
                    poids.Text = "";



                }
                else
                    MessageBox.Show("Champ Vide ou non Valide");

            }

        }

        private void poid2_TextChanged(object sender, EventArgs e)
        {

        }

        private void poid1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
