using CyberGlobes.BL.CyberGlobesAnalyticsCore;
using CyberGlobes.BL.CyberGlobesCore;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CGServices
{

    public class CGAnalyticsService : ICGAnalyticsService
    {
        DatabaseUtils dataUtilsBL = new DatabaseUtils();
        
        private TextSemanticsBL semanticsAnalytics = new TextSemanticsBL();

        string type1 = "Analytics1";

        private void serverRemoveValues(object o)
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

        public CGAnalyticsService()
        {
            InitTokens();
        }

        private void InitTokens()
        {
            try
            {
                
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public Dictionary<string, List<string>> GetTextNER(string token,string text)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return NERAnalyticsBL.GetTextNER(text);

            }
            return null;
        }

        public MatchCollection GetTextEmails(string token, string text)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return NERAnalyticsBL.GetTextEmails(text);

            }
            return null;
        }

        public List<string> GetTextPhoneNumbers(string token, string text)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                //return nerAnalytics.GetTextPhoneNumbers(text);

            }
            return null;
        }

    }
}
