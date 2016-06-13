using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Database
{
    //Classe static permettant de calculer des valeur statistiques sur la BDD
    class StatTools
    {
        //Calcul de la moyenne
        public static double mean(DbManager manager, String query, String propertyName)
        {
            manager.DBConnexion();
            SQLiteDataReader reader = manager.QueryRequest(query);
            double sum = 0;
            int count = 0;
            while (reader.Read())
            {
                sum += Convert.ToDouble(reader[propertyName].ToString());
                ++count;
            }
            manager.DBDeconnexion();
            return sum/count;
        }

        //Calcul de l'écart-type
        public static double standardDeviation(DbManager manager, String query, String propertyName)
        {
            double mean = StatTools.mean(manager, query, propertyName);
            double sum = 0;

            manager.DBConnexion();
            SQLiteDataReader reader = manager.QueryRequest(query);
            int count = 0;
            while (reader.Read())
            {
                sum += Math.Pow((Convert.ToDouble(reader[propertyName])-mean),2);
                ++count;
            }
            manager.DBDeconnexion();
            return Math.Sqrt(sum / count);
            
        }
    }
}
