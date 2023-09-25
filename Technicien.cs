using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1_PPE
{
    class Technicien
    {

        // // // // CLASSE TECHNICIEN // // // //
        
            private String Nom_T;
            private int Id_T, Nb_I_C, Nb_I_R;

            // CONSTRUCTEUR technicien
            Technicien(int id_t, int nb_i_c, int nb_i_r, String nom_t)
            {
                Nom_T = nom_t;
                Id_T = id_t;
                Nb_I_C = nb_i_c;
                Nb_I_R = nb_i_r;
            }

            // // //GETTERS// // // //
            //get Nom_T
            public String getNom_T()
            {
                return Nom_T;
            }
            //get Id_T
            public int getId_T()
            {
                return Id_T;
            }
            //get Nb_I_C
            public int getNb_I_C()
            {
                return Nb_I_C;
            }
            //get Nb_I_R
            public int getNb_I_R()
            {
                return Nb_I_R;
            }

            // // //SETTERS // // // //
            //set Nom_T
            public void setNom_T(String nom_t)
            {
                Nom_T = nom_t;
            }
            //set Id_T
            public void setId_T(int id_t)
            {
                Id_T = id_t;
            }
            //set Nb_I_C
            public void setNb_I_C(int nb_i_c)
            {
                Nb_I_C = nb_i_c;
            }
            //set Nb_I_R
            public void setNb_I_R(int nb_i_r)
            {
                Nb_I_R = nb_i_r;
            }
        //
    }
}
