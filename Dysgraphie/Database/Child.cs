using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dysgraphie.Database;

/* DB IS LIKE 
 * ID / Nom / Prenom / Age / Classe / Genre / Lateralite
 * */


namespace Dysgraphie.Database
{
    class Child
    {
        private string ID;
        private string Nom;
        private string Prenom;
        private string Age;
        private string Classe;
        private string Genre;
        private string Lateralite;
        private DbManager dBmanager;

        public Child(string ID, string Nom, string Prenom, string Age, string Classe, string Genre, string Lateralite)
      {
            this.ID = ID;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Age = Age;
            this.Classe = Classe;
            this.Genre = Genre;
            this.Lateralite = Lateralite;
            this.dBmanager = new DbManager();
            this.dBmanager.DBConnexion("myDB");
        }
        
        public void EditChild( string Nom, string Prenom, string Age, string Classe, string Genre, string Lateralite)
        {
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Age = Age;
            this.Classe = Classe;
            this.Genre = Genre;
            this.Lateralite = Lateralite;
        }

        public string GetID()
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
        public string GetAge()
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


        public void AddChildInDB()
        {
            string req = "Insert into ListChildren values ('" + this.ID + "','" + this.Nom + "','" + this.Prenom + "','" + this.Age + "','" + this.Classe + "','" + this.Genre + "','" + this.Lateralite + "' );";
            dBmanager.QueryRequest(req);
        }
    }
}
