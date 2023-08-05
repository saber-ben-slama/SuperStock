using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFA
{
    internal class Produit
    {
        public string Code_prd { get; set; }
        public String nom { get; set; }
        public Produit( string code_prd, String nom)
        {
         
            this.Code_prd = code_prd;
            this.nom = nom;

        }
    }
}
