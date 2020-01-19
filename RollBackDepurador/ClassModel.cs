using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RollBackDepurador
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
        public string id;
        public string fecha;
        public string estado;
        public string new_tvshow;
        public string tvshow_name;
        public string estado_descripcion;
        public string channel_name;

    }

    public class Transaccion_detalle
    {
        public string id;
        public string old_channel;
        public string old_show;

    }



}
