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
    class Children
    {
        List<Child> listChildren;
        private DbManager dBmanager;

        public Children(DbManager dbmanager)
        {
            listChildren = new List<Child>();
            this.dBmanager = dbmanager;
        }


        //  Methode abstraite ?
         public void RemoveChild(int ID)
        {
            dBmanager.DBConnexion();
            string req = "DELETE FROM Children WHERE condition ID = " + ID + "; ";
            dBmanager.NoQueryRequest(req);
            dBmanager.DBDeconnexion();
        }

        public void EditChildFromID(int ID, string Nom, string Prenom, int Age, string Classe, string Genre, string Lateralite)
        {
            foreach(Child c in listChildren)
            {
                if(c.GetID() == ID)
                {
                    c.EditChild( Nom, Prenom, Age, Classe, Genre, Lateralite);
                }
            }
        }
        /**
        public List<Child> GetAllChildren()
        {
            dBmanager.DBConnexion();
            string req = "select * from Children";
            SQLiteDataReader reader = (dBmanager.QueryRequest(req));
            while (reader.Read())
            {

                Child child = new Child(Convert.ToInt32(reader["ID"]), reader["Nom"].ToString(), reader["Prenom"].ToString(), Convert.ToInt32(reader["Age"]), reader["Classe"].ToString(), reader["Genre"].ToString(), reader["Lateralite"].ToString());
                listChildren.Add(child);
            }
            dBmanager.DBDeconnexion();
            return listChildren;
        }**/

    }
}
