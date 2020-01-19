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
        private MySqlConnection connection2;

        public  ArrayList       ChannelsSource;
        public  ArrayList       ChannelsDest;

        public  ArrayList       ProgramasOrigen;
        public  ArrayList       ProgramasDest;



        public string  confFechaMax ;
        public string  confFechaMin;

        public int confCaracteresMinimos = 0;
        

        public ArrayList confArchivosNoBorrar = null;
        public ArrayList confFlagsNoBorrar = null;
        public ArrayList confId_programasnoborrar = null;
        public ArrayList confServidores = null;

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



            connection2 = new MySqlConnection(MyConString);
            connection2.Open();

            return true;
        }

        public static string ToCsv(ArrayList array)
        {
            return string.Join(",", (string[])array.ToArray(Type.GetType("System.String")));
        }


        public int controlInfotype(int idFile)
        {
            MySqlCommand command = connection2.CreateCommand();
            MySqlDataReader Reader;
            int intId;

            int salida = 0;
            command.CommandText = "select infotype  from tvinfo where fileid =" + idFile;
            Console.WriteLine(command.CommandText);

            Reader = command.ExecuteReader();
            intId = Reader.GetOrdinal("infotype");
            string dato;
            while (Reader.Read())
            {
                    dato = Reader.GetString(intId);
                     foreach ( String obj in confFlagsNoBorrar )
                     {
                         if (dato.IndexOf(obj) != -1)
                         {
                             salida = 1;
                             Reader.Close();
                             return salida;
                         }
                     }
            }
            Reader.Close();
            return salida;
        }


        public int cantText(int idFile)
        {
            MySqlCommand command = connection2.CreateCommand();
            MySqlDataReader Reader;
            int intId;

            int salida = 0;
            command.CommandText = "select IFNULL(sum(LENGTH(data)),0) as suma from tvinfo where fileid =" + idFile;
            Console.WriteLine(command.CommandText);

            Reader = command.ExecuteReader();
            intId = Reader.GetOrdinal("suma");
            while (Reader.Read())
            {
                salida = salida  + (int)Reader.GetUInt32(intId);
            }
            Reader.Close();
            return salida;
        }


        public string getNameToDelete(int idFile)
        {
            MySqlCommand command = connection2.CreateCommand();
            MySqlDataReader Reader;
            
            command.CommandText = "select serverlist_hostname ,tvdatafiles_recordDate, tvdatafiles_name  from vw_consulta_no_data where tvdatafiles_id =" + idFile;
            Console.WriteLine(command.CommandText);

            int int_tvdatafiles_recordDate;
            int int_serverlist_hostname;
            int int_tvdatafiles_name;

            string filenameandpath="";
            Reader = command.ExecuteReader();
            if (Reader.Read())
            {

                try
                {
                    int_tvdatafiles_recordDate = Reader.GetOrdinal("tvdatafiles_recordDate");
                    int_serverlist_hostname = Reader.GetOrdinal("serverlist_hostname");
                    int_tvdatafiles_name = Reader.GetOrdinal("tvdatafiles_name");

                    string tvdatafiles_name = Reader.GetValue(int_tvdatafiles_name).ToString();
                    string tvdatafiles_recordDate = Reader.GetValue(int_tvdatafiles_recordDate).ToString();
                    string hostname = Reader.GetValue(int_serverlist_hostname).ToString();

                    Int32 mes = System.Convert.ToInt32(tvdatafiles_recordDate.Substring(3, 2));
                    string strmes = mes.ToString();

                    filenameandpath = @"\\" + hostname + @"\tvfiles\" + tvdatafiles_recordDate.Substring(6, 4) + @"\" + strmes + @"\" + tvdatafiles_name;
                }
                catch (Exception e) 
                {
                    
                }


            }
            Reader.Close();

            return filenameandpath;
        }


        public ArrayList executeProcedure(bool move)
        {
            ArrayList retornoFuncion = new ArrayList();
            // confFechaMax ;
            // confFechaMin;

            // confCaracteresMinimos;
            // confRangoMesesAtras;
            string fecha_desde = confFechaMin;// String.Format("{0:yyyy-MM-dd}", confFechaMin);
            string fecha_hasta = confFechaMax; // String.Format("{0:yyyy-MM-dd}", confFechaMax);  

            int salida;
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            int intId;

            command.CommandText = "select distinct tvdatafiles_id as idFile    from   vw_consulta_no_data  where tvdatafiles_recordDate between '" + fecha_desde + "' and '" + fecha_hasta + "' and tvshows_id not in (" + ToCsv(confId_programasnoborrar) + ") and serverlist_hostname  in (" + ToCsv(confServidores) + ") and tvdatafiles_name  not in (" + ToCsv(confArchivosNoBorrar) + ") order by serverlist_hostname";
            Console.WriteLine(command.CommandText);

            Reader = command.ExecuteReader();
            intId = Reader.GetOrdinal("idFile");
            salida = 0;
            string filenameSource = "";
            string filenameDestination = "";
            while (Reader.Read())
            {
                salida = (int)Reader.GetUInt32(intId);
                // fijarse si tiene los flags ese programa.
                // contar los caracteres.
                // borrar
                filenameSource = "";
                filenameDestination = "_del_"+filenameSource;
                //System.IO.File.Move(filenameSource, filenameDestination);

                Console.WriteLine("id = " + salida );
                if (controlInfotype(salida)==0)
                {
                    if (confCaracteresMinimos == 0)
                    {
                        string origen = getNameToDelete(salida);
                        string destino = origen + ".borrame";

                        if (move)
                        {
                            retornoFuncion.Add("move \"" + origen + "\" \"" + destino + "\"");
                        }
                        else
                        {
                            retornoFuncion.Add("del \"" + origen + "\"");
                        }

                    }
                    else
                    {
                        int hay = 0;
                        hay = cantText(salida);

                        if (hay < confCaracteresMinimos)
                        {
                            // myformvisualizador.filename_path = @"\\" + iphostname + @"\tvfiles\" + maestroselected.tvdatafiles_recordDate.Substring(6, 4) + @"\" + strmes + @"\";
                            // retornoFuncion.Add("id = " + salida + " cant = " + cantText(salida) + " tiene " + tieneinfo + " " +getNameToDelete(salida));
                            string origen = getNameToDelete(salida);
                            string destino = origen + ".borrame";

                            if (move)
                            {
                                retornoFuncion.Add("move \"" + origen + "\" \"" + destino + "\"");
                            }
                            else
                            {
                                retornoFuncion.Add("del \"" + origen + "\"");
                            }
                        }
                    }
                }
            }
            Reader.Close();

            return retornoFuncion;
        }




        private bool DisConnectFromDb()
        {
            connection.Close();
            connection2.Close();

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
