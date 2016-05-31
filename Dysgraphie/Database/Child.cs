using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dysgraphie.Database;
using System.Data.SQLite;

/* DB IS LIKE 
 * ID / Nom / Prenom / Age / Classe / Genre / Lateralite
 * */


namespace Dysgraphie.Database
{
    public class Child
    {
        private int ID;
        private string Nom;
        private string Prenom;
        private DateTime DateN;
        private int Age;
        private string Classe;
        private string Genre;
        private string Lateralite;



        public Child(int ID, String name, String forename, DateTime birth, String grade, String laterality, String gender)
        {
            this.Nom = name;
            this.Prenom = forename;
            this.DateN = birth;
            this.Classe = grade;
            this.Lateralite = laterality;
            this.Genre = gender;
            DateTime today = DateTime.Today;
            this.Age = today.Year - birth.Year;
            if (birth > today.AddYears(-this.Age))
            {
                Age--;
            }
        }


        public void EditChild( string Nom, string Prenom, int Age, string Classe, string Genre, string Lateralite)
        {
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Age = Age;
            this.Classe = Classe;
            this.Genre = Genre;
            this.Lateralite = Lateralite;
        }

        public int GetID()
        {
            return this.ID;
        }
        public string GetNom()
        {
            return this.Nom;
        }
        public string GetPrenom()
        {
            return this.Prenom;
        }

        public DateTime GetDateN()
        {
            return this.DateN;
        }

        public int GetAge()
        {
            return this.Age;
        }
        public string GetClasse()
        {
            return this.Classe;
        }
        public string GetGenre()
        {
            return this.Genre;
        }
        public string GetLateralite()
        {
            return this.Lateralite;
        }


        public bool alreadySaved(DbManager dBmanager)
        {
            dBmanager.DBConnexion();
            string req = "select * from Children WHERE Nom ='" + this.Nom + "' AND Prenom='" + this.Prenom + "' AND Age='" + this.Age + "' AND Classe='" + this.Classe + "' AND Genre='" + this.Genre + "' AND Lateralite='" + this.Lateralite + "'";
            SQLiteDataReader reader = dBmanager.QueryRequest(req);

            while (reader.Read())
            {
                this.ID = Convert.ToInt32(reader.GetInt32(0));
                dBmanager.DBDeconnexion();
                return true;
            }
            dBmanager.DBDeconnexion();
            return false;
        }


        public void AddChildInDB(DbManager dBmanager)
        {
            dBmanager.DBConnexion();
            string req = "Insert into Children values ('" + this.ID + "','" + this.Nom + "','" + this.Prenom + "','" + this.Age + "','" + this.Classe + "','" + this.Genre + "','" + this.Lateralite + "' );";
            dBmanager.QueryRequest(req);
            dBmanager.DBDeconnexion();
        }
    }
}
