using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SuS.Service.FileServices
{
    public static class SettingsFile
    {
        const string SettingsFileName = "app_settings.dat";

        // This NEEDS to be set in the globals.asax file
        public static string SettingsPath { get; set; }
        
        public static bool SettingsFileExists()
        {
            string checkFile = Path.Combine(SettingsPath, SettingsFileName);
            return File.Exists(checkFile);
        }

        public static bool CreateSettingsFile(string connectionString)
        {
            try
            {
                FileStream fs = new FileStream(Path.Combine(SettingsPath, SettingsFileName), FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(connectionString);
                sw.Close();
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
