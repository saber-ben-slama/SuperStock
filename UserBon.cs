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
    public partial class UserBon : UserControl
    {
        public UserBon()
        {
            InitializeComponent();
            if (FormeLogin.Typee == 0)
            {
                guna2Button2.Enabled = false;
            
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormBoncs f = new FormBoncs();
            f.ShowDialog();
        }

        private void UserBon_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            FormModification f = new FormModification();
            f.ShowDialog();
        }
    }
}
