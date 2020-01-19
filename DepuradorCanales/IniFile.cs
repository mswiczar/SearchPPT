using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;



namespace DepuradorCanales
{
    class IniFile
    {
        public string path;


        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                    string key, string def, StringBuilder retVal,
               int size, string filePath);


          
        public IniFile(string INIPath)
        {
            path = INIPath;
        }


        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, this.path);
            return temp.ToString();

        }
    }
}
