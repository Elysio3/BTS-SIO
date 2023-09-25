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

	public class BD
	{
		public BD()
		{

			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			MySqlCommand get_user = conn.CreateCommand();
			get_user.Parameters.AddWithValue("@user_login", textBox1.Text);
			get_user.CommandText = "SELECT fonction FROM login WHERE user = @user_login";
			get_user.ExecuteScalar();

			

		}
	}

}