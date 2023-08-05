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
    public partial class Pesage : Form
    {
        public Pesage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBoncs form1 = Application.OpenForms.OfType<FormBoncs>().FirstOrDefault();

            if (form1 != null)
            {
                // Utilisez une méthode ou une propriété de la Form1 pour envoyer l'élément sélectionné
                string index = ps.Text; // Trouve la position de la première occurrence du caractère "|"
              
                form1.Updateps1(index);
                this.Close();
            }
        }
    }
}
