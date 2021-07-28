using CyberGlobes.BL.CyberGlobesAvatarManagerCore;
using CyberGlobes.BL.CyberGlobesCore;
using CyberGlobesDM.AvatarManagerDMs;
using CyberGlobesDM.FacebookDMs;
using System;
using System.Collections.Generic;

namespace CGServices
{

    public class CGAvatarManagerService : ICGAvatarManagerService
    {
        DatabaseUtils dataUtilsBL = new DatabaseUtils();
        private AvatarManagerBL avatarManager = new AvatarManagerBL();

        string type1 = "AvatarManager1";
        //FBLevel1,INSTALevel1,ProfilerLevel1,TwitterLevel1,YouTubeLevel1
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

        public CGAvatarManagerService()
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

        public List<AvatarUserDM> GetAvatarList(string token)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return avatarManager.GetAvatarList(null, null);

            }
            return null;
        }

        public void UpdateAvatarCookie(string token, int id, string cookie)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                avatarManager.UpdateAvatarCookie(id, cookie);
            }
        }

        public void PerformLogin(string token, SearchQueryParam searchQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                avatarManager.PerformLogin(null, null);
            }
            // return null;
        }

    }
}
