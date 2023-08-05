using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PFA
{
    internal class Bon
    {
        public String code_bn { get; set; }
        public String mat { get; set; }
        public String code_frs { get; set; }
        public String code_trs { get; set; }
        public String code_prd { get; set; }
        public String poid_brut { get; set; }
        public String poid_tare { get; set; }
        public String poid_net { get; set; }
        public String nom_ch { get; set; }
        public String etat { get; set; }
        public String type { get; set; }
        public DateTime date { get; set; }
        public String date_ent { get; set; }
        public String date_sor { get; set; }


        public Bon(string code_bn, string mat, string code_frs, string code_trs, string code_prd, string poid_brut, string poid_tare, string poid_net, string nom_ch, string etat, string type, string date_sor, string date_ent,DateTime date)
        {
            this.date = date;
            this.date_ent = date_ent;
            this.date_sor = date_sor;
            this.code_bn = code_bn;
            this.mat = mat;
            this.code_frs = code_frs;
            this.code_trs = code_trs;
            this.code_prd = code_prd;
            this.poid_brut = poid_brut;
            this.poid_tare = poid_tare;
            this.poid_net = poid_net;
            this.nom_ch = nom_ch;
            this.etat = etat;
            this.type = type;
        }
        public Bon(string text) { }
        
    }
}
