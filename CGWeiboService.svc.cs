using CyberGlobes.BL.CyberGlobesCore;
using CyberGlobes.BL.CyberglobesWeiboCore;
using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.WeiboDMs;
using System;
using System.Collections.Generic;

namespace CGServices
{

    public class CGWeiboService : CGParentController, ICGWeiboService
    {
        private WeiboApis weiboApis = new WeiboApis();
        DatabaseUtils dataUtilsBL = new DatabaseUtils();
        string type1 = "WeiboLevel1";
        //FBLevel1,INSTALevel1,ProfilerLevel1,TwitterLevel1,YouTubeLevel1
       

        public CGWeiboService()
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


        public IEnumerable<Blog> SearchBlogs(string token, SearchQueryParam weiboQueryParams)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return weiboApis.SearchBlogs(weiboQueryParams);
            }
            return null;
        }
    }
}
