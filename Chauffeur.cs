using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFA
{
    internal class Chauffeur
    {
        public String nom { get; set; }
        public String code_trs { get; set; }

        public Chauffeur(String num, String nom)
        {
            this.code_trs = num;
            this.nom = nom;

        }

        public Chauffeur()
        {
        }
    }
}
