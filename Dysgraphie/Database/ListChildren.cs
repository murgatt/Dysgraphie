using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            dBmanager.QueryRequest(req);
        }
    }
}
