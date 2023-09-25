package com.example.helloworld;

import java.util.ArrayList;
import java.util.List;

public class Globals {
    private static Globals instance;

    //Global Variable
    /**
     * int data
     */
    private int data;
    /**
     * globals : nom
     */
    private String nom;
    /**
     * globals : prenom
     */
    private String prenom;
    /**
     * globals : type
     */
    private String type;
    /**
     * globals : adresse
     */
    private String adresse;
    /**
     * globals : mail
     */
    private String mail;

    /**
     * globals : nombre de pros total
     */
    private int nbIdPro = 0;
    /**
     * globals : un pro
     */
    private Professionnels unPro;


    /**
     * globals : date
     */
    private String date;
    /**
     * globals : heure
     */
    private String heure;

    // Restriction sur l'instanciation du constructeur

    /**
     * Constrcteur non autorisé
     */
    private Globals(){}

    /**
     * globals : définition de int data
     * @param d le nouvel int data
     */
    public void setData(int d)
    {
        this.data = d;
    }



    /**
     * Définition des valeurs globales retenues en tant que rendezVous
     * @param date la date
     * @param heure l'heure
     */
    public void setRendezVous(String date, String heure)
    {
        this.date = date;
        this.heure = heure;
    }


    /**
     * getteur de int data
     * @return le int data
     */
    public int getData()
    {
        return this.data;
    }


    /**
     * getteur globals : nom
     * @return le nom
     */
    public String getNom()
    { return this.nom; }

    /**
     * getteur globals : prenom
     * @return le prenom
     */
    public String getPrenom()
    { return this.prenom; }

    /**
     * getteur globals : adresse
     * @return l'adresse
     */
    public String getAdresse()
    { return this.adresse; }

    /**
     * getteur globals : mail
     * @return le mail
     */
    public String getMail()
    { return this.mail; }

    /**
     * getteur globals : type
     * @return le type
     */
    public String getType()
    { return this.type; }

    /**
     * getteur globals : nombre de pro
     * @return le nombre de pros
     */
    public int getNbIdPro()
    { return this.nbIdPro; }

    /**
     * setteur nombre de pros
     * @param nb le nouveau nombre de pros
     */
    public void setNbIdPro(int nb)
    { this.nbIdPro = nb; }


    /**
     * synchronisation du globals si l'instance actuelle est nulle
     * @return
     */
    public static synchronized Globals getInstance()
    {
        if(instance==null)
        {
            instance = new Globals();
        }
        return instance;
    }
}
