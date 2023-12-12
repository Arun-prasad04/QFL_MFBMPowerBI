using HDBPowerBIAPI.JsonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HDBPowerBIAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IHDBService
    {

        [OperationContract(Name = "GetProgressMonitorNewData")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/GetProgressMonitorNewData?FromVIN={FromVIN}&ToVIN={ToVIN}&FromDate={FromDate}&ToDate={ToDate}")]
        List<GetProgressMonitorNewForHDB> GetProgressMonitorNewData(string FromVIN, string ToVIN, string FromDate, string ToDate);

        // TODO: Add your service operations here
    }


}
