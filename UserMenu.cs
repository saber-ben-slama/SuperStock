using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFA.Menu
{
    public partial class UserMenu : UserControl
    {
        public UserMenu()
        {
            InitializeComponent();
        }
       

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormCompte us = new FormCompte();
            us.ShowDialog();
        }
    }
}
