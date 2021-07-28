using CyberGlobes.BL.CyberGlobesCore;
using CyberGlobes.BL.CyberGlobesFacebookCore;
using CyberGlobes.BL.CyberGlobesPiplCore;
using CyberGlobes.BL.CyberglobesTruecallerCore;
using CyberGlobes.BL.CyberGlobesYoutubeCore;
using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.GeneralsDMs;
using CyberGlobesInfra;
using CyberGlobesInfra.Utils;
using Google.Apis.YouTube.v3.Data;
using System;

namespace CGServices
{

    public class CGYoutubeService : CGParentController, ICGYoutubeService
    {
        private YoutubeBL youTubeBL = new YoutubeBL();
        DatabaseUtils dataUtilsBL = new DatabaseUtils();
        string type1 = "YouTubeLevel1";
        //FBLevel1,INSTALevel1,ProfilerLevel1,TwitterLevel1,YouTubeLevel1
       

        public CGYoutubeService()
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

        public SearchListResponse YouTubeListRequest(string token, SearchQueryParam searchQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return youTubeBL.YouTubeListRequest(searchQueryParam);
            }
            return null;
        }

    }
}
