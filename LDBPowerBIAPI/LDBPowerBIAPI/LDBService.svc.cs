using LDBPowerBIAPI.BAL;
using LDBPowerBIAPI.JsonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace LDBPowerBIAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class LDBService : ILDBService
    {
        public List<GetProgressMonitorNewForLDB> GetProgressMonitorNewData(string FromVIN, string ToVIN, string FromDate, string ToDate)
        {
            List<GetProgressMonitorNewForLDB> GetProgressMonitorNew = new List<GetProgressMonitorNewForLDB>();

            UserDetailsBAL _obj = new UserDetailsBAL();
            try
            {
                GetProgressMonitorNew = _obj.GetProgressMonitorNewData( FromVIN,  ToVIN,  FromDate,  ToDate);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToLog("GetProgressMonitorNewData" + " " + ex.Message);
            }
            return GetProgressMonitorNew;

        }

    }
}
