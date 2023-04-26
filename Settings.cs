using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EquipmentManagement {
    public class Settings {
        public static string SettingsFileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Settings.json";
        public static string TranslationsFileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Translations.json";
        public static Settings CurrentSettings = LoadSettings();
        public static Dictionary<string, Dictionary<string, string>> Translations = LoadTranslations();

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

        private static Dictionary<string, Dictionary<string, string>> LoadTranslations() {
            if (File.Exists(TranslationsFileName)) {
                string json = File.ReadAllText(TranslationsFileName);
                return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
            } else {
                return new Dictionary<string, Dictionary<string, string>>();
            }
        }


    }
}