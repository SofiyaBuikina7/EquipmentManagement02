using EquipmentManagement.Forms;
using System;
using System.Collections.Generic;
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
                ColumnTranslation = Settings.Translations[typeof(T).Name];
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
                Settings.Translations.Add(typeof(T).Name, ColumnTranslation);
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
                ColumnTranslation = Settings.Translations[typeof(T).Name];
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
                Settings.Translations.Add(typeof(T).Name, ColumnTranslation);
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
                ColumnTranslation = Settings.Translations[typeof(T).Name];
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
                Settings.Translations.Add(typeof(T).Name, ColumnTranslation);
            }
            if (NeedToSave) {
                Settings.SaveTranslations();
            }
            return ColumnName;
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

    }
}
