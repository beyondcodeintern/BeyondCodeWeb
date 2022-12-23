using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace BeyondCode.Helper.Mapper
{
    public class FormCollectionMapper
    {
        public static T FormToModel<T>(FormCollection formCollection)
        {
            var model = Activator.CreateInstance(typeof(T));
            Type modelType = model.GetType();

            foreach (PropertyInfo prop in modelType.GetProperties())
            {
                var mykey = prop.Name;
                if (prop.CanRead && formCollection.AllKeys.Contains(mykey))
                {
                    try
                    {
                        var value = formCollection[mykey];
                        var propType = prop.PropertyType;
                        if (propType == typeof(int) ||
                            propType == typeof(int?) ||
                           propType == typeof(Int64) ||
                          propType == typeof(Int32)  )
                        {
                            prop.SetValue(model, int.Parse(value));
                        }  
                        else if  (propType == typeof(decimal))
                        {
                            prop.SetValue(model, decimal.Parse(value));
                        }
                        else if (propType == typeof(DateTime)||
                             propType == typeof(DateTime?))
                        {
                            prop.SetValue(model, DateTime.Parse(value));
                        }
                        else if (propType == typeof(bool))
                        {
                            prop.SetValue(model, bool.Parse(value));
                        }
                        else
                        {
                            prop.SetValue(model, value);
                        }

                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }

            return (T)model;
        }



    }
}