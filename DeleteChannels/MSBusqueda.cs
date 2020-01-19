using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Runtime.InteropServices;

namespace DeleteChannels
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
        public ArrayList ShowsNoVideos;

        public ArrayList Channels;
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
                ( Reader.GetValue(intDescription).ToString() , Reader.GetUInt32(intId)) );

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
            Tipos1        = new ArrayList();
            Tipos2        = new ArrayList();
            Tipos3        = new ArrayList();
            AndOr1        = new ArrayList();
            AndOr2        = new ArrayList();
            Users         = new ArrayList();
            ListaPalabras = new ArrayList();
            arrayMaestros = new ArrayList();
            arrayDetalle  = new ArrayList();

            ShowsNoVideos = new ArrayList();

            
            this.ConnectToDb();
            this.fillChannels();
            this.fillTipos();
            this.fillAndOr();
            this.fillUsers();
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


        public bool deleteShowNoVideos(string commas)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "delete from tvshows where id in (" + commas + ")";
            command.ExecuteNonQuery();
            return true;
        }


        public bool fillShowNoVideos()
        {
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            int intId, intChannel, intDescription;
            command.CommandText = "select id, name,channel,estado from tvshows LEFT JOIN (SELECT distinct tvshow as dato FROM `tvdatafiles`) as tvdatafiles2 ON tvshows.id= tvdatafiles2.dato  where dato is NULL";
            Reader = command.ExecuteReader();
            intId = Reader.GetOrdinal("Id");
            intDescription = Reader.GetOrdinal("Name");
            intChannel = Reader.GetOrdinal("Channel");
            ShowsNoVideos.Clear();
            while (Reader.Read())
            {
                ShowsNoVideos.Add(new AddValue
                (Reader.GetValue(intChannel).ToString() + " - " + Reader.GetValue(intDescription).ToString(), Reader.GetUInt32(intId)));
            }
            Reader.Close();
            return true;
        }


    
    }
}
