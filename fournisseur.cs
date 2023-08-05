using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFA
{
    internal class fournisseur
    {

        public String adresse { get; set; }
        public String nom { get; set; }
        public String num { get; set; }
        public String description { get; set; }


        public fournisseur(String @num , string nom, string adresse, string disc)
        {
            this.num = @num;
            this.adresse = adresse;
            this.nom = nom;
            this.description = disc;
        }
        public fournisseur()
        {
            this.num = null;
            this.adresse = "";
            this.nom = "";

            this.description = "";

        }





    }
}
