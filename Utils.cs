using EquipmentManagement.Forms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentManagement {
    public static class Utils {
        public static void TranslateColumnHeaders<T>(ref DataGridView MyDataGridView) {
            bool NeedToSave = false;
            bool NeedToAddTable = false;
            Dictionary<string, string> ColumnTranslation;
            if (Settings.Translations.Keys.Contains(typeof(T).Name)) {
                ColumnTranslation = Settings.Translations[typeof(T).Name].MyProperies;
            } else {
                ColumnTranslation = new Dictionary<string, string>();
                NeedToAddTable = true;
                NeedToSave = true;
            }

            foreach (DataGridViewColumn MyColumn in MyDataGridView.Columns) {
                if (ColumnTranslation.Keys.Contains(MyColumn.Name)) {
                    MyColumn.HeaderText = ColumnTranslation[MyColumn.Name];
                } else {
                    ColumnTranslation.Add(MyColumn.Name, MyColumn.Name);
                    NeedToSave = true;
                }
            }
            if (NeedToAddTable) {
                Settings.Translations.Add(typeof(T).Name, new MyDictionary { Name = typeof(T).Name, MyProperies = ColumnTranslation });
            }
            if (NeedToSave) {
                Settings.SaveTranslations();
            }
        }

        public static void TranslateColumnHeaders<T>(ref MyDGV MyDataGridView) {
            bool NeedToSave = false;
            bool NeedToAddTable = false;
            Dictionary<string, string> ColumnTranslation;
            if (Settings.Translations.Keys.Contains(typeof(T).Name)) {
                ColumnTranslation = Settings.Translations[typeof(T).Name].MyProperies;
            } else {
                ColumnTranslation = new Dictionary<string, string>();
                NeedToAddTable = true;
                NeedToSave = true;
            }

            foreach (DataGridViewColumn MyColumn in MyDataGridView.Columns) {
                if (ColumnTranslation.Keys.Contains(MyColumn.Name)) {
                    MyColumn.HeaderText = ColumnTranslation[MyColumn.Name];
                } else {
                    ColumnTranslation.Add(MyColumn.Name, MyColumn.Name);
                    NeedToSave = true;
                }
            }
            if (NeedToAddTable) {
                Settings.Translations.Add(typeof(T).Name, new MyDictionary { Name = typeof(T).Name, MyProperies = ColumnTranslation });
            }
            if (NeedToSave) {
                Settings.SaveTranslations();
            }
        }

        public static string GetColumnTranslation<T>(string ColumnName) {
            bool NeedToSave = false;
            bool NeedToAddTable = false;
            Dictionary<string, string> ColumnTranslation;
            if (Settings.Translations.Keys.Contains(typeof(T).Name)) {
                ColumnTranslation = Settings.Translations[typeof(T).Name].MyProperies;
            } else {
                ColumnTranslation = new Dictionary<string, string>();
                NeedToAddTable = true;
                NeedToSave = true;
            }
            if (ColumnTranslation.Keys.Contains(ColumnName)) {
                return ColumnTranslation[ColumnName];
            } else {
                ColumnTranslation.Add(ColumnName, ColumnName);
                NeedToSave = true;
            }

            if (NeedToAddTable) {
                Settings.Translations.Add(typeof(T).Name, new MyDictionary { Name = typeof(T).Name, MyProperies = ColumnTranslation });
            }
            if (NeedToSave) {
                Settings.SaveTranslations();
            }
            return ColumnName;
        }

        public static string GetTableNameTranslation<T>() {
            bool NeedToSave = false;
            bool NeedToAddTable = false;
            string TableName;
            if (Settings.Translations.Keys.Contains(typeof(T).Name)) {
                TableName = Settings.Translations[typeof(T).Name].Name;
            } else {
                TableName = typeof(T).Name + "s";
            }

            return TableName;
        }


        public static void ChangeColunmEnumToListBox<T>(ref MyDGV MyDataGridView, string ColumnName) {
            var MyColumn = new DataGridViewComboBoxColumn();
            MyColumn.Name = MyDataGridView.Columns[ColumnName].Name;
            MyColumn.DataPropertyName = MyDataGridView.Columns[ColumnName].DataPropertyName;

            foreach (T p in Enum.GetValues(typeof(T)).Cast<T>()) {
                MyColumn.Items.Add(p);
            }
            int Index = MyDataGridView.Columns[ColumnName].Index;
            MyDataGridView.Columns.Remove(MyDataGridView.Columns[ColumnName]);
            MyDataGridView.Columns.Insert(Index, MyColumn);
        }

        public static void ChangeColunmEntityToListBox<T>(ref MyDGV MyDataGridView, string ColumnName, List<T> MyEntities) {
            var MyColumn = new DataGridViewComboBoxColumn();
            MyColumn.Name = MyDataGridView.Columns[ColumnName].Name;
            MyColumn.DataPropertyName = MyDataGridView.Columns[ColumnName].DataPropertyName;
            MyColumn.DataSource = MyEntities;
            MyColumn.ValueType = typeof(T);
        
            int Index = MyDataGridView.Columns[ColumnName].Index;
            MyDataGridView.Columns.Remove(MyDataGridView.Columns[ColumnName]);
            MyDataGridView.Columns.Insert(Index, MyColumn);
        }

        public static IQueryable<T> LoadRelated<T>(this IQueryable<T> originalQuery) {
            Func<IQueryable<T>, IQueryable<T>> includeFunc = f => f;
            foreach (var prop in typeof(T).GetProperties().Where(p => Attribute.IsDefined(p, typeof(IncludeAttribute)))) {
                Func<IQueryable<T>, IQueryable<T>> chainedIncludeFunc = f => f.Include(prop.Name);
                includeFunc = Compose(includeFunc, chainedIncludeFunc);
            }
            return includeFunc(originalQuery);
        }

        private static Func<T, T> Compose<T>(Func<T, T> innerFunc, Func<T, T> outerFunc) {
            return arg => outerFunc(innerFunc(arg));
        }


        public static string CreateMD5(string input) {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create()) {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string prior to .NET 5
                StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++) {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
