using Dysgraphie.Database;
using Dysgraphie.Views;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dysgraphie
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //DbManager manager = new DbManager("kikouDB");
            //manager.CreateDB();
            //StatTools st = new StatTools(manager);
            //st.mean("select * from Children", "");
            /*
            manager.DBConnexion();
            SQLiteDataReader r = manager.QueryRequest("SELECT * from Children, datas WHERE Children.id = datas.ChildID AND Lateralite = 'Gaucher'");
            while (r.Read())
            {
                Console.WriteLine(Convert.ToDouble(r["AzimuthMoyen"]));
                manager.NoQueryRequest("UPDATE Datas SET AzimuthMoyen ='" + (Convert.ToDouble(r["AzimuthMoyen"]) + 1800) + "' WHERE Symbole = '" + r["Symbole"] + "' AND TempsTrace = '" + r["TempsTrace"] + "' AND HauteurLettre = '" + r["HauteurLettre"] + "'");
                                               
            }
            manager.DBDeconnexion();
            */
            
        }
    }
}
