using CyberGlobes.BL.CyberGlobesCore;
using CyberGlobes.BL.CyberGlobesWhatsappCore;
using CyberGlobesDM.GeneralsDMs;
using CyberGlobesDM.WhatsAppDMs;
using CyberGlobesInfra;
using CyberGlobesInfra.Utils;
using System.ServiceModel;
using System;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CGWhatsappService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CGWhatsappService.svc or CGWhatsappService.svc.cs at the Solution Explorer and start debugging.
    public class CGWhatsappService : ICGWhatsappService
    {
        static EmulatorsManager emulatorManager = null;
        DatabaseUtils dataUtilsBL = new DatabaseUtils();

        public WhatsAppPersonDM GetWhatsappUser(string token, ProfilerQueryParam profilerQueryParam)
        {
            WhatsAppPersonDM whatsAppPersonDM = new WhatsAppPersonDM();
            WhatsappBL whatsappBL = new WhatsappBL();

            if (emulatorManager == null)
            {
                emulatorManager = new EmulatorsManager();
            }
            if (!string.IsNullOrEmpty(profilerQueryParam.PhoneNumber) && ValidateUtils.IsValidPhone(profilerQueryParam.PhoneNumber))
            {
                if (CyberGlobesConst.IsWhatsappEnabled())
                {
                        whatsAppPersonDM = whatsappBL.GetWhatsappPersonDM(emulatorManager, profilerQueryParam.PhoneNumber);
                }
            }
            return whatsAppPersonDM;
        }
    }
}
