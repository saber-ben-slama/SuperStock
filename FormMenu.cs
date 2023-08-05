using Guna.UI2.WinForms;
using PFA.Menu;
using ServiceStack.Script;
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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();

            UserBon us = new UserBon();
            AddControlleToPanel(us);
            if (FormeLogin.Typee == 0)
                guna2Button1.Enabled = false;

        }
        private void mouveimagebox(Object sender)
        {

            Guna2Button b = (Guna2Button)sender;
            pictureBox2.Location = new Point(b.Location.X + 150, b.Location.Y-3);
            pictureBox2.SendToBack();
           

        }
        private void FormMenu_Load(object sender, EventArgs e)
        {
            labelName.Text ="Bonjour "+connectbd.NameUser(FormeLogin.getUser());
        }


        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            mouveimagebox(sender);
        }
        private void AddControlleToPanel(Control controlToAdd)
        {
            // Assuming you have a panel named "panel1" in your form
            panel2.Controls.Clear(); // Remove any existing controls from the panel
            controlToAdd.Dock = DockStyle.Fill; // Set the docking style of the control
            panel2.Controls.Add(controlToAdd); // Add the control to the panel
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UserMenu us = new UserMenu();
            AddControlleToPanel(us);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UserRecherch us = new UserRecherch();
            AddControlleToPanel(us);
        }

     

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            UserBase us = new UserBase();
            AddControlleToPanel(us);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

            UserBon us = new UserBon();
            AddControlleToPanel(us);
        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            FormeLogin f = new FormeLogin();
            f.Show();
            this.Close();
        }
    }
}
