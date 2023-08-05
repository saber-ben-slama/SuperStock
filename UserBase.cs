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
    public partial class UserBase : UserControl
    {
        public UserBase()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormAjouterFournisseur newForm = new FormAjouterFournisseur();


            newForm.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            FormAjouterTransporteur newForm = new FormAjouterTransporteur();


            newForm.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FormProduit f = new FormProduit();
            f.ShowDialog(this);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            FormCamion f = new FormCamion();
            f.Show();
        }
    }
}
