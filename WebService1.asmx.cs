using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;

namespace GsbApplicationWeb
{
    /// <summary>
    /// Description résumée de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
		/// <summary>
		/// print "hello world"
		/// </summary>
		/// <returns>string : hello world</returns>
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

		/// <summary>
		/// addition 2 valeurs
		/// </summary>
		/// <param name="nb1">valeur 1</param>
		/// <param name="nb2">valeur 2</param>
		/// <returns>resultat</returns>
        [WebMethod]
        public int Addition(int nb1, int nb2)
        {
            return nb1 + nb2;
        }

		//liste des méthodes concernant la table MEDICAMENTS
		/// <summary>
		/// Get liste des id de la table Medicaments
		/// </summary>
		/// <returns>le tableau des ids</returns>
		[WebMethod]
        public String[] GetListMedicaments()
        {
			
				// Connection Base de Données
				String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
				MySqlConnection conn = new MySqlConnection(connString);
				conn.Open();



				// Creation Commande Select All Medicaments
				MySqlCommand get_M = conn.CreateCommand();
				get_M.CommandText = "SELECT * FROM medicaments";

				// Initialisation liste de String : id et nom des médicaments
				var listeMedicaments = new List<String>();
				MySqlDataReader datareader = get_M.ExecuteReader();
				while (datareader.Read())
				{
				listeMedicaments.Add(Convert.ToString(datareader["id_medicament"]));
				}

				// Incrémentation tableau pour return
				int size = listeMedicaments.Count;
				string[] test = new String[size];

				int i = 0;
				foreach(String medicament in listeMedicaments)
				{
					test[i] = medicament ;
					i++ ;
				}

				// return tableau id/nom des médicaments
				return test;
			









		}

		/// <summary>
		/// get Nom d'un medicament depuis son id
		/// </summary>
		/// <param name="id">l'id du medicament</param>
		/// <returns>le nom du medicament</returns>
		[WebMethod]
		public String GetNomMedicament(String id)
		{
			// Connexion Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			MySqlCommand get_M = conn.CreateCommand();
			
			get_M.CommandText = "SELECT nom_medicament FROM medicaments WHERE id_medicament = '" + id + "'";
			return Convert.ToString(get_M.ExecuteScalar());
			
		}

		/// <summary>
		/// get Nom d'un medicament depuis son id
		/// </summary>
		/// <param name="id">l'id du medicament</param>
		/// <returns>le nom du medicament</returns>
		[WebMethod]
		public String[] GetListProblemesMedicament(String id)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();



			// Creation Commande Select All Medicaments
			MySqlCommand get_M = conn.CreateCommand();
			get_M.CommandText = "select nom_probleme " +
				"from problemes " +
				"join soigner on problemes.code_probleme = soigner.code_probleme " +
				"join medicaments on medicaments.id_medicament = soigner.code_medicament " +
				"where id_medicament = " + id;

			// Initialisation liste de String : id et nom des médicaments
			var listeProblemes = new List<String>();
			MySqlDataReader datareader = get_M.ExecuteReader();
			while (datareader.Read())
			{
				listeProblemes.Add(Convert.ToString(datareader["nom_probleme"]));
			}

			// Incrémentation tableau pour return
			int size = listeProblemes.Count;
			string[] test = new String[size];

			int i = 0;
			foreach (String probleme in listeProblemes)
			{
				test[i] = probleme;
				i++;
			}

			if (size == 0)
			{
				string[] test2 = new string[1];
				test2[0] = "Aucun problème détecté";
				test = test2;


			}

