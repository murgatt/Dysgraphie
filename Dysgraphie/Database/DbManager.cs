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

        private void CreateDB(string name)
        {
            SQLiteConnection.CreateFile("../../"+name+".sqlite");
        }

        public void DBConnexion(string name)
        {
           this.m_dbConnection =new SQLiteConnection("Data Source=../../"+name+".sqlite;Version=3;");
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
