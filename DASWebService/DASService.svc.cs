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
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        public string token = "7FEBE4AD-9B44-406B-A756-F553E7F212AE";
        public string InsertCus(Customer infoCus)
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
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
                        if (result == 1)
                        {
                            return "Insert sucess to table CUSTMSTTABLE";
                        }
                        else
                        {
                            return "Fail to insert table CUSTMSTTABLE";
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }else
            {
                return "Provide wrong token";
            }
            
        }
        public string InsertProHier(ProHier proHier)
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
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
                        if (result == 1)
                        {
                            return "Insert sucess to table PRODHIERTABLE";
                        }
                        else
                        {
                            return "Fail to insert table PRODHIERTABLE";
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return "Provide wrong token";
            }
        }
        public DataSet GetCNtoSAP(string SAPToken)
        {
            if(SAPToken == token)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spr_GetDataSAPPI", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        cmd.ExecuteNonQuery();
                        return ds;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
