using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Runtime.InteropServices;

namespace RollBackDepurador
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
        public  ArrayList       ArrayEstados;
        public ArrayList        arrayMaestros;

        public int fillEstados()
        { 
                ArrayEstados.Add(new AddValue("En Proceso", -1));
                ArrayEstados.Add(new AddValue("Completo", 1));
                ArrayEstados.Add(new AddValue("Deshecho", 2));
                return 1;
        }

        public int fillMaestro(string sql)
        {


            Console.Write(sql + "\n");

            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;

            int int_transaccion_id;
            int int_fecha;
            int int_transaccion_estado;
            int int_new_tvshow;
            int int_name;
            int int_tvchannels_name;


            command.CommandText = sql;
            command.CommandTimeout = int.MaxValue;
            Reader = command.ExecuteReader();


            int_transaccion_id = Reader.GetOrdinal("transaccion_id");
            int_fecha = Reader.GetOrdinal("fecha");
            int_transaccion_estado = Reader.GetOrdinal("transaccion_estado");
            int_new_tvshow = Reader.GetOrdinal("new_tvshow");
            int_name = Reader.GetOrdinal("name");
            int_tvchannels_name = Reader.GetOrdinal("tvchannels_name");

            
            int resultado = 0;
            while (Reader.Read())
            {
                resultado++;
                Transaccion amaestro = new Transaccion();

                /*
                 *         
                 public int id;
                 public string fecha;
                 public int estado;
                 public int new_tvshow;
                 public string tvshow_name;
                 public string estado_descripcion;
                 public string channel_name;

                 * */

                amaestro.id = Reader.GetValue(int_transaccion_id).ToString();
                amaestro.fecha = Reader.GetValue(int_fecha).ToString();
                amaestro.estado = Reader.GetValue(int_transaccion_estado).ToString();
                switch (amaestro.estado)
                {
                    case "-1":
                        amaestro.estado_descripcion = "En Proceso";
                        break;

                    case "1":
                        amaestro.estado_descripcion = "Completo";
                        break;

                    case "2":
                        amaestro.estado_descripcion = "Deshecho";
                        break;
                }
                amaestro.new_tvshow = Reader.GetValue(int_new_tvshow).ToString();
                amaestro.tvshow_name = Reader.GetValue(int_name).ToString();
                amaestro.channel_name = Reader.GetValue(int_tvchannels_name).ToString();

                arrayMaestros.Add(amaestro);
            }
            Reader.Close();
            return resultado;
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





        public int updateTransaccion(Transaccion atransaccion)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "update transaccion  set estado = 2 where id = " + atransaccion.id;

            command.ExecuteNonQuery();
            return 2; 
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



        public int DoRollback(Transaccion atransaccion)
        {
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            ArrayList arraydatos = new ArrayList();

            string sql;

            int int_id;
            int int_old_channel;
            int int_old_tvshow;

            sql = "SELECT id ,  old_channel, old_tvshow  FROM `old_tvdatafiles` WHERE transaccion_id = " + atransaccion.id;

            command.CommandText = sql;
            command.CommandTimeout = int.MaxValue;
            Reader = command.ExecuteReader();

            int_id = Reader.GetOrdinal("id");
            int_old_channel = Reader.GetOrdinal("old_channel");
            int_old_tvshow = Reader.GetOrdinal("old_tvshow");


            Transaccion_detalle adetalle;
            while (Reader.Read())
            {
                adetalle = new Transaccion_detalle();

                adetalle.id = Reader.GetValue(int_id).ToString();
                adetalle.old_channel = Reader.GetValue(int_old_channel).ToString();
                adetalle.old_show = Reader.GetValue(int_old_tvshow).ToString();

                arraydatos.Add(adetalle);
            }
            Reader.Close();

            int i;
            for (i = 0; i < arraydatos.Count; i++)
            {
                adetalle = (Transaccion_detalle)arraydatos[i];
                command.CommandText = "update  tvdatafiles set channel = " + adetalle.old_channel + " , tvshow = " + adetalle.old_show+ " where id = " + adetalle.id;
                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();
            }


            return 1;
 
            
            



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

            command.CommandText = "update tvdatafiles  set channel = " + ashow.channel + " , tvshow = " + atransaccion.new_tvshow + " where id  in (" + commaseparatedstring + ")";
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
        /*
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

        */
  



        public MSBusqueda()
        {
            ArrayEstados = new ArrayList();
            arrayMaestros = new ArrayList();
            fillEstados();
            this.ConnectToDb();
        }




    
    }
}
