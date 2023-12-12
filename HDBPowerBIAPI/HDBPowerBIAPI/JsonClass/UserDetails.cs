using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HDBPowerBIAPI.JsonClass
{
    [Serializable]
    [DataContract]
    public class GetProgressMonitorNewForHDB
    {
        [DataMember]
        public string PartName { get; set; }
     
        

        [DataMember]
        public string VIN { get; set; }

        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string VehicleType { get; set; }

     
        


        [DataMember]
        public string 責任部門 { get; set; }
        [DataMember]
        public string 修正部門 { get; set; }
        [DataMember]
        public string 修正予定日 { get; set; }
        [DataMember]
        public string 完成予定日 { get; set; }
        [DataMember]
        public string 緊急 { get; set; }

        [DataMember]
        public string 備考 { get; set; }
        [DataMember]
        public string Qgate { get; set; }
        [DataMember]
        public string 完成日 { get; set; }
        [DataMember]
        public string Defect { get; set; }
        [DataMember]
        public string Status { get; set; }

    }

    [Serializable]
    [DataContract]
    public class ProgressMonitor
    {
        [DataMember]
        public int plantid { get; set; }
        [DataMember]
        public string vinfrom { get; set; }
        [DataMember]
        public string vinto { get; set; }
        [DataMember]
        public string fromdate { get; set; }
        [DataMember]
        public string todate { get; set; }
        [DataMember]
        public string VINNumber { get; set; }


        [DataMember]
        public int fromcount { get; set; }

        [DataMember]
        public int tocount { get; set; }

        [DataMember]
        public int Lineid { get; set; }

        [DataMember]
        public string ModelName { get; set; }
    }

}





