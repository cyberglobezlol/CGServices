using CyberGlobes.BL.CyberGlobesCore;
using CyberGlobes.BL.CyberGlobesFacebookCore;
using CyberGlobes.BL.CyberGlobesPiplCore;
using CyberGlobes.BL.CyberglobesTruecallerCore;
using CyberGlobes.BL.CyberGlobesTwitterCore;
using CyberGlobesDM.CustomAttributes;
using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.GeneralsDMs;
using CyberGlobesDM.TwitterDMs;
using CyberGlobesInfra;
using CyberGlobesInfra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using TweetSharp;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CGGeneralService : CGParentController, ICGGeneralService
    {
        DatabaseUtils dataUtilsBL = new DatabaseUtils();
        string type1 = "CGGeneral1";



        public CGGeneralService()
        {
            InitTokens();
        }

        private void InitTokens()
        {
            try
            {
                /*
                SocialUser socialUser = null;
                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("Facebook", CyberGlobesConst.Company());
                }
                else
                {
                    CGGeneralServicesDB.CGGeneralServiceClient generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
                    socialUser = generalServiceClient?.GetSocialUser("Facebook", CyberGlobesConst.Company());
                }

                if (socialUser != null)
                {
                    FacebookSettingHelper.FacebookAccessToken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                    FacebookSettingHelper.FacebookCookie = StringCipher.Decrypt(socialUser.Cookie, CyberGlobesConst.CipherPassword);
                    FacebookSettingHelper.AvatarUid = StringCipher.Decrypt(socialUser.AvatarUid, CyberGlobesConst.CipherPassword);
                }
                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("Pipl", CyberGlobesConst.Company());
                }

                if (socialUser != null)
                {
                    PiplSettingHelper.PiplAccesstoken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                }

                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("TrueCaller", CyberGlobesConst.Company());
                }

                if (socialUser != null)
                {
                    TrueCallerHelper.TrueCallerAccesstoken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                }
                */
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public string IsLoginAuthorize(string UserName, string UserPassword, string macAddress, string token)
        {
            try
            {

            if (token == "GenerateMeAToken1231")
            {
                return DatabaseUtils.Instance.IsLoginAuthorize(UserName, UserPassword, macAddress);
            }
            return null;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public SocialUser GetSocialUser(string socialType, string company, string token, int avatarId)
        {
            if (token == CyberGlobesConst.DefualtToken || dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return DatabaseUtils.Instance.GetSocialUser(socialType, company, avatarId);
            }
            return null;
        }
        public CyberglobesSysUser GetCyberglobesUser(string userName,string passWord, string token)
        {
            if (token == CyberGlobesConst.DefualtToken || dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return DatabaseUtils.Instance.GetCyberglobesUser(userName, passWord);
            }
            return null;
        }
        
        public void WriteToLog(string action, string search, string token)
        {
            if (token == CyberGlobesConst.DefualtToken || dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                string userAgent = WebOperationContext.Current.IncomingRequest.Headers["User-Agent"];
                OperationContext context = OperationContext.Current;
                MessageProperties prop = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                string ip = endpoint.Address;
                DatabaseUtils.Instance.WriteToLog(action, search, userAgent, ip);
            }
        }

        public void UpdateCookie(string cookie, int id, string token, string AccesstokenSecret)
        {
            if (CyberGlobesConst.IsLoaclSocialUserEnabled())
            {
                if (token == "getMeInside1" || dataUtilsBL.IsAuthorizeRequest(type1, token))
                {

                    DatabaseUtils.Instance.UpdateCookie(cookie, id, AccesstokenSecret);
                }
            }
            else
            {
                //TODO:pini
                CGGeneralServicesDB.CGGeneralServiceClient generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
                generalServiceClient.UpdateCookie(cookie, id, token, AccesstokenSecret);
            }
        }

        public void UpdateSkypeToken(string skypeToken, string skypeRefreshToken, string skypeAccessToken, int rowId, string token)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {

                    DatabaseUtils.Instance.UpdateSkypeToken(skypeToken,skypeRefreshToken,skypeAccessToken,rowId);
                }
                else
                {
                    //TODO:pini
                    //CGGeneralServicesDB.CGGeneralServiceClient generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
                    //generalServiceClient.UpdateSkypeToken(skypeToken, skypeRefreshToken, skypeAccessToken, rowId,token);
                }
            }
        }



        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        
        //public bool LocatorAppVerifyMAC(string hash, string nonce)
        //{
        //    string authorizedMAC = "0A002700000C"; //INSERT MAC HERE ;)
        //    string calcedHash = StringCipher.ComputeSha256Hash(authorizedMAC, nonce);

        //    return calcedHash.Equals(hash);
        //}
    }
}
