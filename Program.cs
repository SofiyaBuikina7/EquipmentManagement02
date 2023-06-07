using EquipmentManagement.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentManagement {
    static class Program {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Settings.CreateDB = true;
            foreach (var arg in args) {
                if (arg.ToLower().Contains("-migrate")){
                    Settings.CreateDB = false;
                }
            }
            
            SetConnectionString();
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK) {
                Application.Run(new MainForm());
            }


            //try {
            //    var loginForm = new LoginForm();
            //    if (loginForm.ShowDialog() == DialogResult.OK) {
            //        Application.Run(new MainForm());
            //    }
            //} catch (Exception ex) {
            //    MessageBox.Show(ex.Message);
            //}
        }
        static void SetConnectionString() {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            var MyConnectionString = connectionStringsSection.ConnectionStrings["EMContext"].ConnectionString;
            var StringSections = MyConnectionString.Split(';');
            MyConnectionString = "";
            foreach (string MySection in StringSections) {
                if (MySection.StartsWith("AttachDbFilename=")) {
                    MyConnectionString += "AttachDbFilename=" + Settings.DBFileName + ".mdf;";
                } else if (MySection.StartsWith(@"Data Source=(LocalDB)\")) {
                    if (String.IsNullOrEmpty(Settings.CurrentSettings.SQLInstanceName)) {
                        Settings.CurrentSettings.SQLInstanceName = "MSSQLLocalDB";
                        Settings.CurrentSettings.SaveSettings();
                    }
                    MyConnectionString += @"Data Source=(LocalDB)\" + Settings.CurrentSettings.SQLInstanceName + ";";
                } else {
                    MyConnectionString += MySection + ";";
                }
            }
            MyConnectionString = MyConnectionString.Substring(0, MyConnectionString.Length - 1);
            connectionStringsSection.ConnectionStrings["EMContext"].ConnectionString = MyConnectionString;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");

        }

       
    }
}
