using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DASWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DASService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DASService.svc or DASService.svc.cs at the Solution Explorer and start debugging.
    public class DASService : IDASService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        string token = ConfigurationManager.AppSettings["Token"].ToString();
        public string InsertCus(Customer infoCus)
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    log.Error("Cannot open database due to error", ex);
                }
            }
            if(infoCus.Token == token)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spr_INSERT_CUSTMSTTABLE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ShiptoName", SqlDbType.VarChar).Value = infoCus.ShiptoName;
                        cmd.Parameters.Add("@Cust_Stat", SqlDbType.VarChar).Value = infoCus.Cust_Stat;
                        cmd.Parameters.Add("@SalesOrg", SqlDbType.VarChar).Value = infoCus.SalesOrg;
                        cmd.Parameters.Add("@CustNo", SqlDbType.VarChar).Value = infoCus.CustNo;
                        cmd.Parameters.Add("@Status", SqlDbType.Decimal).Value = infoCus.Status;
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result == 1)
                        {
                            log.Info(infoCus.ShiptoName.ToString() + " - Insert to CUSTMSTTABLE success");
                            return "Insert success to table CUSTMSTTABLE";
                        }
                        else
                        {
                            return "Fail to insert table CUSTMSTTABLE";
                        }
                    }
                }
                catch (Exception ex)
                {
                    //throw ex;
                    log.Error(infoCus.ShiptoName.ToString() + " - Fail to insert - ",ex);
                    return "Fail to insert table CUSTMSTTABLE";
                }
            }else
            {
                log.Warn(infoCus.ShiptoName.ToString() + " - Provide wrong token");
                return "Provide wrong token";
            }
            
        }
        public string InsertProHier(ProHier proHier)
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    log.Error("Cannot open database due to error", ex);
                }
            }
            if (proHier.Token == token)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spr_INSERT_PRODHIERTABLE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@BrandCode", SqlDbType.VarChar).Value = proHier.BrandCode;
                        cmd.Parameters.Add("@BrandName", SqlDbType.VarChar).Value = proHier.BrandName;
                        cmd.Parameters.Add("@SubBrandCode", SqlDbType.VarChar).Value = proHier.SubBrandCode;
                        cmd.Parameters.Add("@SubbrandName", SqlDbType.VarChar).Value = proHier.SubbrandName;
                        cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = proHier.ProductID;
                        cmd.Parameters.Add("@CompanyID", SqlDbType.VarChar).Value = proHier.CompanyID;
                        cmd.Parameters.Add("@Status", SqlDbType.Decimal).Value = proHier.Status;
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result == 1)
                        {
                            log.Info(proHier.BrandCode.ToString() + " - Insert to PRODHIERTABLE success");
                            return "Insert success to table PRODHIERTABLE";
                        }
                        else
                        {
                            return "Fail to insert table PRODHIERTABLE";
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error(proHier.BrandCode.ToString() + " - Fail to insert due to - ", ex);
                    return "Fail to insert table PRODHIERTABLE";
                }
            }
            else
            {
                log.Warn(proHier.BrandCode.ToString() + " - Provide wrong token");
                return "Provide wrong token";
            }
        }
        public DataSet GetCNtoSAP(string SAPToken)
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    log.Error("Cannot open database due to error", ex);
                }
            }
            if (SAPToken == token)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spr_GetDataSAPPI", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 300;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        if(ds.Tables[0].Rows.Count > 1)
                        {
                            log.Info("Successful get Credit Notes for SAP: Total record "+ ds.Tables[0].Rows.Count);
                        }
                        if(ds.Tables[0].Rows.Count  == 0)
                        {
                            log.Info("Get Credit Note: No record");
                        }
                        return ds;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Fail to get data - ", ex);
                    return null;
                }
            }
            else
            {
                log.Warn("GetCNtoSAP - Provide wrong token");
                return null;
            }
        }
        public List<CreditNote> GetCNsbyList(string token)
        {
            List<CreditNote> CNs = new List<CreditNote>();

            return CNs;
        }
    }
}
