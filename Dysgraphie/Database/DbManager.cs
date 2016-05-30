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
            this.NoQueryRequest("CREATE TABLE Datas (ChildID INT, Symbole VARCHAR, VitesseMoyenne NUMERIC(32), TempsTrace NUMERIC(32), TempsPause NUMERIC(32), LongueurTrace NUMERIC(32), HauteurLettre NUMERIC(32), LargeurLettre NUMERIC(32), NbBlocs INTEGER, PressionMoyenne NUMERIC(32), AltitudeMoyenne NUMERIC(32), AzimuthMoyen NUMERIC(32), TwistMoyen NUMERIC(32))");
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
