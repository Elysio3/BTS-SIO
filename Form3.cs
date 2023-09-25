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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test");
            BaseBD.newIncident("1", Convert.ToInt32(textBox2.Text), textBox1.Text);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test2");
            var listeIncidents = new List<String>();
            listeIncidents = BaseBD.getIncidents();
            foreach(var Incident in listeIncidents)
            {
                listBox1.Items.Add(Incident);
            }
        }
    }
}


