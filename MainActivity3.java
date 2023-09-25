package com.example.helloworld;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

import org.w3c.dom.Text;

import java.util.concurrent.ExecutionException;

public class MainActivity3 extends AppCompatActivity {


    SQLiteDataBaseHelper db;

    TextView textDate;
    TextView textHeure;
    TextView textPro;
    TextView txtid;

    EditText editTextRdv;


    /**
     * Fonction dès l'ouverture de la page
     * @param savedInstanceState l'instance actuelle
     */
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main3);

        db = new SQLiteDataBaseHelper(this);

        textDate = findViewById(R.id.resultBD2_1);
        textHeure = findViewById(R.id.resultBD2_2);
        textPro = findViewById(R.id.resultBD2_3);
        editTextRdv = findViewById(R.id.editText_idRdv);
        txtid = findViewById(R.id.resultID_rdv);

        majListeDate();
        majListePro();
        majListeHeure();

    }



    /**
     * clic bouton menu : affichage page menu
     * @param view
     */
    public void clicAfficherMenu(View view)
    {
        Intent intentAfficher = new Intent(this, Menu_Page.class);
        startActivity(intentAfficher);
    }

    /**
     * Affichage de la liste des rendez-vous enregistrés dans la BD
     * @param view l'écran actuel
     */
    public void cliclAfficherRDV(View view)
    {
        textHeure.setText("Date : ");
        textHeure.setText("Heure : ");
        textPro.setText("Professionnel Concerné : ");
        txtid.setText("ID :");

        majListeDate();
        majListePro();
        majListeHeure();
    }

    /**
     * Fonctino mise à jour des IDs
     */
    public void majListeID()
    {
        try{
            Cursor dataID = db.getListeRDV();
            txtid.setText("ID :");
            while(dataID.moveToNext())
            {
                txtid.setText(txtid.getText() + " \n " + (dataID.getInt(4)));
            }
        }
        catch(Exception e)
        {
            txtid.setText(e.getMessage());
        }
    }
    /**
     * Fonction mise à jour liste des Dates
     */
    public void majListeDate()
    {
        try {
            Cursor dataDate = db.getListeRDV();

            textDate.setText("Date :");
            while (dataDate.moveToNext())
            {
                textDate.setText(textDate.getText() + " \n " + (dataDate.getString(1)));

            }

        }
        catch (Exception e)
        {
            textDate.setText(e.getMessage());
        }
    }

    /**
     * Fonction mise à jour liste des Heures
     */
    public void majListeHeure()
    {
        try {
            Cursor dataHeure = db.getListeRDV();
            textHeure.setText("Heure :");
            while (dataHeure.moveToNext())
            {
                textHeure.setText(textHeure.getText() + " \n " + (dataHeure.getString(0)));
            }

        }
        catch (Exception e)
        {
            textHeure.setText(e.getMessage());
        }
    }

    /**
     * Fonction mise à jour liste des Pros
     */
    public void majListePro()
    {
        try {
            Cursor dataPro = db.getListeRDV();
            String[] listePro  = db.getListeIdPro();
            textPro.setText("PRofessionnel Concerné :");
            while (dataPro.moveToNext())
            {
                textPro.setText(textPro.getText() + " \n " + (dataPro.getString(2)) + " " + listePro[dataPro.getInt(2)]);


            }

        }
        catch (Exception e)
        {
            textPro.setText(e.getMessage());
        }
    }

    /**
     * Fonction suppression de la liste entière des rendez-vous
     * @param view l'écran actuel
     */
    public void clicDelAllRDv(View view)
    {
        try {
            db.delAllDataRDV();
            textDate.setText("Date : ");
            textHeure.setText("Heure : ");
            textPro.setText("Professionnel Concerné : ");

            majListeDate();
            majListePro();
            majListeHeure();
        }
        catch (Exception e)
        {
            textPro.setText(e.getMessage());
        }
    }

    /**
     * Fonction de suppression d'un rendez-vous selon son id
     * @param view l'écran actuel
     */
    public void clicDelARDv(View view)
    {
        try {
            String id = editTextRdv.getText().toString();
            db.delARdv(id);
            editTextRdv.setText(" ");
            majListeHeure();
            majListePro();
            majListeDate();
        }
        catch (Exception e)
        {
            editTextRdv.setText(e.getMessage());
        }
    }



}