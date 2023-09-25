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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test3");
            var listeMateriel = new List<String>();
            listeMateriel = BaseBD.getMateriel();
            foreach (var Materiel in listeMateriel)
            {
                listBox1.Items.Add(Materiel);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test4");
            BaseBD.addMateriel(textBox1.Text, textBox4.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test5");
            var listeIncidents = new List<String>();
            listeIncidents = BaseBD.getIncidents();
            foreach (var Incident in listeIncidents)
            {
                listBox1.Items.Add(Incident);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test4");
            bool resolution;
            if (radioButton1.Checked)
                resolution = true;
            else
                resolution = false;
            BaseBD.modifIncident(Convert.ToInt32(textBox2.Text), textBox3.Text, resolution);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BaseBD.delMateriel(Convert.ToInt32(textBox1.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}

