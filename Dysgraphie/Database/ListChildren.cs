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
    class ListChildren
    {
        List<Children> listChildren = new List<Children>();

        private DbManager dBmanager;

       


        //  Methode abstraite ?
         public void RemoveChilden(int ID)
        {
            string req = "DELETE FROM ListChildren WHERE condition ID = " + ID + "; ";
            dBmanager.NoQueryRequest(req);
        }
        public List<Children> GetAllChildren()
        {
            string req = "select * from ListChildren";
            List<Children> tempListChildren = new List<Children>();
            SQLiteDataReader reader = (dBmanager.QueryRequest(req));
            while (reader.Read())
            {
                Children child = new Children(reader["ID"].ToString(), reader["Nom"].ToString(), reader["Prenom"].ToString(), reader["Age"].ToString(), reader["Classe"].ToString(), reader["Genre"].ToString(), reader["Lateralite"].ToString());
                tempListChildren.Add(child);
            }
            return tempListChildren;
        }
    }
}
