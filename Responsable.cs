using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1_PPE
{
    // // // // // CLASSE RESPONSABLE // // // // //
    class Responsable
    {
        private int Id_R;
        private String Nom_R;

        //CONSTRUCTEUR//
        Responsable(int id_r, String nom_r)
        {
            Id_R = id_r;
            Nom_R = nom_r;
        }

        // // //GETTERS // // // //
        //Get Nom_R
        public String getNom_R()
        {
            return Nom_R;
        }
        //Get Id_R
        public int getId_R()
        {
            return Id_R;
        }
        // // //SETTER // // // //
        //set Nom_R
        public void setNom_R(String nom_r)
        {
            Nom_R = nom_r;
        }
        //set Id_R
        public void setId_R(int id_r)
        {
            Id_R = id_r;
        }
    }
}
