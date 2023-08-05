using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFA
{
    internal class Camion
    {

        public string Mat { get; set; }
        public String Code_trs { get; set; }
        public String Code_frs { get; set; }


        public Camion(string mat, String code_tr,String code_fr)
        {
            this.Mat = mat;
            this.Code_frs = code_fr;
            this.Code_trs = code_tr;

        }
        public Camion()
        {


        }


    }
}
