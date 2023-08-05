using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace PFA
{
    internal class connectbd
    {

        public static MySqlConnection GetConnection()
        {
            String cn = "server=127.0.0.1;username=root;password=;database=pfa;SSL Mode=None;";
            MySqlConnection con = new MySqlConnection(cn);
            try
            {
                con.Open();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;

        }
        ///FOURNISSEUR
        public static int NumFotrnisseur()
        {
            string sql = "SELECT MAX(SUBSTR(code_frs, 2)) + 1 AS plus_grand FROM fournisseur WHERE code_frs REGEXP '^F[0-9]+$'; ";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
           
                int maxCode = (Convert.ToInt32(dr[0]));
                return maxCode;
            


                
        }

        public static string NameUser(string name)
        {
            string sql = "SELECT nom FROM login WHERE adresse like @nom;";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@nom", name);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();

            // Check if any rows are returned
            if (dr.HasRows)
            {
                // Call Read() to move to the first row
                dr.Read();
                return dr["nom"].ToString();
            }
            else
            {
                return "No results found";
            }
        }

        public static int Login(login lo)
        {
            using (MySqlConnection con = GetConnection())
            {

                // Use parameterized query to prevent SQL injection
                string sql = "SELECT type FROM login WHERE adresse = @email AND motpasse = @password";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@email", lo.adresse);
                    cmd.Parameters.AddWithValue("@password", lo.motpasse); // Hash the password before storing it

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            // Get the user's type
                            int type = (int)dr["type"];
                            // Return 1 if the type is 1, 0 otherwise
                            return type == 1 ? 1 : 0;
                        }
                        else
                        {
                            // Return -1 if no results were returned
                            return -1;
                        }
                    }
                }
            }
        }



        public static void AjouterFournisseur(fournisseur fr)
        {

            using (MySqlConnection con = GetConnection())
            {
                try
                {

                    MySqlCommand cmd = new MySqlCommand("insert into fournisseur(code_frs,nom_frs,adresse,discr) Values  (@num,@nom,@adresse,@discr);", con);
                    cmd.Parameters.AddWithValue("@nom", fr.nom);
                    cmd.Parameters.AddWithValue("@num", fr.num);
                    cmd.Parameters.AddWithValue("@adresse", fr.adresse);
                    cmd.Parameters.AddWithValue("@discr", fr.description);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        MessageBox.Show("The supplier was added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while adding the supplier.");
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("erreur.");
                }
            }
        }

        public static List<fournisseur> RechercheFournisseur()
        {
            List<fournisseur> ListFourn = new List<fournisseur>();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT * FROM fournisseur";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {


                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fournisseur fr = new fournisseur();
                            fr.num = reader.GetString(0);
                            fr.nom = reader.GetString(1);
                            fr.adresse = reader.GetString(2);
                            fr.description = reader.GetString(3);

                            ListFourn.Add(fr);
                        }
                        return ListFourn;

                    }
                }
            }
        }
        public static List<fournisseur> RechercheFournisseur(String nom)
        {
            List<fournisseur> ListFourn = new List<fournisseur>();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT * FROM fournisseur where nom_frs like @nom; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@nom", "%" + nom + "%");
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fournisseur fr = new fournisseur();
                            fr.num =  reader.GetString(0);
                            fr.nom = reader.GetString(1);
                            fr.adresse = reader.GetString(2);
                            fr.description = reader.GetString(3);

                            ListFourn.Add(fr);
                        }
                        return ListFourn;

                    }
                }
            }
        }
        public static List<fournisseur> RechercheFournisseurNUM(int num)
        {
            List<fournisseur> ListFourn = new List<fournisseur>();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT * FROM fournisseur where code_frs like @num; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@num", "F%" + num + "%");
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fournisseur fr = new fournisseur();
                            fr.num = reader.GetString(0);
                            fr.nom = reader.GetString(1);
                            fr.adresse = reader.GetString(2);
                            fr.description = reader.GetString(3);

                            ListFourn.Add(fr);
                        }
                        return ListFourn;

                    }
                }
            }
        }
        public static String RechercheCodFrCamion(String mat)
        {
            String type;


            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT code_frs FROM camion where mat = @num; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@num", mat);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            type = (String)reader["code_frs"];

                            return type;
                        }

                    }
                }
            }
            return null;



        }
        public static void ModifierFournisseur(fournisseur fr)
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE fournisseur SET nom_frs = @nom, adresse = @adresse, discr = @discr WHERE code_frs like @id", con);
                    cmd.Parameters.AddWithValue("@nom", fr.nom);
                    cmd.Parameters.AddWithValue("@adresse", fr.adresse);
                    cmd.Parameters.AddWithValue("@discr", fr.description);
                    cmd.Parameters.AddWithValue("@id", "F"+fr.num);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        MessageBox.Show("The supplier was modified successfully.");
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while modifying the supplier.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error.");
                }
            }
        }
        ///Transporteur

        public static void AjouterTronsporteur(transporteur tr)
        {

            using (MySqlConnection con = GetConnection())
            {



                string selectQuery = "SELECT * FROM camion WHERE code_trs like @code_trs";
                MySqlCommand selectCommand = new MySqlCommand(selectQuery, con);
                selectCommand.Parameters.AddWithValue("@code_trs", tr.code_trs);
                using (MySqlDataReader reader = selectCommand.ExecuteReader())
                {


                    if (reader.HasRows)
                    {
                        // Le camion existe déjà dans la base
                        MessageBox.Show("Le Transporteur existe déjà dans la base.");
                    }
                    else
                    {
                        con.Close();
                        con.Open();






                        try
                        {

                            MySqlCommand cmd = new MySqlCommand("insert into transporteur(code_trs,nom_trs,adresse,description) Values  (@code_trs,@nom,@adresse,@discr);", con);
                            cmd.Parameters.AddWithValue("@code_trs", tr.code_trs);
                            cmd.Parameters.AddWithValue("@nom", tr.nom_trs);
                            cmd.Parameters.AddWithValue("@adresse", tr.adresse);
                            cmd.Parameters.AddWithValue("@discr", tr.description);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected == 1)
                            {
                                MessageBox.Show("The supplier was added successfully.");
                            }
                            else
                            {
                                MessageBox.Show("An error occurred while adding the supplier.");
                            }

                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("erreur.");
                        }
                    }
                }
            }
        }
        public static List<transporteur> RechercheTransporteur(String nom)
        {
            List<transporteur> ListFourn = new List<transporteur>();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT * FROM transporteur where nom_trs like @nom; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@nom", "%" + nom + "%");
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            transporteur tr = new transporteur();
                            tr.code_trs = reader.GetString(0);
                            tr.nom_trs = reader.GetString(1);
                            tr.adresse = reader.GetString(2);
                            tr.description = reader.GetString(3);

                            ListFourn.Add(tr);
                        }
                        return ListFourn;

                    }
                }
            }
        }
        public static List<transporteur> RechercheTRansport()
        {
            List<transporteur> transporteursx = new List<transporteur>();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT * FROM Transporteur";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            transporteur transporteurs = new transporteur();
                            transporteurs.code_trs = reader.GetString(0);
                            transporteurs.nom_trs = reader.GetString(1);
                            transporteurs.adresse = reader.GetString(2);
                            transporteurs.description = reader.GetString(3);
                            transporteursx.Add(transporteurs);
                        }
                        return transporteursx;

                    }
                }
            }
        }
        public static int NumTronsporteur()
        {
            string sql = "SELECT MAX(SUBSTR(code_trs, 2)) AS plus_grand FROM Transporteur WHERE code_trs REGEXP '^T[0-9]+$';";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();

            int maxCode = (Convert.ToInt32(dr[0] )+ 1);



            return maxCode;
        }
        ///////// chauffeur 
        public static string RechercheFornisseurCamion(String num)
        {
            string type;


            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT nom_frs FROM fournisseur where code_frs like @num; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@num", "F"+num);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            type = (string)reader["nom_frs"];

                            return type;
                        }

                    }
                }
            }
            return "";


        }
        public static List<string> RechercheChauffeur(String num)
        {
            List<string> chauffeurs = new List<string>();
            using (MySqlConnection con = GetConnection())
            {
                string sql = ("SELECT nom FROM chauffeur where code_trs like @num");

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@num", "%"+num + "%");
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ch = reader.GetString(0);
                            chauffeurs.Add(ch);

                        }
                        return chauffeurs;

                    }
                }
            }
        }
        public static void AjouterChauffeur(Chauffeur ch)
        {

            using (MySqlConnection con = GetConnection())
            {
                try
                {

                    MySqlCommand cmd = new MySqlCommand("INSERT INTO chauffeur (nom,code_trs) VALUES (@nom,@code_trs)", con);
                    cmd.Parameters.AddWithValue("@nom", ch.nom);
                    cmd.Parameters.AddWithValue("@code_trs",ch.code_trs);

                    cmd.ExecuteNonQuery();


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("erreur Ajout chauffeur.");
                }
            }
        }


        public static string RechercheTransportCamion(String num)
        {
            string type;


            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT nom_trs FROM transporteur where code_trs like @num; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@num", num);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            type = (string)reader["nom_trs"];

                            return type;
                        }

                    }
                }
            }
            return "";


        }


        public static String RechercheCodTrsCamion(String num)
        {
            String type;


            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT code_trs FROM camion where mat = @num; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@num", num);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            type = (String)reader["code_trs"];

                            return type;
                        }

                    }
                }
            }
            return null;


        }
        public static void AjouterCamion(Camion Cam)
        {
            // Vérifier si le camion existe déjà dans la base
            using (MySqlConnection con = GetConnection())
            {
                string selectQuery = "SELECT * FROM camion WHERE mat like @mat";
                MySqlCommand selectCommand = new MySqlCommand(selectQuery, con);
                selectCommand.Parameters.AddWithValue("@mat", Cam.Mat);
                using (MySqlDataReader reader = selectCommand.ExecuteReader())
                {


                    if (reader.HasRows)
                    {
                        // Le camion existe déjà dans la base
                        MessageBox.Show("Le camion existe déjà dans la base.");
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        // Le camion n'existe pas encore dans la base, on peut l'ajouter
                        string insertQuery = "INSERT INTO camion (mat, code_trs, code_frs) VALUES (@mat, @code_trs, @code_frs)";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, con);
                        insertCommand.Parameters.AddWithValue("@mat", Cam.Mat);
                        insertCommand.Parameters.AddWithValue("@code_trs", Cam.Code_trs);
                        insertCommand.Parameters.AddWithValue("@code_frs", Cam.Code_frs);

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        MessageBox.Show("Le camion a été ajouté à la base.");
                    }
                }
            }

        }

        public static DataTable RechercheCamion(String mat)
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT mat,nom_trs,nom_frs from camion JOIN transporteur USING (code_trs)LEFT OUTER JOIN fournisseur USING (code_frs) where mat like @nom; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@nom", "%" + mat + "%");



                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }
        //////// Produit

        public static void AjouterProduit(Produit pr)
        {

            using (MySqlConnection con = GetConnection())
            {
                try
                {

                    MySqlCommand cmd = new MySqlCommand("INSERT INTO produit (code_prd,nom_prd) VALUES ('',@nom)", con);
                    cmd.Parameters.AddWithValue("@nom", pr.nom);


                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Succes");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("erreur Ajout Produit.");
                }
            }
        }
        public static List<string> NomProduit()
        {
            List<string> NomPrd = new List<string>();
            using (MySqlConnection con = GetConnection())
            {
                string sql = ("SELECT nom_prd FROM produit ");

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ch = reader.GetString(0);
                            NomPrd.Add(ch);

                        }
                        return NomPrd;

                    }
                }
            }
        }
        public static int NumProduit()
        {
            string sql = "select max(code_prd) from Produit;";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();

            int maxCode = (int)dr[0] + 1;



            return maxCode;
        }
        public static DataTable RechercheCamion()
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT mat,nom_trs from camion JOIN transporteur USING (code_trs) ; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {




                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }
        public static DataTable RechercheListeCamion(String chaine)
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT mat,nom_trs from camion JOIN transporteur USING (code_trs) where mat like @mat or nom_trs like @mat; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@mat", "%" + chaine + "%");



                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }
        public static String RemplireBonAvec(String mat)
        {
            String type;

            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT code_trs from camion where mat like @mat ; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {

                    command.Parameters.AddWithValue("@mat", mat);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            type = Convert.ToString( reader["code_trs"]);

                            return type;
                        }

                        return "";
                    }
                }
            }
        }
        public static String RemplireBonNomTrs(String mat)
        {
            String type;

            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT nom_trs from transporteur where code_trs = @mat ; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {

                    command.Parameters.AddWithValue("@mat", mat);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            type = (String)(reader["nom_trs"]);

                            return type;
                        }

                        return null;
                    }
                }
            }
        }
        public static string RechercheBonCodeFornisseur(String num)
        {
            string type;


            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT code_frs FROM camion where mat like @nom; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@nom", num);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            type = (Convert.ToString(reader["code_frs"]));

                            return type;
                        }

                    }
                }
            }
            return null;


        }
        public static string RechercheBonNomFornisseur(String num)
        {
            string type;


            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT nom_frs FROM fournisseur where code_frs = @code; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@code", num);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            type = (string)(reader["nom_frs"]);

                            return type;
                        }
                        return null;

                    }
                }
            }
           


        }
        public static DataTable RecherchListeFournisseur()
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT code_frs,nom_frs,adresse from fournisseur ; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {




                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }
        public static DataTable RechercheListeFournisseur(String chaine)
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT code_frs,nom_frs,adresse from fournisseur where code_frs like @mat or nom_frs like @mat; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@mat", "%" + chaine + "%");



                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }
        public static DataTable RechercheListetransporteur(String chaine)
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT code_trs,nom_trs from transporteur where code_trs like @mat or nom_trs like @mat; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@mat", "%" + chaine + "%");



                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }

        public static DataTable RecherchListeTransporrteur()
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT code_trs,nom_trs from transporteur ; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {




                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }
        public static DataTable RecherchListeProduit()
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT code_prd,nom_prd from produit ; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {




                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }
        public static DataTable RechercheListeProduit(String chaine)
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT code_prd,nom_prd from produit where code_prd like @mat or nom_prd like @mat; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@mat", "%" + chaine + "%");



                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }
        public static String RemplireBonNomPrd(String mat)
        {
            String type;

            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT nom_prd from produit where code_prd = @mat ; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {

                    command.Parameters.AddWithValue("@mat", mat);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            type = (String)(reader["nom_prd"]);

                            return type;
                        }

                        return null;
                    }
                }
            }
        }
        //////////////////BON///////////
        public static int NumBon()
        {
            string sql = "SELECT MAX(CAST(SUBSTR(code_bon, 2) AS UNSIGNED)) + 1 AS plus_grand\r\nFROM bon\r\nWHERE code_bon REGEXP '^(B[0-9]+)$';";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();

            int maxCode = (Convert.ToInt32(dr[0]));
            return maxCode;




        }
        public static DataTable BonNonTerminer()
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT code_bon,mat,nom_frs,poid_net,nom_prd,type FROM bon join fournisseur using(code_frs) join produit using(code_prd) where poid_tare is null or poid_tare like '' or poid_brut is null or poid_brut like '';";
                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    



                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                    return result;
                  }
            }
        }

         public static bool DoesFournisseurExist(string name)
        {
            using (MySqlConnection con = GetConnection())
            {

                string query = "SELECT COUNT(*) FROM Fournisseur WHERE code_frs like @name";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@name", name);
                    using (MySqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            int count = reader.GetInt32(0);
                            return count > 0;

                        }
                }
            }
            return false;
        }
        public static bool DoesTransporteurExist(string name)
        {
            using (MySqlConnection con = GetConnection())
            {
               
                string query = "SELECT COUNT(*) FROM transporteur WHERE code_trs like @name";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@name", name);
                    using (MySqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            int count = reader.GetInt32(0);
                            return count > 0;

                        }
                }
            }
            return false;
        }
        public static bool DoesMatriculeExist(string name)
        {
            using (MySqlConnection con = GetConnection())
            {

                string query = "SELECT COUNT(*) FROM camion WHERE mat like @name";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@name", name);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = reader.GetInt32(0);
                            return count > 0;
                            
                        }

                    }
                }
            }
            return false;
        }
        public static void AjouterBon(Bon bn)
        {

            using (MySqlConnection con = GetConnection())
            {
                try
                {

                    MySqlCommand cmd = new MySqlCommand("INSERT INTO `bon` (`code_bon`, `mat`, `code_frs`, `code_trs`, `code_prd`, `poid_brut`, `poid_tare`, `poid_net`, `nom_ch`, `etat`, `type`, `date`, `date_ent`, `date_sor`) VALUES (@code_bn, @mat, @code_frs   , @code_trs, @code_prd, @brut,@tare,@net,@nomch ,@etat,@type,@date_day,@date_ent,@date_sor);", con);
                    cmd.Parameters.AddWithValue("@code_bn",bn.code_bn);
                    cmd.Parameters.AddWithValue("@mat", bn.mat);
                    cmd.Parameters.AddWithValue("@code_frs", bn.code_frs);
                    cmd.Parameters.AddWithValue("@code_trs", bn.code_trs);
                    cmd.Parameters.AddWithValue("@code_prd", bn.code_prd);
                    cmd.Parameters.AddWithValue("@brut", bn.poid_brut);
                    cmd.Parameters.AddWithValue("@tare", bn.poid_tare);
                    cmd.Parameters.AddWithValue("@net", bn.poid_net);
                    cmd.Parameters.AddWithValue("@nomch", bn.nom_ch);
                    cmd.Parameters.AddWithValue("@etat", bn.etat);
                    cmd.Parameters.AddWithValue("@type", bn.type);
                    cmd.Parameters.AddWithValue("@date_day", bn.date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@date_ent", bn.date_ent);
                    cmd.Parameters.AddWithValue("@date_sor", bn.date_sor);



                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Succes");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("erreur Ajout Bon.");
                }
            }
        }
        public static bool DoesproduitExist(string name)
        {
            using (MySqlConnection con = GetConnection())
            {

                string query = "SELECT COUNT(*) FROM produit WHERE code_prd like @name";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@name", name);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = reader.GetInt32(0);
                            return count > 0;

                        }

                    }
                }
            }
            return false;
        }
        public static bool DoesproduitExist2(string name)
        {
            using (MySqlConnection con = GetConnection())
            {

                string query = "SELECT COUNT(*) FROM Bon WHERE code_prd like (select code_prd from produit where nom_prd like @name)";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@name", name);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = reader.GetInt32(0);
                            return count > 0;

                        }

                    }
                }
            }
            return false;
        }
        public static bool DoesChauffeurExiste(Chauffeur ch)
        {
            using (MySqlConnection con = GetConnection())
            {

                string query = "SELECT COUNT(*) FROM chauffeur WHERE nom  like @nom and code_trs like @code";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@nom",ch.nom );
                    command.Parameters.AddWithValue("@code",ch.code_trs);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = reader.GetInt32(0);
                            return count > 0;

                        }

                    }
                }
            }
            return false;
        }


        public static DataTable RechercheMatBon(String mat)
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT * from bon  where code_bon like @nom; ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@nom",  mat );



                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {

                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }

        public static void UpdateBon(Bon bn)
        {
            using (MySqlConnection con = GetConnection())
            {
                string query = "UPDATE `bon` SET `mat`=@mat, `code_frs`=@code_frs, `code_trs`=@code_trs, `code_prd`=@code_prd, `poid_brut`=@poid_brut, `poid_tare`=@poid_tare, `poid_net`=@poid_net, `nom_ch`=@nom_ch, `etat`=@etat, `date_ent`=@date_ent, `date_sor`=@date_sor WHERE `code_bon`=@code_bon";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@mat", bn.mat);
                    command.Parameters.AddWithValue("@code_frs", bn.code_frs);
                    command.Parameters.AddWithValue("@code_trs", bn.code_trs);
                    command.Parameters.AddWithValue("@code_prd", bn.code_prd);
                    command.Parameters.AddWithValue("@poid_brut", bn.poid_brut);
                    command.Parameters.AddWithValue("@poid_tare", bn.poid_tare);
                    command.Parameters.AddWithValue("@poid_net", bn.poid_net);
                    command.Parameters.AddWithValue("@nom_ch", bn.nom_ch);
                    command.Parameters.AddWithValue("@etat", bn.etat);
                    command.Parameters.AddWithValue("@date_ent", bn.date_ent);
                    command.Parameters.AddWithValue("@date_sor", bn.date_sor);
                    command.Parameters.AddWithValue("@code_bon", bn.code_bn);

                    command.ExecuteNonQuery();

                }
            }
        }
        public static void UpdateTransporteur(transporteur tr)
        {
            using (MySqlConnection con = GetConnection())
            {
                string query = "UPDATE `transporteur` SET `nom_trs`=@nom_trs,`adresse`=@adresse,`description`=@discription WHERE `code_trs` like @code;";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@nom_trs", tr.nom_trs);
                    command.Parameters.AddWithValue("@adresse", tr.adresse);
                    command.Parameters.AddWithValue("@description", tr.description);
                    command.Parameters.AddWithValue("@code", tr.code_trs);

                    command.ExecuteNonQuery();

                }
            }
        }
        public static void UpdateBonModification(Bon bn)
        {
            using (MySqlConnection con = GetConnection())
            {
                string query = "UPDATE `bon` SET `mat`=@mat, `code_frs`=@code_frs, `code_trs`=@code_trs, `code_prd`=@code_prd, `poid_brut`=@poid_brut, `poid_tare`=@poid_tare, `poid_net`=@poid_net, `nom_ch`=@nom_ch, `etat`=@etat WHERE `code_bon`=@code_bon";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@mat", bn.mat);
                    command.Parameters.AddWithValue("@code_frs", bn.code_frs);
                    command.Parameters.AddWithValue("@code_trs", bn.code_trs);
                    command.Parameters.AddWithValue("@code_prd", bn.code_prd);
                    command.Parameters.AddWithValue("@poid_brut", bn.poid_brut);
                    command.Parameters.AddWithValue("@poid_tare", bn.poid_tare);
                    command.Parameters.AddWithValue("@poid_net", bn.poid_net);
                    command.Parameters.AddWithValue("@nom_ch", bn.nom_ch);
                    command.Parameters.AddWithValue("@etat", bn.etat);
                   
                    command.Parameters.AddWithValue("@code_bon", bn.code_bn);

                    command.ExecuteNonQuery();

                }
            }
        }
        public static bool DoesBonExist(string name)
        {
            using (MySqlConnection con = GetConnection())
            {

                string query = "SELECT COUNT(*) FROM Bon WHERE code_bon like @name";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@name", name);
                    using (MySqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            int count = reader.GetInt32(0);
                            return count > 0;

                        }
                }
            }
            return false;
        }


        ////////////Ajouter Compte/////////////
        public static void AjouterCompte(login lg)
        {

            using (MySqlConnection con = GetConnection())
            {
                try
                {

                    MySqlCommand cmd = new MySqlCommand("INSERT INTO `login`(`adresse`, `motpasse`, `type`, `nom`) VALUES (@adresse,@mp,@type,@nom);", con);
                    cmd.Parameters.AddWithValue("@adresse", lg.adresse);
                    cmd.Parameters.AddWithValue("@mp", lg.motpasse);
                    cmd.Parameters.AddWithValue("@type",lg.type);
                    cmd.Parameters.AddWithValue("@nom", lg.nom);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        MessageBox.Show("The supplier was added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while adding the supplier.");
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("erreur.");
                }
            }
        }
        public static bool DoesCompteExiste(string name)
        {
            using (MySqlConnection con = GetConnection())
            {

                string query = "SELECT COUNT(*) FROM login WHERE adresse like @name";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@name", name);
                    using (MySqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            int count = reader.GetInt32(0);
                            return count > 0;

                        }
                }
            }
            return false;
        }
        public static void UpdateCompte(login bn)
        {
            using (MySqlConnection con = GetConnection())
            {
                string query = "UPDATE `login` SET `motpasse`=@mp,`type`=@type,`nom`=@nom WHERE adresse like @ad";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@ad", bn.adresse);
                    command.Parameters.AddWithValue("@mp", bn.motpasse);
                    command.Parameters.AddWithValue("@nom", bn.nom);
                    command.Parameters.AddWithValue("@type", bn.type);
                   

                    command.ExecuteNonQuery();

                }
            }
        }
        public static DataTable Comptes()
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT * FROM `login` WHERE 1;";
                using (MySqlCommand command = new MySqlCommand(sql, con))
                {




                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                    return result;
                }
            }
        }
        public static void supprimerProduit(string fr)
        {

            using (MySqlConnection con = GetConnection())
            {
                try
                {

                    MySqlCommand cmd = new MySqlCommand("DELETE FROM `produit` WHERE nom_prd like @nom;", con);
                    cmd.Parameters.AddWithValue("@nom", fr);
                   
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        MessageBox.Show("The supplier was added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while adding the supplier.");
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("erreur.");
                }
            }
        }


        public static DataTable RechercheProduit(String code,DateTime d1)
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT * from bon  where code_prd like @code and date> @date and etat not like 'Annuler'  ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@code", code);
                    command.Parameters.AddWithValue("@date", d1);



                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {

                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }
        public static DataTable RechercheProduit(String code)
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT * from bon  where code_prd like @code   ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@code", code);
               



                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {

                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }
        public static DataTable RechercheProduit1(String code, DateTime d1)
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT * from bon  where code_prd like @code and date< @date and etat not like 'Annuler'  ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@code", code);
                    command.Parameters.AddWithValue("@date", d1);



                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {

                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }

        public static DataTable RechercheProduit1(String code, DateTime d1, DateTime d2)
        {
            DataTable result = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                string sql = "SELECT * from bon  where code_prd like @code and date< @date and date> @date1 and etat not like 'Annuler'  ";

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@code", code);
                    command.Parameters.AddWithValue("@date", d1);
                    command.Parameters.AddWithValue("@date1", d2);



                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {

                        adapter.Fill(result);
                    }
                    return result;


                }
            }
        }



    }
}
   
   

