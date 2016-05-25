using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


/* DB IS LIKE 
 * ID / Nom / Prenom / Age / Classe / Genre / Lateralite
 * */

namespace Dysgraphie.Database
{
    class DbManager
    {
        public SQLiteConnection m_dbConnection { get; set; }

        public DbManager(String DBname)
        {
            this.m_dbConnection = new SQLiteConnection("Data Source=Database/" + DBname + ".sqlite;Version=3;");
        }

        public void CreateDB()
        {          
            this.m_dbConnection.Open();
            this.NoQueryRequest("CREATE TABLE Children (ID INT PRIMARY KEY NOT NULL, Nom VARCHAR, Prenom VARCHAR, Age VARCHAR, Classe VARCHAR, Genre VARCHAR, Lateralite VARCHAR )");
            this.NoQueryRequest("CREATE TABLE Datas (ChildID INT, Symbole VARCHAR, VitesseMoyenne NUMERIC, TempsTrace NUMERIC, TempsPause NUMERIC, LongueurTrace NUMERIC, HauteurLettre NUMERIC, LargeurLettre NUMERIC, NbBlocs INTEGER, PressionMoyenne NUMERIC, AltitudeMoyenne NUMERIC, AzimuthMoyen NUMERIC, TwistMoyen NUMERIC)");
            this.m_dbConnection.Close();
        }

        public void DBConnexion()
        {
           this.m_dbConnection.Open();
        }

        public void DBDeconnexion()
        {
            this.m_dbConnection.Close();
        }

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
        public SQLiteDataReader QueryRequest(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, this.m_dbConnection);
           
            try
            {
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    Console.WriteLine("nom: " + reader["Nom"] + "\tPrenom: " + reader["Prenom"]);
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
