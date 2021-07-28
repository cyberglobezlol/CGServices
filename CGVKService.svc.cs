using CyberGlobes.BL.CyberGlobesCore;
using CyberGlobes.BL.CyberGlobesVKCore;
using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.GeneralsDMs;
using CyberGlobesDM.VKDMs;
using CyberGlobesInfra;
using CyberGlobesInfra.Utils;
using System;
using System.Collections.Generic;

namespace CGServices
{
    public class CGVKService : CGParentController, ICGVKService
    {
        VKBL vkBL = new VKBL();
        DatabaseUtils dataUtilsBL = new DatabaseUtils();
        string type1 = "VKLevel1";
        
        
     
        public CGVKService()
        {
            InitTokens();
        }
        private void InitTokens()
        {
            try
            {
                SocialUser socialUser = null;
                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("VK", CyberGlobesConst.Company(),0);
                }
                else
                {
                    CGGeneralServicesDB.CGGeneralServiceClient generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
                    socialUser = generalServiceClient?.GetSocialUser("VK", CyberGlobesConst.Company(), systemCostantToken,0);
                }

                if (socialUser != null)
                {
                    VKSettingHelper.VKAccessToken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                }


            }
            catch (Exception ex)
            {

                throw;
            }         
        }

        //public void ExportInstagramToDB(string token, List<InstaSharp.Models.Media> instagramResults)
        //{
        //    if (dataUtilsBL.IsAuthorizeRequest(type1, token))
        //    {
        //        instagramBL.ExportInstagramToDB(instagramResults, "Manual");
        //    }
        //}

        //public List<InstaSharp.Models.UserInfo> SearchInstagramUsersByName(string token, string instagramNameSearch, bool v)
        //{
        //    if (dataUtilsBL.IsAuthorizeRequest(type1, token))
        //    {
        //        return instagramBL.SearchInstagramUsersByName(instagramNameSearch, v);
        //    }
        //    return null;
        //}
        //public InstaSharp.Models.User GetInstagramProfileInfoByUserID(string token, string UserId)
        //{
        //    if (dataUtilsBL.IsAuthorizeRequest(type1, token))
        //    {
        //        return instagramBL.GetInstagramProfileInfoByUserID(UserId);
        //    }
        //    return null;
        //}
        public VKPostResponseDM GetVKposts(string token, SearchQueryParam searchQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return vkBL.GetVKposts(searchQueryParam);
            }
            return null;
        }

        public VKPostResponseDM GetVKpostsById(string token, SearchQueryParam searchQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return vkBL.GetVKpostsById(searchQueryParam);
            }
            return null;
        }

        public VKPostResponseDM GetVKMentionsById(string token, SearchQueryParam searchQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return vkBL.GetVKMentionsById(searchQueryParam);
            }
            return null;
        }

        public void ExportVKToDB(string token, List<CyberGlobesDM.VKDMs.Item> vkResults)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
               // instagramBL.ExportInstagramToDB(vkResults, "Manual");
            }
        }

        public VKAutoCompleteDM SearchForUsersByName(string token, string name)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return vkBL.SearchForUsersByName(name);
            }
            return null;
        }

        public VKUser SearchForUsersByID(string token, string id)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return vkBL.SearchForUsersByIDOrUsername(id);
            }
            return null;
        }
        
        public List<CyberGlobesDM.VKDMs.Item> GetInfoById(string token, List<CyberGlobesDM.VKDMs.Item> users, List<CyberGlobesDM.VKDMs.Item> groups)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                List<CyberGlobesDM.VKDMs.Item> merged = new List<CyberGlobesDM.VKDMs.Item>();
                merged.AddRange(vkBL.GetVKInfoByUserId(users));
                merged.AddRange(vkBL.GetVKInfoByGroupId(groups));
                return merged;
            }
            return null;
        }


        public CyberGlobesDM.VKDMs.VKFriendsDM GetVKFriendsById(string token, SearchQueryParam searchQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return vkBL.GetVKFriendsById(searchQueryParam);
            }
            return null;
        }

        public CyberGlobesDM.VKDMs.VKGroupsDM GetVKGroupsById(string token, SearchQueryParam searchQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return vkBL.GetVKGroupsById(searchQueryParam);
            }
            return null;
        }


    }
}
