using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace updateSingleSearch
{


    class Program
    {

        static void Main(string[] args)
        {
            MSBusqueda thebusqueda;
            thebusqueda = new MSBusqueda();
            string dfrom;
            if (args.Length == 0)
            {
                dfrom = thebusqueda.getdatestr();
                thebusqueda.getNewData(dfrom, dfrom);
            }
            else
            {
                thebusqueda.getNewData(args[0], args[1]);
            }
            thebusqueda.DisConnectFromDb();
        }
    }
}
