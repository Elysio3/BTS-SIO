using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1_PPE
{
    // // // // // CLASSE INCIDENTS // // // // //
    class Incident
    {
        private int Id_I, Id_M;
        private String Desc_I;

        Incident(int id_i, int id_m, String desc_i)
        {
            Id_I = id_i;
            Id_M = id_m;
            Desc_I = desc_i;
        }

        // // // GETTERS // // //
        //get Id_I
        public int getId_I()
        {
            return Id_I;
        }
        //get Id_M
        public int getId_M()
        {
            return Id_M;
        }
        //get Desc_I
        public String getDesc_I()
        {
            return Desc_I;
        }
        // // //SETTERS // // //
        //set Id_I
        public void setId_I(int id_i)
        {
            Id_I = id_i;
        }
        //set Id_M
        public void setId_M(int id_m)
        {
            Id_M = id_m;
        }
        //set Desc_I
        public void setDesc_I(String desc_i)
        {
            Desc_I = desc_i;
        }
    }
}
