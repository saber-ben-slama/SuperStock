using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFA
{
    internal class transporteur
    {
        public String code_trs { get; set; }
        public String nom_trs { get; set; }
        public String adresse { get; set; }
        public String description { get; set; }

        public transporteur(String code_trs, string nom_trs, string adresse, string disc)
        {
            this.code_trs = code_trs;
            this.adresse = adresse;
            this.nom_trs = nom_trs;
            this.description = disc;

        }
        public transporteur()
        {
            this.code_trs = "";
            this.adresse = "";
            this.nom_trs = "";
            this.description = "";

        }
    }
}
