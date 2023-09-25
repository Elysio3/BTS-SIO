using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet1_PPE
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Connection Base de Données
            String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            
            

            if (textBox1.Text != "" && textBox2.Text !="")
            {


                if (BaseBD.getfonction(textBox1.Text) == 0 && radioButton1.Checked)
                {
                    
                    if (BaseBD.getmdp(textBox1.Text) == textBox2.Text)
                    {
                        MessageBox.Show("Le mdp correspond à l'utilisateur et la fonction, vous êtes connecté");
                        Form3 form = new Form3();
                        form.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Mot de passe erroné");
                }


                if (BaseBD.getfonction(textBox1.Text) == 1 && radioButton2.Checked)
                {
                    
                    if (BaseBD.getmdp(textBox1.Text) == textBox2.Text)
                    {
                        MessageBox.Show("Le mdp correspond à l'utilisateur et la fonction, vous êtes connecté");
                        Form4 form = new Form4();
                        form.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Mot de passe erroné");
                }

                if (BaseBD.getfonction(textBox1.Text) == 2 && radioButton3.Checked)
                {
                    
                    if (BaseBD.getmdp(textBox1.Text) == textBox2.Text)
                    {
                        MessageBox.Show("Le mdp correspond à l'utilisateur et la fonction, vous êtes connecté");
                        Form5 form = new Form5();
                        form.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Mot de passe erroné");
                }
            }
            else MessageBox.Show("Veuillez renseigner un nom d'utilisateur");

            
    
            
            
        }

        private void btnexit_Click(object sender, EventArgs e)
        {

            this.Close();
            Form1 form = new Form1();
            form.Show();

            
        }
    }
}
