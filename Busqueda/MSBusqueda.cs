using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Runtime.InteropServices;

namespace Busqueda
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
        public ArrayList ListaPalabras;
        private MySqlConnection connection;
        public ArrayList Channels;
        public ArrayList Programas;
        public ArrayList Tipos1;
        public ArrayList Tipos2;
        public ArrayList Tipos3;

        public ArrayList AndOr1;
        public ArrayList AndOr2;

        public ArrayList Users;


        public ArrayList arrayMaestros;
        public ArrayList arrayDetalle;

        


        public int pagina;
        public bool ascendente;

        public int fillMaestro(string strwhere,bool is_withData,bool fulltext )
        {
            string sql;
            
            if (ascendente)
            {
                if (is_withData)
                {
                    if (fulltext)
                    {
                        sql = "select distinct tvdatafiles_name, tvdatafiles_id, tvdatafiles_recordDate ,tvdatafiles_Starttime,tvchannels_Channel,tvchannels_Name,   tvdatafiles_tvshow,tvshows_name,users_Name, storagetype_name ,tvdatafiles_host , serverlist_hostname from (SELECT * FROM `vw_consulta_fulltext` WHERE " + strwhere + "  ) tabla order by tvdatafiles_recordDate ";
                    }
                    else
                    {
                        sql = "select distinct tvdatafiles_name, tvdatafiles_id, tvdatafiles_recordDate ,tvdatafiles_Starttime,tvchannels_Channel,tvchannels_Name,   tvdatafiles_tvshow,tvshows_name,users_Name, storagetype_name ,tvdatafiles_host , serverlist_hostname from (SELECT * FROM `vw_consulta` WHERE " + strwhere + "  ) tabla order by tvdatafiles_recordDate ";
                    
                    }
                }
                else
                {
                    sql = "select distinct tvdatafiles_name, tvdatafiles_id, tvdatafiles_recordDate ,tvdatafiles_Starttime,tvchannels_Channel,tvchannels_Name,   tvdatafiles_tvshow,tvshows_name,users_Name, storagetype_name ,tvdatafiles_host , serverlist_hostname from (SELECT * FROM `vw_consulta_no_data` WHERE " + strwhere + "  ) tabla order by tvdatafiles_recordDate ";
                }
            }
            else
            {
                if (is_withData)
                {
                    if (fulltext)
                    {
                        sql = "select distinct tvdatafiles_name, tvdatafiles_id, tvdatafiles_recordDate ,tvdatafiles_Starttime,tvchannels_Channel,tvchannels_Name,   tvdatafiles_tvshow,tvshows_name,users_Name, storagetype_name ,tvdatafiles_host , serverlist_hostname from (SELECT * FROM `vw_consulta_fulltext` WHERE " + strwhere + "  ) tabla order by tvdatafiles_recordDate desc ";
                    }
                    else
                    {
                        sql = "select distinct tvdatafiles_name, tvdatafiles_id, tvdatafiles_recordDate ,tvdatafiles_Starttime,tvchannels_Channel,tvchannels_Name,   tvdatafiles_tvshow,tvshows_name,users_Name, storagetype_name ,tvdatafiles_host , serverlist_hostname from (SELECT * FROM `vw_consulta` WHERE " + strwhere + "  ) tabla order by tvdatafiles_recordDate desc ";
                    }
                }
                else
                {
                    sql = "select distinct tvdatafiles_name, tvdatafiles_id, tvdatafiles_recordDate ,tvdatafiles_Starttime,tvchannels_Channel,tvchannels_Name,   tvdatafiles_tvshow,tvshows_name,users_Name, storagetype_name ,tvdatafiles_host , serverlist_hostname from (SELECT * FROM `vw_consulta_no_data` WHERE " + strwhere + "  ) tabla order by tvdatafiles_recordDate desc ";
                }
            }
            
            sql = sql + " LIMIT " + this.pagina * 100 + " , " + 99; 
            
            
            
            Console.Write(sql +"\n");

            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            
            int int_tvdatafiles_id;
            int int_tvdatafiles_name;

            int int_tvdatafiles_recordDate;
            int int_tvdatafiles_Starttime;
            int int_tvchannels_Channel;
            int int_tvchannels_Name;
            int int_tvdatafiles_tvshow;
            int int_tvshows_name;
            int int_storagetype_name;
            int int_users_Name;

            int int_tvdatafiles_host;
            int int_serverlist_hostname;


            command.CommandText = sql ;
            command.CommandTimeout = int.MaxValue;
            Reader = command.ExecuteReader();
            

            int_tvdatafiles_id         = Reader.GetOrdinal("tvdatafiles_id");
            int_tvdatafiles_name       = Reader.GetOrdinal("tvdatafiles_name");

            int_tvdatafiles_recordDate = Reader.GetOrdinal("tvdatafiles_recordDate");
            int_tvdatafiles_Starttime  = Reader.GetOrdinal("tvdatafiles_Starttime");

            int_tvchannels_Channel     = Reader.GetOrdinal("tvchannels_Channel");
            int_tvchannels_Name        = Reader.GetOrdinal("tvchannels_Name");
            
            int_tvdatafiles_tvshow     = Reader.GetOrdinal("tvdatafiles_tvshow");
            int_tvshows_name           = Reader.GetOrdinal("tvshows_name");

            int_storagetype_name       = Reader.GetOrdinal("storagetype_name");
            int_users_Name             = Reader.GetOrdinal("users_Name");

            int_tvdatafiles_host       = Reader.GetOrdinal("tvdatafiles_host");
            int_serverlist_hostname    = Reader.GetOrdinal("serverlist_hostname");

            
            int resultado=0;
            while (Reader.Read())
            {
                resultado++;
                Maestro amaestro = new Maestro();
                
                amaestro.tvdatafiles_id         = Reader.GetValue(int_tvdatafiles_id).ToString();
                amaestro.tvdatafiles_name       = Reader.GetValue(int_tvdatafiles_name).ToString();
                
                if (Reader.GetValue(int_tvdatafiles_recordDate) != null)
                {
                    amaestro.tvdatafiles_recordDate = Reader.GetValue(int_tvdatafiles_recordDate).ToString();
                }
                else
                {
                    amaestro.tvdatafiles_recordDate = "";
                }


                amaestro.tvdatafiles_Starttime  = Reader.GetValue(int_tvdatafiles_Starttime).ToString();
                amaestro.tvchannels_Channel     = Reader.GetValue(int_tvchannels_Channel).ToString();
                amaestro.tvchannels_Name        = Reader.GetValue(int_tvchannels_Name).ToString();
                amaestro.tvdatafiles_tvshow     = Reader.GetValue(int_tvdatafiles_tvshow).ToString();
                amaestro.tvshows_name           = Reader.GetValue(int_tvshows_name).ToString();
                amaestro.storagetype_name       = Reader.GetValue(int_storagetype_name).ToString();
                amaestro.users_Name             = Reader.GetValue(int_users_Name).ToString();
                amaestro.tvdatafiles_host       = Reader.GetValue(int_tvdatafiles_host).ToString();
                amaestro.serverlist_hostname    = Reader.GetValue(int_serverlist_hostname).ToString();

                arrayMaestros.Add(amaestro);
            }
            Reader.Close();
            return resultado;
        }

        public void fillDateShowporFile(string str_datafile_id, ref string fecha, ref string show)
        {
            string sql;
            fecha = "";
            show = "";



            sql = "SELECT DISTINCT DATE_FORMAT(tvdatafiles_recordDate,'%Y-%m-%d') as tvdatafiles_recordDate , tvdatafiles_tvshow  FROM vw_consulta WHERE tvdatafiles_id = " + str_datafile_id;

            Console.Write(sql + "\n");

            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;

            int int_tvdatafiles_recordDate;
            int int_tvdatafiles_tvshow;

            command.CommandText = sql;
            command.CommandTimeout = int.MaxValue;
            Reader = command.ExecuteReader();

            int_tvdatafiles_recordDate = Reader.GetOrdinal("tvdatafiles_recordDate");
            int_tvdatafiles_tvshow = Reader.GetOrdinal("tvdatafiles_tvshow");
            while (Reader.Read())
            {
                fecha = Reader.GetValue(int_tvdatafiles_recordDate).ToString();
                show = Reader.GetValue(int_tvdatafiles_tvshow).ToString();
            }
            Reader.Close();


        }

        public int fillDetalle(string strwhere, string str_datafile_id, bool is_withData)
        {
            string sql;



            sql = "SELECT serverlist_hostname, tvdatafiles_id , tvdatafiles_name  , tvinfo_timepoint,tvinfo_infotype, tvinfo_data FROM `vw_consulta` WHERE " + strwhere + " and tvdatafiles_id = " + str_datafile_id + "  order by tvinfo_timepoint";
            Console.Write(sql + "\n");

            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;

            int int_tvinfo_timepoint;
            int int_tvinfo_infotype;
            int int_tvinfo_data;

            int int_tvdatafiles_id;
            int int_tvdatafiles_name;
            int int_serverlist_hostname;

            command.CommandText = sql;
            command.CommandTimeout = int.MaxValue;
            Reader = command.ExecuteReader();


            int_tvdatafiles_id = Reader.GetOrdinal("tvdatafiles_id");
            int_tvdatafiles_name = Reader.GetOrdinal("tvdatafiles_name");


            int_tvinfo_timepoint = Reader.GetOrdinal("tvinfo_timepoint");
            int_tvinfo_infotype = Reader.GetOrdinal("tvinfo_infotype");
            int_tvinfo_data = Reader.GetOrdinal("tvinfo_data");
            int_serverlist_hostname = Reader.GetOrdinal("serverlist_hostname");

            int resultado = 0;
            while (Reader.Read())
            {
                resultado++;
                Detalle aDetalle = new Detalle();

                aDetalle.tvinfo_timepoint = Reader.GetValue(int_tvinfo_timepoint).ToString();
                aDetalle.tvinfo_infotype = Reader.GetValue(int_tvinfo_infotype).ToString();
                aDetalle.tvinfo_data = Reader.GetValue(int_tvinfo_data).ToString();
                aDetalle.tvdatafiles_id = Reader.GetValue(int_tvdatafiles_id).ToString();
                aDetalle.tvdatafiles_name = Reader.GetValue(int_tvdatafiles_name).ToString();
                aDetalle.serverlist_hostname = Reader.GetValue(int_serverlist_hostname).ToString();

                arrayDetalle.Add(aDetalle);
            }
            Reader.Close();
            return resultado;
        }


  


        public int fillDetalleAll(string str_datafile_id, bool is_withData)
        {
            string sql;

            string fecha = "";
            string show = "";

            fillDateShowporFile(str_datafile_id, ref fecha, ref show);

            sql = "SELECT serverlist_hostname , tvdatafiles_id , tvdatafiles_name  ,  tvinfo_timepoint, tvinfo_infotype, tvinfo_data FROM `vw_consulta` WHERE  tvdatafiles_tvshow = '" + show + "' and tvdatafiles_recordDate = '" + fecha + "'  order by  tvdatafiles_id , tvinfo_timepoint";
            Console.Write(sql + "\n");

            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;

            int int_tvinfo_timepoint;
            int int_tvinfo_infotype;
            int int_tvinfo_data;

            int int_tvdatafiles_id;
            int int_tvdatafiles_name;

            int int_serverlist_hostname;

            command.CommandText = sql;
            command.CommandTimeout = int.MaxValue;
            Reader = command.ExecuteReader();

            int_tvdatafiles_id = Reader.GetOrdinal("tvdatafiles_id");
            int_tvdatafiles_name = Reader.GetOrdinal("tvdatafiles_name");




            int_tvinfo_timepoint = Reader.GetOrdinal("tvinfo_timepoint");
            int_tvinfo_infotype = Reader.GetOrdinal("tvinfo_infotype");
            int_tvinfo_data = Reader.GetOrdinal("tvinfo_data");

            int_serverlist_hostname = Reader.GetOrdinal("serverlist_hostname");


            int resultado = 0;
            while (Reader.Read())
            {
                resultado++;
                Detalle aDetalle = new Detalle();

                aDetalle.tvinfo_timepoint = Reader.GetValue(int_tvinfo_timepoint).ToString();
                aDetalle.tvinfo_infotype = Reader.GetValue(int_tvinfo_infotype).ToString();
                aDetalle.tvinfo_data = Reader.GetValue(int_tvinfo_data).ToString();


                aDetalle.tvdatafiles_id = Reader.GetValue(int_tvdatafiles_id).ToString();
                aDetalle.tvdatafiles_name = Reader.GetValue(int_tvdatafiles_name).ToString();

                aDetalle.serverlist_hostname = Reader.GetValue(int_serverlist_hostname).ToString();

                arrayDetalle.Add(aDetalle);
            }
            Reader.Close();
            return resultado;
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
                Channels.Add(new AddValue
                (Reader.GetValue(intDescription).ToString(), Reader.GetUInt32(intChannel)));

            }
            Reader.Close();
            return true;
        }

        public bool fillPrograms(long programa)
        {
            Programas.Clear();
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            int intId, intChannel, intDescription;
            //command.CommandText = "select id,name from tvshows where channel = " + programa.ToString() + " order by name ";
            command.CommandText = "select tvshows.id, tvshows.name from tvshows ,tvchannels  where  tvchannels.id =tvshows.channel  and tvchannels.channel = " + programa.ToString() + " order by tvshows.name ";

            Reader = command.ExecuteReader();
            intId = Reader.GetOrdinal("Id");
            intDescription = Reader.GetOrdinal("Name");
            while (Reader.Read())
            {
                Programas.Add(new AddValue
                (Reader.GetValue(intDescription).ToString(), Reader.GetUInt32(intId)));

            }
            Reader.Close();
            return true;
        }



        private bool fillTipos()
        {
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            int intId, intChannel, intDescription;
            command.CommandText = "select * from infotype";
            Reader = command.ExecuteReader();
            intId = Reader.GetOrdinal("Id");
            intDescription = Reader.GetOrdinal("name");
            intChannel = Reader.GetOrdinal("infotype");
            while (Reader.Read())
            {
                Tipos1.Add(new AddValue
                (Reader.GetValue(intDescription).ToString(), Reader.GetUInt32(intId)));

                Tipos2.Add(new AddValue
                (Reader.GetValue(intDescription).ToString(), Reader.GetUInt32(intId)));

                Tipos3.Add(new AddValue
                (Reader.GetValue(intDescription).ToString(), Reader.GetUInt32(intId)));

            }
            Reader.Close();
            return true;
        }

        private bool fillUsers()
        {
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            int intId, intChannel, intDescription;
            command.CommandText = "select * from users";
            Reader = command.ExecuteReader();
            intId = Reader.GetOrdinal("Id");
            intDescription = Reader.GetOrdinal("name");
            intChannel = Reader.GetOrdinal("UserName");
            while (Reader.Read())
            {
                Users.Add(new AddValue
                (Reader.GetValue(intDescription).ToString(), Reader.GetUInt32(intId)));
            }
            Reader.Close();
            return true;
        }

        
        
        
        bool fillAndOr()
        {
            AndOr1.Add(new AddValue
            ("And",1));
            AndOr1.Add(new AddValue
            ("Or", 2));

            AndOr2.Add(new AddValue
            ("And", 1));
            AndOr2.Add(new AddValue
            ("Or", 2));
            return true;
        }


        
        public MSBusqueda()
        {
            Channels      = new ArrayList();
            Programas     = new ArrayList();

            Tipos1        = new ArrayList();
            Tipos2        = new ArrayList();
            Tipos3        = new ArrayList();
            AndOr1        = new ArrayList();
            AndOr2        = new ArrayList();
            Users         = new ArrayList();
            ListaPalabras = new ArrayList();
            arrayMaestros = new ArrayList();
            arrayDetalle  = new ArrayList();





            this.ConnectToDb();
            this.fillChannels();


            this.fillTipos();
            this.fillAndOr();
            this.fillUsers();
        }


        public string getDateNew(string str)
        {
            if (str == "01")
            {
                return "Ene";
            }

            if (str == "02")
            {
                return "Feb";
            }
            if (str == "03")
            {
                return "Mar";
            }
            if (str == "04")
            {
                return "Abr";
            }
            if (str == "05")
            {
                return "May";
            }
            if (str == "06")
            {
                return "Jun";
            }
            if (str == "07")
            {
                return "Jul";
            }
            if (str == "08")
            {
                return "Ago";
            }
            if (str == "09")
            {
                return "Set";
            }
            if (str == "10")
            {
                return "Oct";
            }
            if (str == "11")
            {
                return "Nov";
            }
            if (str == "12")
            {
                return "Dic";
            }
            return "";
        }

        public string getStringFromIntInfoType(long valor)
        {
            switch (valor)
            {
                case 1:
                    return "D";
                case 2:
                    return "S";
                case 3:
                    return "E";
                case 4:
                    return "A";
                case 5:
                    return "T";
                case 6:
                    return "C";
                case 7:
                    return "I";
                case 8:
                    return "M";
                case 9:
                    return "R";

                case 10:
                    return "T";
            }
            return "";
        }


        
    
    }
}
