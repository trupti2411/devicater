using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Reflection;


namespace Utilities
{
    public static class Common
    {
        public static string Tostring(this object objValue)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(objValue)))
                {
                    return string.Empty;
                }
                else
                {
                    return Convert.ToString(objValue).Trim();
                }
            }
            catch
            {
                return string.Empty;
            }

        }
        public static DateTime? ToDateTime(this object objValue)
        {
            DateTime returnValue;
            if (DateTime.TryParse(Convert.ToString(objValue), out returnValue))
            {
                return returnValue;
            }
            return null;
        }
        public static decimal ToDecimal(this object objValue)
        {
            decimal returnValue = 0;
            try
            {
                decimal.TryParse(Convert.ToString(objValue), out returnValue);
            }
            catch { }
            return returnValue;
        }
        public static int? ToNullableInt(this object objValue)
        {
            int returnValue = 0;
            try
            {
                if (objValue.IsNull())
                    return null;
                else if (objValue.GetType().BaseType.Name == "Enum")
                {
                    returnValue = Convert.ToInt32(objValue);
                }
                else
                {
                    int.TryParse(objValue.Tostring(), out returnValue);
                }
                return returnValue;
            }
            catch
            {
                return null;
            }
        }
        public static int ToInt(this object objValue)
        {
            int returnValue = 0;
            try
            {
                if (objValue.IsNull())
                    return 0;
                else if (objValue.GetType().BaseType.Name == "Enum")
                {
                    returnValue = Convert.ToInt32(objValue);
                }
                else
                {
                    int.TryParse(objValue.Tostring(), out returnValue);
                }
                return returnValue;
            }
            catch
            {
                return 0;
            }
        }
        public static bool ToBoolean(this object objvalue)
        {
            try
            {
                if (objvalue.IsNull())
                    return false;
                else if (objvalue.Tostring() == "1" || objvalue.Tostring().ToLower() == "true")
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsNull(this object ObjValue)
        {
            if (ObjValue == null || ObjValue == DBNull.Value)
                return true;
            else
                return false;
        }
        public static string hascode(string str)
        {
            string rethash = "";
            try
            {

                System.Security.Cryptography.SHA1 hash = System.Security.Cryptography.SHA1.Create();
                System.Text.ASCIIEncoding encoder = new System.Text.ASCIIEncoding();
                byte[] combined = encoder.GetBytes(str);
                hash.ComputeHash(combined);
                rethash = Convert.ToBase64String(hash.Hash);
            }
            catch (Exception ex)
            {
                string strerr = "Error in HashCode : " + ex.Message;
            }
            return rethash;

        }

        public static void Fill(object LogicObject, System.Data.DataRow Row)
        {
            Dictionary<string, PropertyInfo> props = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo p in LogicObject.GetType().GetProperties())
                props.Add(p.Name, p);
            foreach (System.Data.DataColumn col in Row.Table.Columns)
            {
                string name = col.ColumnName;
                if (Row[name] != DBNull.Value && props.ContainsKey(name))
                {
                    object item = Row[name];
                    PropertyInfo p = props[name];
                    if (p.PropertyType != col.DataType)
                        item = Convert.ChangeType(item, p.PropertyType);
                    p.SetValue(LogicObject, item, null);
                }
            }
        }
    }

    


    public class Converter
    {
        public static void Fill(object LogicObject, System.Data.DataRow Row)
        {
            Dictionary<string, PropertyInfo> props = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo p in LogicObject.GetType().GetProperties())
                props.Add(p.Name, p);
            foreach (System.Data.DataColumn col in Row.Table.Columns)
            {
                string name = col.ColumnName;
                if (Row[name] != DBNull.Value && props.ContainsKey(name))
                {
                    object item = Row[name];
                    PropertyInfo p = props[name];
                    if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {

                        if (p.PropertyType != col.DataType)
                            item = Convert.ChangeType(item, p.PropertyType.GetGenericArguments()[0]);
                    }
                    else
                    {
                        if (p.PropertyType != col.DataType)
                            item = Convert.ChangeType(item, p.PropertyType);
                    }
                    p.SetValue(LogicObject, item, null);
                }
            }
        }

        public static void Fill(object LogicObject, System.Data.SqlClient.SqlDataReader SqlDataReader)
        {
            Dictionary<string, PropertyInfo> props = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo p in LogicObject.GetType().GetProperties())
                props.Add(p.Name, p);
            //foreach (System.Data.DataColumn col in Row.Table.Columns)

            for (int i = 0; i < SqlDataReader.FieldCount; i++)
            {
                string name = SqlDataReader.GetName(i);
                if (SqlDataReader[name] != DBNull.Value && props.ContainsKey(name))
                {
                    object item = SqlDataReader[name];
                    PropertyInfo p = props[name];
                    if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        if (p.PropertyType != SqlDataReader.GetFieldType(i))
                            item = Convert.ChangeType(item, p.PropertyType.GetGenericArguments()[0]);

                    }
                    else
                    {
                        if (p.PropertyType != SqlDataReader.GetFieldType(i))
                            item = Convert.ChangeType(item, p.PropertyType);
                    }

                    p.SetValue(LogicObject, item, null);
                }

            }
        }




        
    }

    public class LolacFunction
    {
        public static DateTime? ToDate(string date)
        {
            if (date != "")
            {
                try
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("gu-IN", true);

                    DateTime dtime = DateTime.Parse(date, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    return Convert.ToDateTime(dtime);
                }
                catch (Exception)
                {

                    return null;
                }

            }
            else
            {
                return null;
            }


        }
        public static string ToDateString(string datetime)
        {
            if (datetime == null || datetime == "" || datetime == string.Empty)
            {
                return "";
            }
            else
            {
                return Convert.ToDateTime(datetime).ToString("dd/MM/yyyy");
            }

        }
    }

}

