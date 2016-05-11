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
        List<Child> listChildren = new List<Child>();

        private DbManager dBmanager;

       


        //  Methode abstraite ?
         public void RemoveChild(int ID)
        {
            string req = "DELETE FROM ListChildren WHERE condition ID = " + ID + "; ";
            dBmanager.NoQueryRequest(req);
        }
        public List<Child> GetAllChildren()
        {
            string req = "select * from ListChildren";
            List<Child> tempListChildren = new List<Child>();
            SQLiteDataReader reader = (dBmanager.QueryRequest(req));
            while (reader.Read())
            {
                Child child = new Child(reader["ID"].ToString(), reader["Nom"].ToString(), reader["Prenom"].ToString(), reader["Age"].ToString(), reader["Classe"].ToString(), reader["Genre"].ToString(), reader["Lateralite"].ToString());
                tempListChildren.Add(child);
            }
            return tempListChildren;
        }
    }
}
