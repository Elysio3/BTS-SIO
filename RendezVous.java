package com.example.helloworld;

import com.example.helloworld.Professionnels;
import com.example.helloworld.Globals;

public class RendezVous
{

    Globals g;
    /**
     * La date
     */
    private String date;
    /**
     * l'heure
     */
    private String heure;
    /**
     * le professionnel concerné (objet)
     */
    private Professionnels ProfessionnelConcerne;
    /**
     * l'ID du professionnel concerné
     */
    private int ProConcerne;


    /**
     * Constructeur de la classs RendezVous
     * @param date la date du rendez-vous (format JJ/MM/AAAA)
     * @param heure l'heure du rendez-vous
     */
    public RendezVous(String date, String heure, int ProConcerne) {
        this.date = date;
        this.heure = heure;
        this.ProConcerne = ProConcerne;
    }

    /**
     * // // // // //LISTE DES GETTERS// // // // //
     */

    /**
     * getter date
     * @return la date
     */
    public String getDate() {
        return date;
    }

    /**
     * Getter heure
     * @return l'heure
     */
    public String getHeure() {
        return heure;
    }
    /**
     *  // // // // //LISTE DES SETTERS// // // // //
     */

    /**
     * Setter date
     * @param date
     */
    public void setDate(String date) {
        this.date = date;
    }

    /**
     * Setter heure
     * @param heure
     */
    public void setHeure(String heure) {
        this.heure = heure;
    }

    /**
     * Setter Professionnel concerné
     * @param id l'id du professionnel concerné
     */
    public void setProfessionnelConcerne(int id)
    {
        this.ProConcerne = id;
    }

    /**
     * Getteur du professionnel concerné
     * @return l'id du professionnel concerné
     */
    public int getProConcerne()
    {
        return this.getProConcerne();
    }
}
