using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PFA
{
    public partial class FormeLogin : Form
    {
        public static int Typee=1;
        public static string user;
        public FormeLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          


        }
        public static string getUser()
        {

            return user;
        }
        private void FormeLogin_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(220, 220, 220);
            login.BorderColor = Color.FromArgb(255, 0, 0);
        }

        private void textBoxmp_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (textBoxadresse.Text.Trim().Length == 0)
            {
                MessageBox.Show(" Adresse is enmpty");

                return;


            }
            else

          if (textBoxmp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Motpasse  is enmpty");
                return;


            }
            else
            {

                login std = new login(textBoxadresse.Text.Trim(), textBoxmp.Text.Trim());
                int result = connectbd.Login(std);
                if (result == -1)
                {
                    MessageBox.Show("Invalid email or password. Please try again.");
                }
                else if (result == 1 || result == 0)
                {
                    Typee = result;
                    user = textBoxadresse.Text.Trim();
                    FormMenu fm = new FormMenu();
                    fm.Show();
                    this.Hide();

                }


                textBoxmp.Text = textBoxadresse.Text = String.Empty;


            }
        }
    }
}
