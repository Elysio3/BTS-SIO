using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1_PPE
{
    class Utilisateur
    {

        // // // // CLASSE UTILISATEUR // // // //

        
            private String Nom_U;
            private int Id_U, Nb_I_U;


            // CONSTRUCTEUR Utilisateur
            public Utilisateur(int num_u, int nb_i_u, String nom_u)
            {
                Nom_U = nom_u;
                Id_U = num_u;
                Nb_I_U = nb_i_u;
            }

            // // //GETTERS// // // //
            //get ID_U
            public int getId_U()
            {
                return Id_U;
            }
            //get Nom_U
            public String getNom_U()
            {
                return Nom_U;
            }
            //get Nb_I_U
            public int getNb_I_U()
            {
                return Nb_I_U;
            }

            // // //SETTERS // // // //
            //set Id_U
            public void setId_U(int id_u)
            {
                Id_U = id_u;
            }
            //set Nom_U
            public void setNom_U(String nom_u)
            {
                Nom_U = nom_u;
            }
            //set Nb_I_U
            public void setNb_I_U(int nb_i_u)
            {
                Nb_I_U = nb_i_u;
            }
        //
    }
}
