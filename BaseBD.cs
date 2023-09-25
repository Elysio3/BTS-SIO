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
	public class BaseBD
	{

		public BaseBD()
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();


				MessageBox.Show("Test de connection à la base de données réussi");

				conn.Close();
			}
			catch (Exception e)
			{
				MessageBox.Show("connection impossible" + e);
			}

		}

		/*	MySqlCommand get_user = conn.CreateCommand();
			get_user.Parameters.AddWithValue("@user_login", textBox1.Text);
			get_user.CommandText = "SELECT fonction FROM login WHERE user = @user_login";
			get_user.ExecuteScalar();

			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();
			MySqlCommand get_ = conn.CreateCommand();
			get_.Parameters.AddWithValue("@", );
			get_.CommandText = "SELECT  FROM  WHERE  = @";
			return (Convert.ToInt32(get_.ExecuteScalar()));
		*/

		public static int getId_Commercial(String nom)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();
				MySqlCommand get_com_id = conn.CreateCommand();
				get_com_id.Parameters.AddWithValue("@com_nom", nom);
				get_com_id.CommandText = "SELECT Id_Commercial FROM commercial WHERE Nom_Commercial = @com_nom";
				return (Convert.ToInt32(get_com_id.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return 0;
			}
		}

		public static String getNom_Commercial(int id)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();
				MySqlCommand get_com_nom = conn.CreateCommand();
				get_com_nom.Parameters.AddWithValue("@com_id", id);
				get_com_nom.CommandText = "SELECT Nom_Commercial FROM commercial WHERE Id_Commercial = @com_id";
				return (Convert.ToString(get_com_nom.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return "0";
			}
		}

		public static Double getTarif_Commercial(int id)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();
				MySqlCommand get_com_tar = conn.CreateCommand();
				get_com_tar.Parameters.AddWithValue("@com_id", id);
				get_com_tar.CommandText = "SELECT Tarif_Commercial FROM commercial WHERE Id_Commercial = @com_id";
				return (Convert.ToDouble(get_com_tar.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return 0;
			}
		}

		public static void setId_Commercial(int id, int newid)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();

				MySqlCommand set_Id_Com = conn.CreateCommand();
				set_Id_Com.Parameters.AddWithValue("@new_id", newid);
				set_Id_Com.Parameters.AddWithValue("@id", id);
				set_Id_Com.CommandText = "UPDATE Commercial SET Id_Commercial = @new_id WHERE Id_Commercial = @id";
				set_Id_Com.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);

			}
		}

		public static void setNom_Commercial(String newnom, int id)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();

				MySqlCommand set_Nom_Com = conn.CreateCommand();
				set_Nom_Com.Parameters.AddWithValue("@new_id", newnom);
				set_Nom_Com.Parameters.AddWithValue("@id", id);
				set_Nom_Com.CommandText = "UPDATE Commercial SET Nom_Commercial = @new_nom WHERE Id_Commercial = @id";
				set_Nom_Com.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
			}
		}

		public static void setTarif_Commercial(double newtarif, int id)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();

				MySqlCommand set_Tarif_Com = conn.CreateCommand();
				set_Tarif_Com.Parameters.AddWithValue("@new_tarif", newtarif);
				set_Tarif_Com.Parameters.AddWithValue("@id", id);
				set_Tarif_Com.CommandText = "UPDATE Commercial SET Tarif_Commercial = @new_tarif WHERE Id_Commercial = @id";
				set_Tarif_Com.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);

			}
		}



		public static int getId_User(String nom)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();
				MySqlCommand get_user_id = conn.CreateCommand();
				get_user_id.Parameters.AddWithValue("@user_nom", nom);
				get_user_id.CommandText = "SELECT Id FROM utilisateur WHERE Nom = @user_nom";
				return (Convert.ToInt32(get_user_id.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return 0;
			}
		}

		public static String getNom_User(int id)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();
				MySqlCommand get_user_nom = conn.CreateCommand();
				get_user_nom.Parameters.AddWithValue("@user_id", id);
				get_user_nom.CommandText = "SELECT Nom FROM utilisateur WHERE Id = @user_id";
				return (Convert.ToString(get_user_nom.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return "0";
			}
		}

		public static int getNbIncident_User(int id)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();
				MySqlCommand get_user_nbi = conn.CreateCommand();
				get_user_nbi.Parameters.AddWithValue("@user_id", id);
				get_user_nbi.CommandText = "SELECT nb_Incident_Declare FROM utilisateur WHERE Id = @user_id";
				return (Convert.ToInt32(get_user_nbi.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return 0;
			}
		}

		public static void setId_User(int id) { }
		public static void setNom_User(String nom) { }
		public static void setNbIncident_User(int nb) { }



		public static int getid_Tech(String nom)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();
				MySqlCommand get_Id_Tech = conn.CreateCommand();
				get_Id_Tech.Parameters.AddWithValue("@tech_nom", nom);
				get_Id_Tech.CommandText = "SELECT Id_T FROM technicien WHERE  = @tech_nom";
				return (Convert.ToInt32(get_Id_Tech.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return 0;
			}
		}

		public static String getNom_Tech(int id)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();
				MySqlCommand get_Nom_Tech = conn.CreateCommand();
				get_Nom_Tech.Parameters.AddWithValue("@tech_id", id);
				get_Nom_Tech.CommandText = "SELECT Nom_T FROM technicien WHERE Id_T = @tech_id";
				return (Convert.ToString(get_Nom_Tech.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return "0";
			}
		}

		public static int getNbICharge_tech(int id)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();
				MySqlCommand get_NbIC = conn.CreateCommand();
				get_NbIC.Parameters.AddWithValue("@tech_id", id);
				get_NbIC.CommandText = "SELECT  FROM NB_I_C WHERE Id_T = @tech_id";
				return (Convert.ToInt32(get_NbIC.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return 0;
			}
		}

		public static int getNbIResolu_Tech(int id)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();
				MySqlCommand get_NbIR = conn.CreateCommand();
				get_NbIR.Parameters.AddWithValue("@tech_id", id);
				get_NbIR.CommandText = "SELECT  FROM NB_I_R WHERE Id_T = @tech_id";
				return (Convert.ToInt32(get_NbIR.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return 0;
			}
		}

		public static void setId_Tech(int id) { }
		public static void setNom_tech(String nom) { }
		public static void setNbICharge_tech(int nb) { }
		public static void setNbIRESOLU_tech(int nb) { }




		public static int getId_responsable(String nom)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();
				MySqlCommand get_Id_R = conn.CreateCommand();
				get_Id_R.Parameters.AddWithValue("@Res_nom", nom);
				get_Id_R.CommandText = "SELECT Id_R FROM responsable WHERE Nom_R = @res_nom";
				return (Convert.ToInt32(get_Id_R.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return 0;
			}
		}

		public static String getNom_Responsable(int id)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();
				MySqlCommand get_Nom_R = conn.CreateCommand();
				get_Nom_R.Parameters.AddWithValue("@Res_id", id);
				get_Nom_R.CommandText = "SELECT Nom_R FROM responsable WHERE Id_R = @Res_id";
				return (Convert.ToString(get_Nom_R.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return "0";
			}
		}

		public static void setId_Responsable(int id) { }
		public static void setNom_Responsable(String nom) { }




		public static int getfonction(String login)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();

				MySqlCommand cmdfonction = conn.CreateCommand();
				cmdfonction.Parameters.AddWithValue("@user_login", login);
				cmdfonction.CommandText = "SELECT fonction FROM login WHERE user = @user_login";
				return (Convert.ToInt32(cmdfonction.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return 0;
			}
		}

		public static String getmdp(String login)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();

				MySqlCommand cmdmdp = conn.CreateCommand();
				cmdmdp.Parameters.AddWithValue("@user_login", login);
				cmdmdp.CommandText = "SELECT mdp FROM login WHERE user = @user_login";
				return (Convert.ToString(cmdmdp.ExecuteScalar()));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				return "0";
			}
		}

		public static void newIncident(String user, int idmat, String desc)
		{
			try
			{
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();

				MySqlCommand cmdNewI = conn.CreateCommand();
				cmdNewI.Parameters.AddWithValue("@IdUser", user);
				cmdNewI.Parameters.AddWithValue("@IdMat", Convert.ToString(idmat));
				cmdNewI.Parameters.AddWithValue("@Desc", desc);



				cmdNewI.CommandText = "INSERT INTO incident (Description, id_matériel, Résolution, Id_Technicien) VALUES (@Desc, @IdMat, FALSE, @IdUser)";
				cmdNewI.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
			}
		}

		public static List<String> getIncidents()
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			try
			{
				MySqlCommand get_I = conn.CreateCommand();
				get_I.CommandText = "SELECT * FROM incidents";


				var listeIncident = new List<String>();
				MySqlDataReader datareader = get_I.ExecuteReader();
				while (datareader.Read())
				{
					listeIncident.Add(Convert.ToString(datareader["id"]) + Convert.ToString(datareader["Résolution"]));
				}

				return listeIncident;

			}

			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				var listeIncident = new List<String>();
				listeIncident.Add("Null");
				return listeIncident;
			}

		}


		public static List<String> getMateriel()
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			try
			{
				MySqlCommand get_M = conn.CreateCommand();
				get_M.CommandText = "SELECT * FROM matériel";


				var listeMateriel = new List<String>();
				MySqlDataReader datareader = get_M.ExecuteReader();
				while (datareader.Read())
				{
					listeMateriel.Add(Convert.ToString(datareader["id_matériel"]) + Convert.ToString(datareader["nom_Matériel"]));
				}

				return listeMateriel;

			}

			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
				var listeMateriel = new List<String>();
				listeMateriel.Add("Null");
				return listeMateriel;
			}

		}

		public static void addMateriel(String id, String nom)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			try
			{
				MySqlCommand add_mat = conn.CreateCommand();
				add_mat.Parameters.AddWithValue("@id", id);
				add_mat.Parameters.AddWithValue("@nom", nom);
				add_mat.CommandText = "INSERT INTO matériel(id_matériel, nom_Matériel) VALUES (@id,@nom)";
				add_mat.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :" + e);
			}
		}

		public static void modifIncident(int id, String desc, Boolean reso)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			try
			{
				MySqlCommand modif_mat = conn.CreateCommand();
				modif_mat.Parameters.AddWithValue("@id", id);
				modif_mat.Parameters.AddWithValue("@desc", desc);
				modif_mat.Parameters.AddWithValue("@reso", reso);
				modif_mat.CommandText = "UPDATE incident SET Description=@desc, Résolution=@reso, WHERE id=@id";
				modif_mat.ExecuteNonQuery();

			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :\n" + e);
			}
		}

		public static void delMateriel(int id)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			try
			{
				MySqlCommand delete_mat = conn.CreateCommand();
				delete_mat.Parameters.AddWithValue("@id", id);
				delete_mat.CommandText = "DELETE FROM matériel WHERE id_matériel=@id";
				delete_mat.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :\n" + e);
			}

		}

		public static void addTech(int id, String nom, int NbIC, int NbIR)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			try
			{

				MySqlCommand add_tech = conn.CreateCommand();
				add_tech.Parameters.AddWithValue("@nom", nom);
				add_tech.Parameters.AddWithValue("@id", id);
				add_tech.Parameters.AddWithValue("@nbIC", NbIC);
				add_tech.Parameters.AddWithValue("@nbIR", NbIC);
				add_tech.CommandText = "INSERT INTO technicien(Id_T, Nom_T, NB_I_C, NB_I_R) VALUES (@id,@nom,@nbIC,@nbIR)";
				add_tech.ExecuteScalar();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :\n" + e);
			}
		}

		public static void addUser(int id, String nom, int nbID)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			try
			{

				MySqlCommand add_User = conn.CreateCommand();
				add_User.Parameters.AddWithValue("@nom", nom);
				add_User.Parameters.AddWithValue("@id", id);
				add_User.Parameters.AddWithValue("@nbID", nbID);
				add_User.CommandText = "INSERT INTO `utilisateur`(`Nom`, `Id`, `nb_Incident_Declare`) VALUES (@nom,@id,@nbID)";
				add_User.ExecuteScalar();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :\n" + e);
			}
		}

		public static void modifUser(int id, String nom, int nbID)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			try
			{

				MySqlCommand modif_user = conn.CreateCommand();
				modif_user.Parameters.AddWithValue("@nom", nom);
				modif_user.Parameters.AddWithValue("@id", id);
				modif_user.Parameters.AddWithValue("@nbID", nbID);
				modif_user.CommandText = "UPDATE `utilisateur` SET `Nom`=@nom,`Id`=@id,`nb_Incident_Declare`=@nbID WHERE Id=@id";
				modif_user.ExecuteScalar();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :\n" + e);
			}
		}

		public static void modifTech(int id, String nom, int nbIC, int nbIR)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			try
			{

				MySqlCommand Modif_T = conn.CreateCommand();
				Modif_T.Parameters.AddWithValue("@nom", nom);
				Modif_T.Parameters.AddWithValue("@id", id);
				Modif_T.Parameters.AddWithValue("@nbIC", nbIC);
				Modif_T.Parameters.AddWithValue("@nbIR", nbIR);
				Modif_T.CommandText = "UPDATE `technicien` SET `Id_T`=@id,`Nom_T`=@nom,`NB_I_C`=@nbIC,`NB_I_R`=nbIR WHERE Id_T=@id";
				Modif_T.ExecuteScalar();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :\n" + e);
			}
		}

		public static void delTech(int id)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			try
			{

				MySqlCommand del_Tech = conn.CreateCommand();
				del_Tech.Parameters.AddWithValue("@id", id);
				del_Tech.CommandText = "DELETE FROM `technicien` WHERE Id_T=@id";
				del_Tech.ExecuteScalar();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :\n" + e);
			}
		}

		public static void delUser(int id)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=bd_ppe;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			try
			{
				MySqlCommand add_User = conn.CreateCommand();
				add_User.Parameters.AddWithValue("@id", id);
				add_User.CommandText = "DELETE FROM `utilisateur` WHERE Id=@id";
				add_User.ExecuteScalar();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erreur :\n" + e);
			}
		}













	}
}
