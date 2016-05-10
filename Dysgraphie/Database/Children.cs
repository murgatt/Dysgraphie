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
    class Children
    {
        private int ID;
        private string Nom;
        private string Prenom;
        private int Age;
        private string Classe;
        private string Genre;
        private string Lateralite;
        private DbManager dBmanager;

        Children(int ID, string Nom, string Prenom, int Age, string Classe, string Genre, string Lateralite)
      {
            this.ID = ID;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Age = Age;
            this.Classe = Classe;
            this.Genre = Genre;
            this.Lateralite = Lateralite;

            this.dBmanager.DBConnexion("myDB");
        }

        public void AddChildrenInDB()
        {
            string req = "Insert into ListChildren values ('" + this.ID + "','" + this.Nom + "','" + this.Prenom + "','" + this.Age + "','" + this.Classe + "','" + this.Genre + "','" + this.Lateralite + "' );";
            dBmanager.QueryRequest(req);
        }
    }
}
