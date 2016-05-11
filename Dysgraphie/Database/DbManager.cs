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
        SQLiteConnection m_dbConnection;

        public void CreateDB(string DBName, string TableName)
        {
            SQLiteConnection.CreateFile("../../Database/"+ DBName + ".sqlite");
            this.m_dbConnection = new SQLiteConnection("Data Source=../../" + DBName + ".sqlite;Version=3;");
            this.m_dbConnection.Open();
            this.NoQueryRequest("CREATE TABLE "+TableName+ " (ID INT PRIMARY KEY NOT NULL, Nom VARCHAR, Prenom VARCHAR, Age VARCHAR, Classe VARCHAR, Genre VARCHAR, Lateralite VARCHAR )");
        }

        public void DBConnexion(string DBName)
        {
           this.m_dbConnection =new SQLiteConnection("Data Source=../../Database/"+ DBName + ".sqlite;Version=3;");
           this.m_dbConnection.Open();
        }
        public void NoQueryRequest(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, this.m_dbConnection);
            command.ExecuteNonQuery();
        }
        public SQLiteDataReader QueryRequest(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, this.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("nom: " + reader["Nom"] + "\tPrenom: " + reader["Prenom"]);
            return reader;
        }
    }
}
