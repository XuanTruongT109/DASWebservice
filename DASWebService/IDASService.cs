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
        [OperationContract]
        List<CreditNote> GetCNsbyList(string token);
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
    [DataContract]
    public class CreditNote
    {
        string _INTERFACETYPE = string.Empty;
        string _SALESORG = string.Empty;
        string _SOLDTOPARTY = string.Empty;
        string _SHIPTOPARTY = string.Empty;
        string _ORDERREASON = string.Empty;
        string _ORDERDATE = string.Empty;
        string _REQUESTDELIVERYDATE = string.Empty;
        string _CUSTOMERDOCUMENT = string.Empty;
        string _MATERIALNUMBER = string.Empty;
        string _ORDERQUANTITY = string.Empty;
        string _SALESUNIT = string.Empty;
        string _CONDITIONTYPE = string.Empty;
        string _AMOUNT = string.Empty;
        string _IONUMBER = string.Empty;
        string _GUI = string.Empty;

        [DataMember]
        public string INTERFACETYPE
        {
            get { return _INTERFACETYPE; }
            set { _INTERFACETYPE = value; }
        }
        [DataMember]
        public string SALESORGE
        {
            get { return _SALESORG; }
            set { _SALESORG = value; }
        }
        [DataMember]
        public string SOLDTOPARTY
        {
            get { return _SOLDTOPARTY; }
            set { _SOLDTOPARTY = value; }
        }
        [DataMember]
        public string SHIPTOPARTY
        {
            get { return _SHIPTOPARTY; }
            set { _SHIPTOPARTY = value; }
        }
        [DataMember]
        public string ORDERREASON
        {
            get { return _ORDERREASON; }
            set { _ORDERREASON = value; }
        }
        [DataMember]
        public string ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        [DataMember]
        public string REQUESTDELIVERYDATE
        {
            get { return _REQUESTDELIVERYDATE; }
            set { _REQUESTDELIVERYDATE = value; }
        }
        [DataMember]
        public string CUSTOMERDOCUMENT
        {
            get { return _CUSTOMERDOCUMENT; }
            set { _CUSTOMERDOCUMENT = value; }
        }
        [DataMember]
        public string MATERIALNUMBER
        {
            get { return _MATERIALNUMBER; }
            set { _MATERIALNUMBER = value; }
        }
        [DataMember]
        public string ORDERQUANTITY
        {
            get { return _ORDERQUANTITY; }
            set { _ORDERQUANTITY = value; }
        }
        [DataMember]
        public string SALESUNIT
        {
            get { return _SALESUNIT; }
            set { _SALESUNIT = value; }
        }
        [DataMember]
        public string CONDITIONTYPE
        {
            get { return _CONDITIONTYPE; }
            set { _CONDITIONTYPE = value; }
        }
        [DataMember]
        public string AMOUNT
        {
            get { return _AMOUNT; }
            set { _AMOUNT = value; }
        }
        [DataMember]
        public string IONUMBER
        {
            get { return _IONUMBER; }
            set { _IONUMBER = value; }
        }
        [DataMember]
        public string GUI
        {
            get { return _GUI; }
            set { _GUI = value; }
        }
    }
}
