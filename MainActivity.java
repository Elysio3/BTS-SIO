package com.example.helloworld;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.provider.Settings;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;


public class MainActivity extends AppCompatActivity {

    Globals g;
    public ArrayList<Professionnels> ListePro = new ArrayList<Professionnels>();

    SQLiteDataBaseHelper db;

    /**
     * Liste des objects graphique liés
     */


    TextView resultTextBD;
    EditText editNom;
    EditText editPrenom;
    EditText editType;
    EditText editAdresse;
    EditText editMail;

    TextView txtNom;
    TextView txtPrenom;
    TextView txtType;
    TextView txtAdresse;
    TextView txtMail;
    TextView txtID;


    /**
     * Fonction dès l'ouverture de la page
     * @param savedInstanceState les données actuelles de l'application
     */
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //Création de la Base de Données
        db = new SQLiteDataBaseHelper(this);


        /**
         * Liens entre les objets de l'interface graphique et les objets virtuels
         */
        editNom = findViewById(R.id.editTextNom);
        editPrenom = findViewById(R.id.editTextPrenom);
        editType = findViewById(R.id.editTextType);
        editAdresse = findViewById(R.id.editTextAdresse);
        editMail = findViewById(R.id.editTextMail);

        resultTextBD = findViewById(R.id.resultBD);
        resultTextBD.setText("texteee");

        txtNom = findViewById(R.id.resultBD1);
        txtPrenom = findViewById(R.id.resultBD2);
        txtType = findViewById(R.id.resultBD3);
        txtAdresse = findViewById(R.id.resultBD4);
        txtMail = findViewById(R.id.resultBD5);
        txtID = findViewById(R.id.resultBD6);

        majListe();
    }


    /**
     * Bouton affichage de l'écran N°2
     * @param view
     */
    public void clicAfficherPage2(View view)
    {
        Intent intentAfficher = new Intent(this, MainActivity2.class);
        startActivity(intentAfficher);

    }

    /**
     * Bouton affichage de l'écran 3
     * @param view
     */
    public void clicAfficherMenu(View view)
    {
        Intent intentAfficher = new Intent(this, Menu_Page.class);
        startActivity(intentAfficher);
    }



    /**
     * Fonction d'enregistrement d'un Professionnel
     * @param view
     */
    public void clicEnregistrer(View view)
    {

        try {
            String Nom, Prenom, Adresse, Type, Mail;

            Nom = editNom.getText().toString();
            Prenom = editPrenom.getText().toString();
            Type = editType.getText().toString();
            Adresse = editAdresse.getText().toString();
            Mail = editMail.getText().toString();

            Professionnels unPro = new Professionnels(Nom, Prenom, Type, Adresse, Mail);



            db.InsertDataPro(unPro);

            majListe();
        }

        catch (Exception e){
            resultTextBD.setText(e.getMessage());
        }



    }

    /**
     * Fonction de mise à jour des trois listes
     * @param view
     */
    public void buttonMajListe(View view)
    {
        majListe();
    }

    /**
     * Fonction de mise à jour du label avec le contenu de la base de données
     */
    public void majListe()
    {
        txtPrenom.setText("Nom \n ");
        txtNom.setText("Prenom \n ");
        txtType.setText("Type \n ");
        txtAdresse.setText("Adresse \n ");
        txtMail.setText("Mail \n ");
        txtID.setText("Id \n ");
        resultTextBD.setText("Professionnel ajouté");

        majListeNom();
        majListePrenom();
        majListeType();
        majListeAdresse();
        majListeMail();
        majListeID();

    }

    /**
     * Fonction de mise à jour de la liste des Noms
     */
    public void majListeNom()
    {
        try {
            Cursor dataNom = db.getAllData();
            while (dataNom.moveToNext())
            {
                txtNom.setText(txtNom.getText() + " \n " + (dataNom.getString(1)));
            }

        }
        catch (Exception e)
        {
            txtNom.setText(e.getMessage());
        }
    }

    /**
     * Fonction de mise à jour de la liste des Prénoms
     */
    public void majListePrenom()
    {
        try {
            Cursor dataNom = db.getAllData();
            while (dataNom.moveToNext())
            {
                txtPrenom.setText(txtPrenom.getText() + " \n " + (dataNom.getString(0)));
            }
        }
        catch (Exception e)
        {
            txtPrenom.setText(e.getMessage());
        }
    }

    /**
     * Fonction de mise à jour de la liste des Types
     */
    public void majListeType()
    {
        try {
            Cursor dataNom = db.getAllData();
            while (dataNom.moveToNext())
            {
                txtType.setText(txtType.getText() + " \n " + (dataNom.getString(2)));
            }
        }
        catch (Exception e)
        {
            txtType.setText(e.getMessage());
        }
    }

    /**
     * fonction de mise à jour de la liste des Adresses
     */
    public void majListeAdresse()
    {
        try {
            Cursor dataNom = db.getAllData();
            while (dataNom.moveToNext())
            {
                txtAdresse.setText(txtAdresse.getText() + " \n " + (dataNom.getString(3)));
            }
        }
        catch (Exception e)
        {
            txtAdresse.setText(e.getMessage());
        }
    }

    /**
     * Fonction de mise à jour de la liste des Mails
     */
    public void majListeMail()
    {
        try {
            Cursor dataNom = db.getAllData();
            while (dataNom.moveToNext())
            {
                txtMail.setText(txtMail.getText() + " \n " + (dataNom.getString(4)));
            }
        }
        catch (Exception e)
        {
            txtMail.setText(e.getMessage());
        }
    }

    /**
     * Fonction de mise à jour de la liste des IDs
     */
    public void majListeID()
    {
        try {
            Cursor dataNom = db.getAllData();
            while (dataNom.moveToNext())
            {
                txtID.setText(txtID.getText() + " \n " + (dataNom.getString(5)));
            }
        }
        catch (Exception e)
        {
            txtID.setText(e.getMessage());
        }
    }



    /**
     * fonction de suppression de toutes les données de la base de données
     * @param view
     */
    public void delAllData(View view)
    {
        try {
            db.delAllData();
            resultTextBD.setText("Base de données supprimée");
            majListe();
        }
        catch (Exception e)
        {
            resultTextBD.setText(e.getMessage());
        }
    }



}