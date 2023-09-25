package com.example.helloworld;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

public class Menu_Page extends AppCompatActivity {



    TextView titre;

    /**
     * Fonciton dès l'ouverture de la page
     * @param savedInstanceState l'instance actuelle
     */
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu__page);

        titre = findViewById(R.id.textViewAppName);
    }

    /**
     * Fonciton d'affichage de la page une
     * @param view l'écran actuel
     */
    public void clicAfficherPage1(View view)
    {
        Intent intentAfficher = new Intent(this, MainActivity.class);
        startActivity(intentAfficher);
    }

    /**
     * Fonction d'affichage de la page deux
     * @param view l'écran actuel
     */
    public void clicAfficherPage2(View view)
    {
            Intent intentAfficher = new Intent(this, MainActivity2.class);
            startActivity(intentAfficher);
    }

    /**
     * Fonction d'affichage de la page trois
     * @param view l'écran actuel
     */
    public void clicAfficherPage3(View view)
    {
        Intent intentAfficher = new Intent(this, MainActivity3.class);
        startActivity(intentAfficher);
    }

}