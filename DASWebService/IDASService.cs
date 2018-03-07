using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DASWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDASService" in both code and config file together.
    [ServiceContract]
    public interface IDASService
    {
        [OperationContract]
        string InsertCus(Customer infoCus);
        [OperationContract]
        string InsertProHier(ProHier proHier);
        [OperationContract]
        DataSet GetCNtoSAP(string token);
    }
    [DataContract]
    public class Customer
    {
        string shiptoname = string.Empty;
        string cust_stat = string.Empty;
        string salesorg = string.Empty;
        string custno = string.Empty;
        string status = string.Empty;
        string token = string.Empty;

        [DataMember]
        public string ShiptoName
        {
            get { return shiptoname; }
            set { shiptoname = value; }
        }

        [DataMember]
        public string Cust_Stat
        {
            get { return cust_stat; }
            set { cust_stat = value; }
        }
        [DataMember]
        public string SalesOrg
        {
            get { return salesorg; }
            set { salesorg = value; }
        }
        [DataMember]
        public string CustNo
        {
            get { return custno; }
            set { custno = value; }
        }
        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        [DataMember]
        public string Token
        {
            get { return token; }
            set { token = value; }
        }
    }
    public class ProHier
    {
        string brandcode = string.Empty;
        string brandname = string.Empty;
        string subbrandcode = string.Empty;
        string subbrandname = string.Empty;
        string proID = string.Empty;
        string companyId = string.Empty;
        string status = string.Empty;
        string token = string.Empty;

        [DataMember]
        public string BrandCode
        {
            get { return brandcode; }
            set { brandcode = value; }
        }
        [DataMember]
        public string BrandName
        {
            get { return brandname; }
            set { brandname = value; }
        }
        [DataMember]
        public string SubBrandCode
        {
            get { return subbrandcode; }
            set { subbrandcode = value; }
        }
        [DataMember]
        public string SubbrandName
        {
            get { return subbrandname; }
            set { subbrandname = value; }
        }
        [DataMember]
        public string ProductID
        {
            get { return proID; }
            set { proID = value; }
        }
        [DataMember]
        public string CompanyID
        {
            get { return companyId; }
            set { companyId = value; }
        }
        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        [DataMember]
        public string Token
        {
            get { return token; }
            set { token = value; }
        }

    }
}
