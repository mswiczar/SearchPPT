using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Runtime.InteropServices;

namespace DepuradorCanales
{

    public class AddValue
    {
        private string m_Display;
        private long m_Value;
        public AddValue(string Display, long Value)
        {
            m_Display = Display;
            m_Value = Value;
        }
        public string Display
        {
            get { return m_Display; }
        }
        public long Value
        {
            get { return m_Value; }
        }
    }

    public class MSBusqueda
    {
        private MySqlConnection connection;
        public  ArrayList       ChannelsSource;
        public  ArrayList       ChannelsDest;

        public  ArrayList       ProgramasOrigen;
        public  ArrayList       ProgramasDest;


        public int fillProgramas( int canal)
        {
            ProgramasOrigen.Clear();

            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            string sql;

            int int_tvshows_id;
            int int_tvshows_name;

            sql = "select id , name from tvshows where (estado =0 or estado = 2) and channel = "+ canal.ToString();

            command.CommandText = sql;
            command.CommandTimeout = int.MaxValue;
            Reader = command.ExecuteReader();

            int_tvshows_id = Reader.GetOrdinal("id");
            int_tvshows_name = Reader.GetOrdinal("name");

            while (Reader.Read())
            {
                ProgramasOrigen.Add(new AddValue
                    (Reader.GetValue(int_tvshows_name).ToString(), Reader.GetUInt32(int_tvshows_id)));
               // Console.WriteLine(Reader.GetValue(int_tvshows_name).ToString());

            }
            Reader.Close();
            return 1;
        }

        public int insertChannel(TVChannel achannel)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "insert into  tvchannels (Channel,Name) values (" + achannel.channel + ",'" + achannel.name + "')";
            command.ExecuteNonQuery();
            achannel.id = (int )command.LastInsertedId;
            return achannel.id;
        }


        public int insertShow(TVShow ashow)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "insert into  tvshows (name,channel,estado) values ('" + ashow.name + "'," + ashow.channel + ",2)";
            command.ExecuteNonQuery();
            ashow.id = (int) command.LastInsertedId;
            return ashow.id;

        }
        /*
             public class Transaccion
    {
        public int id;
        public string fecha;
        public int estado;
        public int new_channel;
        public int new_tvshow;}

         * 
         * 
         * Campo	Tipo	Nulo	Predeterminado	Comentarios
            id	int(11)	No 	 	 
            fecha	datetime	No 	 	 
            estado	int(11)	No 	 	 
            new_tvshow	int(10)	No 	 	 
         * 
         * }

         */



        public int insertTransaccion(Transaccion atransaccion)
        {

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "insert into  transaccion (fecha,estado,new_tvshow) values (now(),-1," + atransaccion.new_tvshow +")";
            command.ExecuteNonQuery();
            atransaccion.id = (int)command.LastInsertedId;
            atransaccion.fecha = DateTime.Now.ToString();
            atransaccion.estado = -1;
            return atransaccion.id; 
        }

        public int updateTransaccion(Transaccion atransaccion)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "update transaccion  set estado = " + atransaccion.estado + " where id = " + atransaccion.id;

            command.ExecuteNonQuery();
            return atransaccion.estado; 
        }


        public int makeRollback(Transaccion atransaccion, ArrayList aprogramasdest)
        {
            MySqlCommand command = connection.CreateCommand();
            string commaseparatedstring;
            int i;
            commaseparatedstring = "-1000";
            for (i=0;i<aprogramasdest.Count; i++)
            {
                AddValue avalue = (AddValue)aprogramasdest[i];
                commaseparatedstring = commaseparatedstring + " , " +avalue.Value;
            }

            command.CommandText = "insert into old_tvdatafiles (id,old_channel,old_tvshow,new_tvshow,transaccion_id)  select id ,channel,tvshow," + atransaccion.new_tvshow + "," + atransaccion.id + " from tvdatafiles  where tvshow  in (" + commaseparatedstring + ")";
            command.ExecuteNonQuery();
            return 0; 
        
        }

        public int updateTvdatafiles(Transaccion atransaccion, ArrayList aprogramasdest, TVShow ashow)
        {
            MySqlCommand command = connection.CreateCommand();
            string commaseparatedstring;
            int i;
            commaseparatedstring = "-1000";
            for (i = 0; i < aprogramasdest.Count; i++)
            {
                AddValue avalue = (AddValue)aprogramasdest[i];
                commaseparatedstring = commaseparatedstring + " , " + avalue.Value;
            }

            command.CommandText = "update tvdatafiles  set channel = " + ashow.channel + " , tvshow = " + atransaccion.new_tvshow + " where tvshow  in (" + commaseparatedstring + ")";
            command.ExecuteNonQuery();
            return 0;

        }
        //thebusqueda.updateTvshow(atransaccion, thebusqueda.ProgramasDest);

        public int updateTvshow(Transaccion atransaccion, ArrayList aprogramasdest)
        {
            MySqlCommand command = connection.CreateCommand();
            string commaseparatedstring;
            int i;
            commaseparatedstring = "-1000";
            for (i = 0; i < aprogramasdest.Count; i++)
            {
                AddValue avalue = (AddValue)aprogramasdest[i];
                commaseparatedstring = commaseparatedstring + " , " + avalue.Value;
            }

            command.CommandText = "update  tvshows  set estado = -1  where id  in (" + commaseparatedstring + ") and estado =0";

            command.ExecuteNonQuery();
            return 0;

            
        
        }


        public int existeShowChannel(TVShow ashow)
        {
            int salida;
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            int intId, intChannel, intDescription;
            command.CommandText = "select id from tvshows where estado = 2 and name ='"+ashow.name+"' and channel =" + ashow.channel;
            Reader = command.ExecuteReader();
            intId = Reader.GetOrdinal("Id");
            salida = 0;
            while (Reader.Read())
            {
                salida = (int)Reader.GetUInt32(intId);
            }
            Reader.Close();
            return salida;
        }




        private bool ConnectToDb ()
        {

            IniFile ini = new IniFile(@"./db.ini");

            string strServer = ini.IniReadValue("database", "host");
            string strDatabase = ini.IniReadValue("database", "db");
            string strUser = ini.IniReadValue("database", "user");
            string strPass = ini.IniReadValue("database", "pass");
            
            string MyConString = "SERVER="+strServer +";" +
                    "DATABASE=" + strDatabase + ";" +
                    "UID=" + strUser + ";" +
                    "PASSWORD=" + strPass + ";";
            connection = new MySqlConnection(MyConString);
            connection.Open();

            return true;
        }

        private bool DisConnectFromDb()
        {
            connection.Close();
            return true;

        }

        private bool fillChannels()
        {
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            int intId , intChannel , intDescription;
            command.CommandText = "select * from tvchannels order by name ";
            Reader = command.ExecuteReader();
            intId = Reader.GetOrdinal("Id");
            intDescription = Reader.GetOrdinal("Name");
            intChannel = Reader.GetOrdinal("Channel");
            while (Reader.Read())
            {
                ChannelsSource.Add(new AddValue
                ( Reader.GetValue(intDescription).ToString() , Reader.GetUInt32(intId)) );

                ChannelsDest.Add(new AddValue
                (Reader.GetValue(intDescription).ToString(), Reader.GetUInt32(intId)));
            }
            Reader.Close();
            return true;
        }


  



        public MSBusqueda()
        {
            ChannelsSource      = new ArrayList();
            ChannelsDest        = new ArrayList();
            ProgramasOrigen     = new ArrayList();
            ProgramasDest       = new ArrayList();
            this.ConnectToDb();
            this.fillChannels();
        }




    
    }
}
