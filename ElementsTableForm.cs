using EquipmentManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentManagement
{
    public partial class ElementsTableForm: Form
    {
        public ElementsTableForm(object list)
        {
            InitializeComponent();
            MainListDGV.DataSource = list;
        }

        //public static object GetPropertyValue(object source, string propertyName)
        //{
        //    PropertyInfo property = source.GetType().GetProperty(propertyName);
        //    return property.GetValue(source, null);
        //}

        //public static IQueryable Set(this DbContext context, Type T)
        //{
        //    // Get the generic type definition
        //    MethodInfo method = typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);

        //    // Build a method with the specific type argument you're interested in
        //    method = method.MakeGenericMethod(T);

        //    return method.Invoke(context, null) as IQueryable;
        //}

        //public static IQueryable<T> Set<T>(DbContext context)
        //{
        //    // Get the generic type definition 
        //    MethodInfo method = typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);

        //    // Build a method with the specific type argument you're interested in 
        //    method = method.MakeGenericMethod(typeof(T));

        //    return method.Invoke(context, null) as IQueryable<T>;
        //}
    }
}
