using CyberGlobes.BL.CyberGlobesCore;
using CyberGlobes.BL.CyberGlobesGoogleCore;
using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.GeneralsDMs;
using CyberGlobesDM.GoogleDMs;
using CyberGlobesInfra;
using CyberGlobesInfra.Utils;
using System;
using System.Collections.Generic;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CGGoogleService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CGGoogleService.svc or CGGoogleService.svc.cs at the Solution Explorer and start debugging.
    public class CGGoogleService : CGParentController , ICGGoogleService
    {

        GoogleCustomSearchBL GoogleBL = new GoogleCustomSearchBL();
        DatabaseUtils dataUtilsBL = new DatabaseUtils();
        //string type1 = "GoogleLevel1";
        //TODO: pini
        string type1 = "ProfilerLevel1";
        
        static CGGoogleService()
        {
            InitTokens();
        }

        private static void InitTokens()
        {
            try
            {
                SocialUser socialUser = null;
                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("GoogleSerp", CyberGlobesConst.Company(), 0);
                }
                else
                {
                    CGGeneralServicesDB.CGGeneralServiceClient generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
                    socialUser = generalServiceClient?.GetSocialUser("GoogleSerp", CyberGlobesConst.Company(), systemCostantToken, 0);
                }

                if (socialUser != null)
                {
                    GoogleSerpSettingHelper.GoogleSerpAccessToken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                }


            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public GoogleSearchDM GetGoogleSearchByQuery(string token, SearchQueryParam searchQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return GoogleBL.GetGoogleSearchByQuery(searchQueryParam);
            }
            return null;
        }

        public GoogleResultSerpDM GetGoogleSearchDataSerpByQuery(string token, SearchQueryParam searchQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return GoogleBL.GoogleSearchDataSerpWow(searchQueryParam);
            }
            return null;
        }

        public GoogleResultSerpDM GetGoogleSearchImagesSerpByQuery(string token, SearchQueryParam searchQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return GoogleBL.GoogleSearchImagesSerpWow(searchQueryParam);
            }
            return null;
        }

        public GoogleSerpNewsResultDM GetGoogleSearchNewsSerpByQuery(string token, SearchQueryParam searchQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return GoogleBL.GoogleSearchNewsSerpWow(searchQueryParam);
            }
            return null;
        }
    }
}
