using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DepuradorCanales
{
    public class TVShow
    {
        public int id;
        public string name;
        public int channel;
        public int estado;
    }


    public class TVChannel
    {
        public int id;
        public int channel;
        public string name;
    }

    public class Transaccion
    {
        public int id;
        public string fecha;
        public int estado;
        public int new_tvshow;
    }



}
