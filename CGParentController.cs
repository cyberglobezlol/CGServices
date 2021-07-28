using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGServices
{
    public class CGParentController
    {
        public static readonly string systemCostantToken = "getMeInside1";
        protected void serverRemoveValues(object o)
        {

            if (o != null)
            {
                var Properties = o.GetType().GetProperties();
                foreach (var property in Properties)
                {
                    if (property.DeclaringType.Assembly.FullName.Contains("CyberGlobesDM"))
                    {
                        object[] customAttributes = property.GetCustomAttributes(typeof(CyberGlobesDM.CustomAttributes.ServerValueRemoveAttribute), true);
                        if (customAttributes != null && customAttributes.Length > 0)
                        {
                            //var SASfields = o.GetType().GetProperties();
                            //var SASfield = SASfields.FirstOrDefault(p => p.Name == property.Name);
                            //SASfield.SetValue(o, null);
                            property.SetValue(o, null);
                        }
                        var value = property.GetValue(o);
                        if (value != null && property.DeclaringType.Assembly.FullName.Contains("CyberGlobesDM"))
                        {
                            serverRemoveValues(value);

                        }
                    }
                }
            }
        }
    }
}