			// return tableau id/nom des médicaments
			return test;

		}

		/// <summary>
		/// get Nom d'un medicament depuis son id
		/// </summary>
		/// <param name="id">l'id du medicament</param>
		/// <returns>le nom du medicament</returns>
		[WebMethod]
		public String[] GetListEffetsMedicament(String id)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();



			// Creation Commande Select All Medicaments
			MySqlCommand get_M = conn.CreateCommand();
			get_M.CommandText = "select nom_effet " +
				"from effets " +
				"join concerner on effets.id_effet = concerner.code_effet " +
				"join medicaments on medicaments.id_medicament = concerner.code_medicament " +
				"where id_medicament = " + id;

			// Initialisation liste de String : id et nom des médicaments
			var listeEffets = new List<String>();
			MySqlDataReader datareader = get_M.ExecuteReader();
			while (datareader.Read())
			{
				listeEffets.Add(Convert.ToString(datareader["nom_effet"]));
			}

			// Incrémentation tableau pour return
			int size = listeEffets.Count;
			string[] test = new String[size];

			int i = 0;
			foreach (String effet in listeEffets)
			{
				test[i] = effet;
				i++;
			}

			if(size == 0)
			{
				string[] test2 = new string[1];
				test2[0] = "Aucun effet détecté";
				test = test2;


			}

			

			// return tableau id/nom des médicaments
			return test;

		}


		/// <summary>
		/// set Nom d'un medicament depuis son id
		/// </summary>
		/// <param name="id">l'id du medicament</param>
		/// <returns>le nom du medicament</returns>
		[WebMethod]
		public void SetNomMedicament(String id, String newNom)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			MySqlCommand set_Id_Com = conn.CreateCommand();
			set_Id_Com.Parameters.AddWithValue("@new_Nom", newNom);
			set_Id_Com.Parameters.AddWithValue("@id", id);
			set_Id_Com.CommandText = "UPDATE medicaments SET nom_medicament = @new_Nom WHERE id_medicament = @id";
			set_Id_Com.ExecuteNonQuery();

		}

		



		/// <summary>
		/// get Description d'un medicament depuis son id
		/// </summary>
		/// <param name="id">l'id du medicament</param>
		/// <returns>la description du medicament</returns>
		[WebMethod]
		public String GetDescMedicament(String id)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			MySqlCommand get_M = conn.CreateCommand();
			
			get_M.CommandText = "SELECT description_medicament FROM medicaments WHERE id_medicament = '" + id + "'";
			return (Convert.ToString(get_M.ExecuteScalar()));
			
		}


		/// <summary>
		/// get boolean ordonnance d'un medicament depuis son id
		/// </summary>
		/// <param name="id">l'id du medicament</param>
		/// <returns>la valeur de l'ordonnance du medicament</returns>
		[WebMethod]
		public Boolean GetOrdMedicament(String id)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			MySqlCommand get_M = conn.CreateCommand();

			get_M.CommandText = "SELECT ordonnance_medicament FROM medicaments WHERE id_medicament = '" + id + "'";
			return Convert.ToBoolean(get_M.ExecuteScalar());

		}

		/// <summary>
		/// Get liste des id des médicaments sous ordonnance ou non
		/// </summary>
		/// <returns>le tableau des ids</returns>
		[WebMethod]
		public String[] GetListMedicamentsOrdonnance(Boolean ord)
		{

			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();



			// Creation Commande Select All Categories
			MySqlCommand get_M = conn.CreateCommand();
			get_M.CommandText = "SELECT * FROM medicaments WHERE ordonnance_medicament = " + ord;

			// Initialisation liste de String : id et nom des categories
			var listeCategories = new List<String>();
			MySqlDataReader datareader = get_M.ExecuteReader();
			while (datareader.Read())
			{
				listeCategories.Add(Convert.ToString(datareader["code_categorie"]));
			}

			// Incrémentation tableau pour return
			int size = listeCategories.Count;
			string[] test = new String[size];

			int i = 0;
			foreach (String categorie in listeCategories)
			{
				test[i] = categorie;
				i++;
			}

			// return tableau id/nom des médicaments
			return test;









		}







		//liste des méthodes concernant la table CATEGORIES
		/// <summary>
		/// Get liste des id de la table categories
		/// </summary>
		/// <returns>le tableau des ids</returns>
		[WebMethod]
		public String[] GetListCategories()
		{

			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();



			// Creation Commande Select All Categories
			MySqlCommand get_M = conn.CreateCommand();
			get_M.CommandText = "SELECT * FROM categories";

			// Initialisation liste de String : id et nom des categories
			var listeCategories = new List<String>();
			MySqlDataReader datareader = get_M.ExecuteReader();
			while (datareader.Read())
			{
				listeCategories.Add(Convert.ToString(datareader["code_categorie"]));
			}

			// Incrémentation tableau pour return
			int size = listeCategories.Count;
			string[] test = new String[size];

			int i = 0;
			foreach (String categorie in listeCategories)
			{
				test[i] = categorie;
				i++;
			}

			// return tableau id/nom des médicaments
			return test;
			








		}

		/// <summary>
		/// get Nom d'une categorie depuis son id
		/// </summary>
		/// <param name="id">l'id de la categorie</param>
		/// <returns>le nom de la categorie</returns>
		[WebMethod]
		public String GetNomCategorie(String id)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			MySqlCommand get_M = conn.CreateCommand();
			
			get_M.CommandText = "SELECT nom_categorie FROM categories WHERE code_categorie = '" + id + "'";
			return (Convert.ToString(get_M.ExecuteScalar()));
			
		}

		/// <summary>
		/// get description d'une categorie depuis son id
		/// </summary>
		/// <param name="id">l'id de la categorie</param>
		/// <returns>la description de la categorie</returns>
		[WebMethod]
		public String GetDescCategorie(String id)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			MySqlCommand get_M = conn.CreateCommand();
			
			get_M.CommandText = "SELECT description_categorie FROM categories WHERE code_categorie = '" + id + "'";
			return (Convert.ToString(get_M.ExecuteScalar()));
			
		}







		//liste des méthodes concernant la table EFFETS
		/// <summary>
		/// Get liste des id de la table Effets
		/// </summary>
		/// <returns>le tableau des ids</returns>
		[WebMethod]
		public String[] GetListEffets()
		{

			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();



			// Creation Commande Select All Categories
			MySqlCommand get_M = conn.CreateCommand();
			get_M.CommandText = "SELECT * FROM effets";

			// Initialisation liste de String : id et nom des categories
			var listeEffets = new List<String>();
			MySqlDataReader datareader = get_M.ExecuteReader();
			while (datareader.Read())
			{
				listeEffets.Add(Convert.ToString(datareader["id_effet"]));
			}

			// Incrémentation tableau pour return
			int size = listeEffets.Count;
			string[] test = new String[size];

			int i = 0;
			foreach (String effet in listeEffets)
			{
				test[i] = effet;
				i++;
			}

			// return tableau id/nom des médicaments
			return test;
			









		}

		/// <summary>
		/// get Nom d'un effet depuis son id
		/// </summary>
		/// <param name="id">l'id de l'effet</param>
		/// <returns>le nom de l'effet</returns>
		[WebMethod]
		public String GetNomEffet(String id)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			MySqlCommand get_M = conn.CreateCommand();
			
			get_M.CommandText = "SELECT nom_effet FROM effets WHERE id_effet = '" + id + "'";
			return (Convert.ToString(get_M.ExecuteScalar()));
			
		}

		/// <summary>
		/// get Description de l'effet depuis son id
		/// </summary>
		/// <param name="id">l'id de l'effet</param>
		/// <returns>la description de l'effet</returns>
		[WebMethod]
		public String GetDescEffet(String id)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			MySqlCommand get_M = conn.CreateCommand();
			
			get_M.CommandText = "SELECT description_effet FROM effets WHERE id_effet = '" + id + "'";
			return (Convert.ToString(get_M.ExecuteScalar()));
			
		}







		//liste des méthodes concernant la table PROBLEMES
		/// <summary>
		/// Get liste des id de la table Probleme
		/// </summary>
		/// <returns>le tableau des ids</returns>
		[WebMethod]
		public String[] GetListProblemes()
		{

			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();



			// Creation Commande Select All Categories
			MySqlCommand get_M = conn.CreateCommand();
			get_M.CommandText = "SELECT * FROM problemes";

			// Initialisation liste de String : id et nom des categories
			var listeProblemes = new List<String>();
			MySqlDataReader datareader = get_M.ExecuteReader();
			while (datareader.Read())
			{
				listeProblemes.Add(Convert.ToString(datareader["code_probleme"]));
			}

			// Incrémentation tableau pour return
			int size = listeProblemes.Count;
			string[] test = new String[size];

			int i = 0;
			foreach (String probleme in listeProblemes)
			{
				test[i] = probleme;
				i++;
			}

			// return tableau id/nom des médicaments
			return test;
			









		}

		/// <summary>
		/// get Nom d'un probleme depuis son id
		/// </summary>
		/// <param name="id">l'id du probleme</param>
		/// <returns>le Nom du probleme</returns>
		[WebMethod]
		public String GetNomProbleme(String id)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			MySqlCommand get_M = conn.CreateCommand();
			
			get_M.CommandText = "SELECT nom_probleme FROM problemes WHERE code_probleme = '" + id + "'";
			return (Convert.ToString(get_M.ExecuteScalar()));
			
		}

		/// <summary>
		/// get Description d'un probleme depuis on id
		/// </summary>
		/// <param name="id">l'id du probleme</param>
		/// <returns>la description du probleme</returns>
		[WebMethod]
		public String GetDescProbleme(String id)
		{
			// Connection Base de Données
			String connString = "Server=127.0.0.1;database=gsb;Uid=root;Password=;";
			MySqlConnection conn = new MySqlConnection(connString);
			conn.Open();

			MySqlCommand get_M = conn.CreateCommand();
			
			get_M.CommandText = "SELECT description_probleme FROM problemes WHERE code_probleme = '" + id + "'";
			return (Convert.ToString(get_M.ExecuteScalar()));
			
		}




	}
}


/*
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

		

			MySqlCommand get_user = conn.CreateCommand();
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

			

		}









		*/
