using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALICWService
{
    public class Admin
    {
        private string ConnectionString = "";
        private SqlCommand SqlCmd;
        public Admin(string iConnectionString)
        {
            try
            {
                ConnectionString = iConnectionString;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public Admin(string iConnectionString, ref SqlCommand iSqlCmd) //overloaded- includes the sqlCmd by reference. (for transactionalising)
        {
            try
            {
                ConnectionString = iConnectionString;
                SqlCmd = iSqlCmd;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable LoadDownloadProcesses(bool isTesting)
        {
            if (!isTesting)
            {
                SqlConnection myConn = new SqlConnection(ConnectionString);
                SqlCommand myCmd = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataTable myResults = new DataTable();
                try
                {
                    myConn.Open();
                    myCmd = new SqlCommand();
                    myCmd.Connection = myConn;
                    myCmd.CommandText = "SELECT * " +
                                        "FROM dbo.FTPProcesses ";
                    //+ "WHERE Status ='1' ";
                    myDA.SelectCommand = myCmd;
                    myDA.Fill(myResults);
                    return myResults;

                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
                finally
                {
                    myConn.Close();
                }
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("RAM");
                dt.Columns.Add("PharmacyName");
                dt.Columns.Add("HostIP");
                dt.Columns.Add("Login");
                dt.Columns.Add("Password");
                dt.Columns.Add("RemoteDir");
                dt.Columns.Add("LocalDir");
                dt.Columns.Add("Account");

                for (int i = 0; i < 10; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = i + 1;
                    dr["RAM"] = "RAM " + (i + 1);
                    dr["PharmacyName"] = "Pharmacy " + (i + 1);
                    dr["HostIP"] = " HostIP " + (i + 1);
                    dr["Login"] = "Login " + (i + 1);
                    dr["Password"] = "Password " + (i + 1);
                    dr["RemoteDir"] = "Remote Dir " + (i + 1);
                    dr["LocalDir"] = "localdir-  " + (i + 1);
                    dr["Account"] = "acc-  " + (i + 1);
                    dt.Rows.Add(dr);
                }
                return dt;
            }

        }
        public DataTable LoadProcessesX()
        {
            SqlConnection myConn = new SqlConnection(ConnectionString);
            SqlCommand myCmd = new SqlCommand();
            SqlDataAdapter myDA = new SqlDataAdapter();
            DataTable myResults = new DataTable();
            try
            {
                myConn.Open();
                myCmd = new SqlCommand();
                myCmd.Connection = myConn;
                myCmd.CommandText = "SELECT * " +
                                    "FROM dbo.Pharmacy " +
                                    "WHERE Status ='1' ";
                myDA.SelectCommand = myCmd;
                myDA.Fill(myResults);
                return myResults;

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                myConn.Close();
            }
        }
        public DataTable GetSummary()
        {
            SqlConnection myConn = new SqlConnection(ConnectionString);
            SqlCommand myCmd = new SqlCommand();
            SqlDataAdapter myDA = new SqlDataAdapter();
            DataTable myResults = new DataTable();
            try
            {
                myConn.Open();
                myCmd = new SqlCommand();
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.Connection = myConn;
                myCmd.CommandText = "GETRatingSummary";
                myDA.SelectCommand = myCmd;
                myDA.Fill(myResults);
                return myResults;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                myConn.Close();
            }
        }
        // Overloaded - update to indicate completion of this message processing.
        public void UpdateTAMIssuerRating(Int32 iMessageID, DateTime idateTime)
        {
            SqlConnection myConn = new SqlConnection(ConnectionString);
            SqlCommand SqlCmd = new SqlCommand();
            string myQuery = "";
            try
            {
                myQuery = "UPDATE dbo.TamIssuerRatingsServiceIO SET "
                           + " MsgProcessedDateTime = '" + String.Format("{0:MM/dd/yyyy H:mm:ss}", idateTime) + "'"
                           + " WHERE MessageID =" + iMessageID.ToString();
                SqlCmd.CommandText = myQuery;
                SqlCmd.Connection = myConn;
                myConn.Open();
                SqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConn.Close();
            }
        }
        public int InsertNewProcess(string iRAM, string iPharmacyName, string iHostIP, string iLocalDir, string iRemoteDir, string iPassword
                                    , string iLogin)
        {
            SqlConnection myConn = new SqlConnection(ConnectionString);
            SqlCommand myCmd = new SqlCommand();

            string myQuery = "";
            try
            {
                myQuery = "INSERT INTO dbo.FTPProcesses  (RAM, PharmacyName, HostIP, LocalDir,RemoteDir,Password,Login ) OUTPUT inserted.Id ";
                myQuery += " VALUES (@RAM, @PharmacyName, @HostIP, @LocalDir,@RemoteDir,@Password,@Login )";
                using (myCmd)
                {
                    myCmd.Parameters.AddWithValue("RAM", iRAM);
                    myCmd.Parameters.AddWithValue("PharmacyName", iPharmacyName);
                    myCmd.Parameters.AddWithValue("HostIP", iHostIP);
                    myCmd.Parameters.AddWithValue("LocalDir", iLocalDir);
                    myCmd.Parameters.AddWithValue("RemoteDir", iRemoteDir);
                    myCmd.Parameters.AddWithValue("Password", iPassword);
                    myCmd.Parameters.AddWithValue("Login", iLogin);

                    myCmd.CommandText = myQuery;
                    myCmd.Connection = myConn;
                    myConn.Open();
                    myCmd.ExecuteNonQuery();
                  
                     return (int)myCmd.ExecuteScalar();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConn.Close();
            }
        }
    }
}