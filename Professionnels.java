package com.example.helloworld;

import com.example.helloworld.Globals;

import java.util.ArrayList;

public class Professionnels

{
    Globals g;
    /**
     * Le nom
     */
    private String nom;
    /**
     * Le prenom
     */
    private String prenom;
    /**
     * Le type
     */
    private String type;
    /**
     * L'adresse
     */
    private String adresse;
    /**
     * le mail
     */
    private String mail;
    /**
     * L'id
     */
    private int id;


    /**
     * Constructeur de la classe Professionnel
     * @param nom son nom
     * @param prenom son prenom
     * @param type son type
     * @param adresse son adresse
     * @param mail son mail
     */
    public Professionnels(String nom, String prenom, String type, String adresse, String mail)
    {
        Globals.getInstance();

        this.nom = nom;
        this.prenom = prenom;
        this.type = type;
        this.adresse = adresse;
        this.mail = mail;

    }
    /**
     * // // // // //LISTE DES SETTERS// // // // //
     */

    /**
     * Setter du nom
     * @param nom le nouveau nom
     */
    public void setNom(String nom) {
        this.nom = nom;
    }

    /**
     * Setter du prénom
     * @param prenom le nouveau prénom
     */
    public void setPrenom(String prenom) {
        this.prenom = prenom;
    }

    /**
     * Setter du type
     * @param type le nouveau type
     */
    public void setType(String type) {
        this.type = type;
    }

    /**
     * Setter de l'adresse
     * @param adresse la nouvelle adresse
     */
    public void setAdresse(String adresse) {
        this.adresse = adresse;
    }

    /**
     * Setter du mail
     * @param mail le nouveau mail
     */
    public void setMail(String mail) {
        this.mail = mail;
    }

    /**
     * Setter de l'id
     * @param id le nouvel id
     */
    public void setId(int id) {
        this.id = id;
    }

    /**
     * // // // // //LISTE DES GETTERS// // // // //
     */

    /**
     * Getter du nom
     * @return le nom
     */
    public String getNom() {
        return nom;
    }

    /**
     * Getter du prénom
     * @return le prénom
     */
    public String getPrenom() {
        return prenom;
    }

    /**
     * Getter du type
     * @return le type
     */
    public String getType() {
        return type;
    }

    /**
     * Getter de l'adresse
     * @return l'adresse
     */
    public String getAdresse() {
        return adresse;
    }

    /**
     * Getter du mail
     * @return le mail
     */
    public String getMail() {
        return mail;
    }

    /**
     * Getter de l'id
     * @return l'id
     */
    public int getId() {
        return id;
    }


}
