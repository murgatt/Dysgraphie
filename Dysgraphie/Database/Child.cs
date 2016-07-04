using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dysgraphie.Database;
using System.Data.SQLite;
using System.Xml.Serialization;

/* DB IS LIKE 
 * ID / Nom / Prenom / Age / Classe / Genre / Lateralite
 * */


namespace Dysgraphie.Database
{
    //Cette classe représente un enfant

    //Elle est serialisée dans un document xml
    [Serializable]
    public class Child
    {
        [XmlAttribute()]
        public int ID { get; set; }
        [XmlAttribute()]
        public string Nom { get; set; }
        [XmlAttribute()]
        public string Prenom { get; set; }
        [XmlAttribute()]
        public DateTime DateN { get; set; }
        [XmlAttribute()]
        public int Age { get; set; }
        [XmlAttribute()]
        public string Classe { get; set; }
        [XmlAttribute()]
        public string Genre { get; set; }
        [XmlAttribute()]
        public string Lateralite { get; set; }
        [XmlAttribute()]
        public string Commenaire { get; set; }

        // Constructeur sans paramètres pour la sérialisation
        public Child()
        {
            // Nothing
        }

        public Child(int ID, String name, String forename, DateTime birth, String grade, String laterality, String gender)
        {
            this.ID = ID;
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


        public Child(String name, String forename, DateTime birth, String grade, String laterality, String gender)
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

        public void SetID(int id)
        {
            this.ID = id;
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

        //Renvoie vrai si un enfant existe déjà dans la base, avec les même nom, prénom, classe, genre et latéralité, sinon faux
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

        //Ajoute l'enfant à la base de données
        public void AddChildInDB(DbManager dBmanager)
        {
            dBmanager.DBConnexion();
            string req = "Insert into Children values ('" + this.ID + "','" + this.Nom + "','" + this.Prenom + "','" + this.Age + "','" + this.Classe + "','" + this.Genre + "','" + this.Lateralite + "' );";
            dBmanager.QueryRequest(req);
            dBmanager.DBDeconnexion();
        }
    }
}
