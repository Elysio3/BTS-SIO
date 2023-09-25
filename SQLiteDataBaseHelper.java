package com.example.helloworld;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.StaleDataException;
import android.database.sqlite.SQLiteOpenHelper;
import android.content.Context;
import android.database.sqlite.SQLiteDatabase;

public class SQLiteDataBaseHelper extends SQLiteOpenHelper {

    /**
     * Le nom de la base de donnée
     */
    public static final String DATABASE_NAME = "GSB";
    /**
     * Le nom de la table Professionnels
     */
    public static final String TABLE_NAME_PRO = "Professionnels";
    /**
     * Le nom de la table Rendez-Vous
     */
    public static final String TABLE_NAME_RDV = "Rendezvous";

    /**
     * Liste des colonnes de la Table Professionnel
     */
    /**
     * colonne "nom"
     */
    public static final String COL_1_1 = "Nom";
    /**
     * colonne "prenom"
     */
    public static final String COL_1_2 = "Prenom";
    /**
     * colonne "type"
     */
    public static final String COL_1_3 = "Type";
    /**
     * "colonne adresse"
     */
    public static final String COL_1_4 = "Adresse";
    /**
     * colonne "mail"
     */
    public static final String COL_1_5 = "Mail";
    /**
     * colonne "id"
     */
    public static final String COL_1_6 = "id";



    /**
     * Liste des colonnes de la table Rendez-vousS
     */
    /**
     * colonne "date"
     */
    public static final String COL_2_1 = "Date";
    /**
     * colonne "heure"
     */
    public static final String COL_2_2 = "Heure";
    /**
     * colonne "idPro"
     */
    public static final String COL_2_3 = "idPro";
    /**
     * colonne"idRdv"
     */
    public static final String COL_2_4 = "idRdv";



    Globals g;



    /**
     * Constructeur de la base de données
     * @param context prise du contexte actuel des bases de données déjà enregistréesS
     */
    public SQLiteDataBaseHelper(Context context)
    {
        super(context, DATABASE_NAME, null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("CREATE TABLE " + TABLE_NAME_PRO + "(Nom TEXT, Prenom TEXT, Type TEXT, Adresse TEXT, Mail TEXT, id INTEGER PRIMARY KEY AUTOINCREMENT)");
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_NAME_RDV);
        db.execSQL("CREATE TABLE " + TABLE_NAME_RDV + "(Date TEXT, Heure TEXT, idPro INTEGER, idRdv INTEGER PRIMARY KEY AUTOINCREMENT)");
    }

