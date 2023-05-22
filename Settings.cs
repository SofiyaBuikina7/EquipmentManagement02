using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EquipmentManagement {
    public class Settings {
        public static string SettingsFileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Settings.json";
        public static string TranslationsFileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Translations.json";
        public static Settings CurrentSettings = LoadSettings();
        //public static Dictionary<string, Dictionary<string, string>> Translations = LoadTranslations();
        public static Dictionary<string, MyDictionary> Translations = LoadTranslations();

        public string SQLInstanceName { get; set; }
        public Font TableFont { get; set; }
        public Color EvenForeColor { get; set; }
        public Color EvenBackColor { get; set; }
        public Color OddForeColor { get; set; }
        public Color OddBackColor { get; set; }


        //public Color NormalForeColor { get; set; }
        //public Color NormalBackColor { get; set; }

        public Color BadForeColor { get; set; }
        public Color BadBackColor { get; set; }


        public void SaveSettings() {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(Settings.SettingsFileName)) {
                using (JsonWriter writer = new JsonTextWriter(sw)) {
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(writer, Settings.CurrentSettings);
                }
            }
        }
        private static Settings LoadSettings() {
            Settings Ret = null;
            if (File.Exists(Settings.SettingsFileName)) {
                using (StreamReader file = File.OpenText(Settings.SettingsFileName)) {
                    JsonSerializer serializer = new JsonSerializer();
                    Ret = (Settings)serializer.Deserialize(file, typeof(Settings));
                }
            }
            if (Ret == null) {
                Ret = new Settings();
                Ret.SaveSettings();
            }
            return Ret;
        }

        internal static void SaveTranslations() {
            string json = JsonConvert.SerializeObject(Translations, Formatting.Indented);
            File.WriteAllText(TranslationsFileName, json);
        }

        private static Dictionary<string, MyDictionary> LoadTranslations() {
            if (File.Exists(TranslationsFileName)) {
                string json = File.ReadAllText(TranslationsFileName);
                return JsonConvert.DeserializeObject<Dictionary<string, MyDictionary>>(json);
            } else {
                return new Dictionary<string, MyDictionary>();
            }
        }
        private static string _DBFileName;
        public static string DBFileName {
            get {
                if (String.IsNullOrEmpty(_DBFileName)) {
                    _DBFileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\EquipmentManagement";
                    if (CurrentSettings != null) {
                        CurrentSettings.SaveSettings();
                    }
                }
                if (!File.Exists(_DBFileName + ".mdf")) {
                    CreateDataBase(_DBFileName);
                }
                return _DBFileName;
            }
            set {
                _DBFileName = value;
            }
        }

        public static bool CreateDB { get;  set; }

        private static void CreateDataBase(string FileName) {
            //SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB");
            if (String.IsNullOrEmpty(Settings.CurrentSettings.SQLInstanceName)) {
                Settings.CurrentSettings.SQLInstanceName = "MSSQLLocalDB";
                Settings.CurrentSettings.SaveSettings();
            }
            SqlConnection connection = new SqlConnection(@"server=(localdb)\" + Settings.CurrentSettings.SQLInstanceName);
            using (connection) {
                connection.Open();

                string drop = "IF DB_ID('EquipmentManagement') IS NOT NULL\n" +
                              "\texec sp_detach_db @dbname='EquipmentManagement', @skipchecks=true; ";
                string sql = string.Format(@"CREATE DATABASE [EquipmentManagement]
                    ON PRIMARY (
                       NAME=EquipmentManagement,
                       FILENAME = '{0}.mdf'
                    )
                    LOG ON (
                        NAME=EquipmentManagement_log,
                        FILENAME = '{0}_log.ldf'
                    )",
                    FileName);

                SqlCommand command = new SqlCommand(drop, connection);
                command.ExecuteNonQuery();
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }



    }
    public class MyDictionary {
        public string Name { get; set; }
        public Dictionary<string, string> MyProperies { get; set; }
    }
}