using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFA
{
    internal class login
    {
        public String adresse { get; }
        public String motpasse { get; set; }
        public String type { get; set; }
        public String nom { get; set; }


        public login(string adresse, string motpasse,string type,string nom)
        {
            this.adresse = adresse;
            this.motpasse = motpasse;
            this.type = type;
            this.nom = nom;
        }
        public login(string adresse, string motpass)
        {
            this.adresse = adresse;
            motpasse = motpass;
         
        }


    }




}
