using CyberGlobes.BL.CyberGlobesCore;
using CyberGlobes.BL.CyberGlobesFacebookCore;
using CyberGlobes.BL.CyberGlobesInstagramCore;
using CyberGlobes.BL.CyberGlobesPiplCore;
using CyberGlobes.BL.CyberglobesTruecallerCore;
using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.GeneralsDMs;
using CyberGlobesInfra;
using CyberGlobesInfra.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CGServices
{
    public class CGInstagramService : CGParentController, ICGInstagramService
    {
        private CGGeneralServicesDB.CGGeneralServiceClient generalServiceClient;

        InstagramBL instagramBL = new InstagramBL();
        DatabaseUtils dataUtilsBL = new DatabaseUtils();
        string type1 = "INSTALevel1";
        
       
     
        public CGInstagramService()
        {
            generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
            InitTokens();
        }
        private void InitTokens()
        {
            try
            {
                SocialUser socialUser = null;
                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("Instagram", CyberGlobesConst.Company(),0);
                }
                else
                {
                    CGGeneralServicesDB.CGGeneralServiceClient generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
                    socialUser =  generalServiceClient?.GetSocialUser("Instagram", CyberGlobesConst.Company(), systemCostantToken,0);
                }

                if (socialUser != null)
                {
                    InstagramSettingHelper.InstagramAccessToken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                    InstagramSettingHelper.InstagramCookie = StringCipher.Decrypt(socialUser.Cookie, CyberGlobesConst.CipherPassword);
                    InstagramSettingHelper.AvatarIdDB = socialUser.Id;

                }


            }
            catch (Exception ex)
            {

                throw;
            }
            try
            {

                SocialUser socialUser = null;
                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("Facebook", CyberGlobesConst.Company(),0);
                    if (socialUser != null)
                    {
                        FacebookSettingHelper.FacebookAccessToken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                        FacebookSettingHelper.FacebookCookie = StringCipher.Decrypt(socialUser.Cookie, CyberGlobesConst.CipherPassword);
                        FacebookSettingHelper.AvatarUid = StringCipher.Decrypt(socialUser.AvatarUid, CyberGlobesConst.CipherPassword);
                        FacebookSettingHelper.AvatarCompany = socialUser.Company;
                        FacebookSettingHelper.AvatarIdDB = socialUser.Id;

                    }
                }
                else
                {
                    CGGeneralServicesDB.CGGeneralServiceClient generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
                    socialUser = generalServiceClient?.GetSocialUser("Facebook", CyberGlobesConst.Company(), systemCostantToken,0);
                }

                

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void ExportInstagramToDB(string token, List<InstaSharp.Models.Media> instagramResults)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                instagramBL.ExportInstagramToDB(instagramResults, "Manual");
            }
        }

        public List<InstaSharp.Models.UserInfo> SearchInstagramUsersByName(string token, string instagramNameSearch, bool v)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return instagramBL.SearchInstagramUsersByName(instagramNameSearch, v);
            }
            return null;
        }
        public InstaSharp.Models.User GetInstagramProfileInfoByUserID(string token, string UserId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return instagramBL.GetUserExtended(UserId);
                //return instagramBL.GetInstagramProfileInfoByUserID(UserId);
            }
            return null;
        }
               
        public InstaSharp.Models.UserInfo GetInstagramUserInfo(string token, string UserId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return instagramBL.GetInstagramUserInfo(UserId);
                
            }
            return null;
        }

        public InstaSharp.Models.Responses.MediasResponse GetInstagramPost(string token, SearchQueryParam searchQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InstaSharp.Models.Responses.MediasResponse result = instagramBL.GetInstagramPost(searchQueryParam);
                if (!CyberGlobesConst.IsLoaclSocialUserEnabled() && !string.IsNullOrEmpty(result.Cookie))
                {
                    generalServiceClient.UpdateCookie(result.Cookie, result.RowId, "getMeInside1", null);
                }
                else
                {

                }
                return result;
            }
            return null;
        }

        public InstaSharp.Models.Responses.MediasResponse GetInstagramPostByUser(string token, SearchQueryParam searchQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return instagramBL.GetInstagramPostByUser(searchQueryParam);
            }
            return null;
        }


        public List<InstaSharp.Models.UserInfo> GetFollowers(string token, string id)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return instagramBL.FetchFriendship(id, "followers");
            }
            return null;
        }
        public List<InstaSharp.Models.UserInfo> GetFollowings(string token, string id)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return instagramBL.FetchFriendship(id, "following");
            }
            return null;
        }
    }
}
