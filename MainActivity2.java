package com.example.helloworld;

import androidx.annotation.NonNull;
import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.Cursor;
import android.os.Build;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.CalendarView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.TimePicker;

import java.util.ArrayList;

public class MainActivity2 extends AppCompatActivity {

    Globals g;
    Spinner spin;
    TextView text;
    String curDate;
    String[] langages = {"php", "html", "java", "javascript", "C#", "python"};
    TimePicker timerpicker;
    CalendarView calendarView;

    /**
     * L'heure selectionnée
     */
    int heures;
    /**
     * les minutes selsctionnée
     */
    int minutes;
    /**
     * l'id du pro selectionnée
     */
    int idSelect;

    SQLiteDataBaseHelper db;
    /**
     * la liste des Pro (Nom - Prenom - Type)
     */
    String[] listeDesPros;

    /**
     * Fonction dès l'ouverture de la page
     * @param savedInstanceState l'instance de l'application
     */
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);

        g = Globals.getInstance();

        /**
         * Liens entre les objets de l'interphace graphique et les objets virtuels
         */
        spin=findViewById(R.id.SpinnerDesPros);
        text = findViewById(R.id.TextView1);
        timerpicker = findViewById(R.id.TimePicker);
        timerpicker.setIs24HourView(true);
        calendarView = findViewById(R.id.CalendarView);

            db = new SQLiteDataBaseHelper(this);

        try {

            listeDesPros = db.getListeIdPro();
            text.setText(db.getNbIdCount() + " " +  listeDesPros[2]);

        }
        catch (Exception e)
        {
            text.setText(e.getMessage());
        }


        calendarView.setOnDateChangeListener((new CalendarView.OnDateChangeListener() {
            /**
             * Fonction de définition de la date du CalendarView et stockage dans une variable
             * @param view L'écran actuel
             * @param year L'année
             * @param month le mois
             * @param dayOfMonth le jour du mois
             */
            @Override
            public void onSelectedDayChange(@NonNull CalendarView view, int year, int month, int dayOfMonth) {

                String leMois = String.valueOf(month+1);
                if((month+1)<10)
                {
                    leMois =("0"+String.valueOf(month+1));
                }
                String leJour = String.valueOf(dayOfMonth);
                if((dayOfMonth)<10)
                {
                    leJour =("0"+String.valueOf(dayOfMonth));
                }


                curDate = String.valueOf(leJour) + "/" + String.valueOf(leMois);
            }
        }));


        timerpicker.setOnTimeChangedListener(new TimePicker.OnTimeChangedListener() {
            /**
             * Fonction de définition de l'heure selectionnée
             * @param view l'écran actuel
             * @param hourOfDay l'heure
             * @param minute les minutes
             */
            @Override
            public void onTimeChanged(TimePicker view, int hourOfDay, int minute) {
                heures = 0;
                minutes = 0;
                heures = hourOfDay;
                minutes = minute;

            }
        });



    }


    /**
     * clic bouton 1 : affichage de la page 1
     * @param view
     */
    public void clicAfficherPage1(View view)
    {
        Intent intentAfficher = new Intent(this, MainActivity.class);
        startActivity(intentAfficher);
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
     * clic bouton 2 : affichage page1
     * @param view
     */
    public void clicPage1(View view)
    {
        TextView text = findViewById(R.id.textViewAppName);
        g = Globals.getInstance();
        String nom = g.getNom();
        text.setText(nom);
    }

    /**
     * fonction de repmlissage du spin avec les nom/prénom des professionnels enregistré
     * @param view
     */
    public void clicFillList(View view)
    {

        ArrayAdapter<String> AllPros = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, listeDesPros);
        AllPros.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spin.setAdapter((AllPros));

        spin.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                idSelect=position;
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });



    }

    /**
     * getteur de l'id de la ligne du spin selectionnée
     * @param view
     */
    public void clicGetSelect(View view)
    {
        String ProSelected = listeDesPros[idSelect];
        text.setText(ProSelected);

    }

    /**
     * Clic bouton obtenir un Rendez-Vous
     * @param view
     */

    public void clicGetRDV(View view)
    {
        try
        {
            String heure = "00h00";

            String laHeure = String.valueOf(heures);
            String laMinute = String.valueOf(minutes);

            if(heures<10)
                laHeure = ("0"+laHeure);
            if(minutes<10)
                laMinute = ("0"+laMinute);

            if(heures==0)
                laHeure = ("00");
            if(minutes==0)
                laMinute = ("00");

            heure = (laHeure + "h" + laMinute);

            RendezVous unRdv = new RendezVous(curDate, heure, idSelect);
            //db.InsertDataRDV(unRdv);
            text.setText("Rendez-vous ajouté");
            db.InsertDataRDV(curDate, heure, idSelect);

            Cursor listerdv = db.getListeRDV();
            while (listerdv.moveToNext())
            {
                text.setText(text.getText() + " \n " + " date : "+ (listerdv.getString(0)) + "heure : " + (listerdv.getString(1)) + "pro concerne :" + (listerdv.getString(2)));

            }
        }
        catch(Exception e)
        {
            text.setText(e.getMessage());
        }
    }



}