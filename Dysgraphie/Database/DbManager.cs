using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;


/* DB IS LIKE 
 * ID / Nom / Prenom / Age / Classe / Genre / Lateralite
 * */

namespace Dysgraphie.Database
{
    //Classe permettant la gestion de la base de données
    public class DbManager
    {
        public SQLiteConnection m_dbConnection { get; set; }

        public DbManager(String DBname)
        {
            DBname += ".sqlite";
            String path = Path.Combine(Environment.CurrentDirectory, "data", DBname);
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
            }
            this.m_dbConnection = new SQLiteConnection("Data Source=" + path + ";Version=3;");
        }

        //Création de la base de données
        public void CreateDB()
        {          
            this.m_dbConnection.Open();
            this.NoQueryRequest("CREATE TABLE Children (ID INT PRIMARY KEY NOT NULL, Nom VARCHAR, Prenom VARCHAR, Age VARCHAR, Classe VARCHAR, Genre VARCHAR, Lateralite VARCHAR )");
            this.NoQueryRequest("CREATE TABLE Datas (ChildID INT, Symbole VARCHAR, VitesseMoyenne NUMERIC(32), TempsTrace NUMERIC(32), TempsPause NUMERIC(32), LongueurTrace NUMERIC(32), HauteurLettre NUMERIC(32), LargeurLettre NUMERIC(32), NbBlocs INTEGER, PressionMoyenne NUMERIC(32), AltitudeMoyenne NUMERIC(32), AzimuthMoyen NUMERIC(32), TwistMoyen NUMERIC(32))");
            this.m_dbConnection.Close();
        }

        //Connexion avec la base
        public void DBConnexion()
        {
           this.m_dbConnection.Open();
        }

        //Déconnexion avec la base
        public void DBDeconnexion()
        {
            this.m_dbConnection.Close();
        }

        //Retourne le dernier identifiant d'enfant
        public int getCurrentChildID()
        {
            string req = "SELECT max(ID) FROM Children";
            SQLiteCommand myCommand= new SQLiteCommand(req, this.m_dbConnection); ;
            this.m_dbConnection.Open();

            if (myCommand.ExecuteScalar().ToString() != "")
            {
                int maxId = Convert.ToInt32(myCommand.ExecuteScalar());
                this.m_dbConnection.Close();
                return maxId;
            }

            else {
                this.m_dbConnection.Close();
                return 0;
            }
        }

        //Exécution d'une requete sans retour (update, insert...)
        public void NoQueryRequest(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, this.m_dbConnection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine("erreur lors de l'execution de NoQueryRequest : " + e);
            }
        }

        //Exécution d'une requete avec retour (select)
        public SQLiteDataReader QueryRequest(string query)
        {

            
            string req = query;
            SQLiteCommand sqCommand = (SQLiteCommand)this.m_dbConnection.CreateCommand();
            sqCommand.CommandText = req;
           
            try
            {
                SQLiteDataReader reader = sqCommand.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Console.WriteLine("erreur lors de l'execution de QueryRequest : " + e);
            }

            return null;
        }
    }
}
