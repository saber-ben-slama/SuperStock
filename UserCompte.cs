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
    public partial class UserCompte : UserControl
    {
        public UserCompte()
        {
            InitializeComponent();
            guna2DataGridView1.ColumnHeadersHeight = 25;
            guna2DataGridView1.DataSource = connectbd.Comptes();
            guna2DataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);
            guna2DataGridView1.Columns[0].HeaderText = "Adresse";
            guna2DataGridView1.Columns[1].HeaderText = "MotPasse";
            guna2DataGridView1.Columns[2].HeaderText = "Type";
            guna2DataGridView1.Columns[3].HeaderText = "Nom";
        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            login lg = new login(adresse.Text, mp.Text, Convert.ToString(type.Value), nom.Text);
            if (connectbd.DoesCompteExiste(adresse.Text))
            {
                connectbd.UpdateCompte(lg);



            }
            else
            {
                connectbd.AjouterCompte(lg);


            }

        }

        private void adresse_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