    /**
     * Fonction Override de mise à jour de la base de données
     * @param db la base de données à metre à jour
     * @param oldVersion numéro de l'ancienne version
     * @param newVersion numéro de la nouvelle version
     */
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_NAME_PRO);
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_NAME_RDV);
        onCreate(db);
    }


    /**
     * Insertion d'un pro dans la base de données à partir de tout ses paramètres
     * @param Nom le nom
     * @param Prenom le prénom
     * @param Type son type
     * @param Adresse son adresse
     * @param Mail son adresse mail
     */
    public void InsertDataPro(String Nom, String Prenom, String Type, String Adresse, String Mail)
    {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();

        contentValues.put(COL_1_1, Nom);
        contentValues.put(COL_1_2, Prenom);
        contentValues.put(COL_1_3, Type);
        contentValues.put(COL_1_4, Adresse);
        contentValues.put(COL_1_5, Mail);
        db.insert(TABLE_NAME_PRO, null, contentValues);

    }

    /**
     * Insertion d'un pro dans la base de donnée àn partir d'un objet pro
     * @param unPro le professsionnel
     */
    public void InsertDataPro(Professionnels unPro)
    {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();

        contentValues.put(COL_1_1, unPro.getNom());
        contentValues.put(COL_1_2, unPro.getPrenom());
        contentValues.put(COL_1_3, unPro.getType());
        contentValues.put(COL_1_4, unPro.getAdresse());
        contentValues.put(COL_1_5, unPro.getMail());
        db.insert(TABLE_NAME_PRO, null, contentValues);
        db.close();
    }


    /**
     * Insertion d'un rendez-vous dans la base de donnée à partir de ses paramètres
     * @param date sa date
     * @param heure son heure
     */
    public void InsertDataRDV(String date, String heure, int idPro)
    {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();

        contentValues.put(COL_2_1, date);
        contentValues.put(COL_2_2, heure);
        contentValues.put(COL_2_3, idPro);

        db.insert(TABLE_NAME_RDV, null, contentValues);
        db.close();
    }


    /**
     * Insertion d'un rendez-vous dans la base de donnée à partir d'un objet rendez-vous
     * @param unRDV le rendez-vous
     */
    public void InsertDataRDV(RendezVous unRDV)
    {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();

        contentValues.put(COL_2_1, unRDV.getDate());
        contentValues.put(COL_2_2, unRDV.getHeure());
        contentValues.put(COL_2_3, unRDV.getProConcerne());

        db.insert(TABLE_NAME_RDV, null, contentValues);
        db.close();
    }

    /**
     * Récupération de l'entièretée de la table professionnel
     * @return tableau des pro (format Cursor)
     */
    public Cursor getAllData()
    {
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor result = db.rawQuery("SELECT * FROM " + TABLE_NAME_PRO, null);

        return result;

    }

    /**
     * Suppression d'une ligne SQL selon son ID
     * @param id l'id de la ligne à supprimer
     */
    public void delAData(int id)
    {
            SQLiteDatabase db = this.getWritableDatabase();
            db.delete(TABLE_NAME_PRO, COL_1_1+"="+id, null);

            db.close();
    }

    /**
     * Suppression de toute les données d'une table PRO
     */
    public void delAllData()
    {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(TABLE_NAME_PRO, null, null);
        db.delete("sqlite_sequence", null, null);

        db.close();
    }
    /**
     * Suppression de toute les données d'une table RDV
     */
    public void delAllDataRDV()
    {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(TABLE_NAME_RDV, null, null);
        db.delete("sqlite_sequence", null, null);

        db.delete("sqlite_sequence", null, null);

        db.execSQL("DROP TABLE IF EXISTS " + TABLE_NAME_RDV);
        db.execSQL("CREATE TABLE " + TABLE_NAME_RDV + "(Date TEXT, Heure TEXT, idPro INTEGER, idRdv INTEGER PRIMARY KEY AUTOINCREMENT)");


        db.close();
    }

    /**
     * Getteur de la liste des ID des Professionnels
     * @return le tableau des nom + prenom des pros
     */
    public String[] getListeIdPro()
    {
        SQLiteDatabase db = this.getReadableDatabase();

        Cursor nbID = db.rawQuery("SELECT * FROM "+ TABLE_NAME_PRO, null);
        int nbIDCount = nbID.getCount();

        String[] test = new String[nbIDCount];
        int i=0;
        while (nbID.moveToNext())
        {
            test[i] = (nbID.getString(0) +" " + nbID.getString(1) + ", type : "+ nbID.getString(2));
            i++;
        }

        return test;
    }


    /**
     * Getteur du nombre de professionnels enregistré
     * @return le nombre de professionnels enregistré
     */
    public int getNbIdCount()
    {
        SQLiteDatabase db = this.getReadableDatabase();

        Cursor nbID = db.rawQuery("SELECT * FROM "+ TABLE_NAME_PRO, null);
        int nbIDCount = nbID.getCount();

        return nbIDCount;
    }

    /**
     * Getteur Liste des rdvs (cursor)
     * @return le curseur contenant la liste des rdvs
     */
    public Cursor getListeRDV()
    {
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor list = db.rawQuery("SELECT * FROM " + TABLE_NAME_RDV, null);

        return list;
    }

    /**
     * Fonction de suppression d'un rendez vous selon son ID
     * @param id l'id du rendez-vous à supprimer
     */
    public void delARdv(String id)
    {
        SQLiteDatabase db = this.getReadableDatabase();
        db.delete(TABLE_NAME_RDV,COL_2_4 + " = " + id , null);


        db.delete("sqlite_sequence", null, null);
    }




}
