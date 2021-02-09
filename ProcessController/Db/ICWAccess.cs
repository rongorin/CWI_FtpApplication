using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICW_FtpApp
{
    class ICWAccess
    {
       private DALICWService.Admin DataObj;

        private string CwiConnectionString = "";
        public ICWAccess(string iConnectionString)
        {
           
                CwiConnectionString = iConnectionString;
            try
            {
                DataObj = new DALICWService.Admin(CwiConnectionString);

            }
            catch (Exception exc)
            {
                throw new Exception("error", exc);  
            }
        }
        public DataTable LoadProcesses(bool IsDownload, string status = "", string ownerscheme = "")
        {
                 bool indWhere = false;
                SqlConnection myConn = new SqlConnection(CwiConnectionString);
                SqlCommand myCmd = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataTable myResults = new DataTable();
                try
                {
                    myConn.Open();
                    myCmd = new SqlCommand();
                    myCmd.Connection = myConn;
                    if (IsDownload)
                        myCmd.CommandText = "SELECT * FROM dbo.FTPProcesses ";  
                    else
                        myCmd.CommandText = "SELECT * FROM dbo.FTPProcessesUpload ";

                    if (status != "")
                    {
                        myCmd.CommandText += "WHERE Status = '" + status + "'";
                        indWhere = true;
                    }
                    if (ownerscheme != null && ownerscheme != "" && ownerscheme != "All")
                    {
                        if (indWhere)
                            myCmd.CommandText += " AND OwnerScheme = '" + ownerscheme + "'";
                        else
                            myCmd.CommandText += "WHERE OwnerScheme = '" + ownerscheme + "'"; 
                    }
                     myCmd.CommandText +=" Order By SortOrder"; 
                     
                    myDA.SelectCommand = myCmd;
                    myDA.Fill(myResults);
                    return myResults;

                }
                catch (Exception Ex)
                {
                    throw new Exception (Ex.Message);
                }
                finally
                {
                    myConn.Close();
                } 
 

        }
        //public DataTable LoadUpProcesses( )
        //{ 
        //        SqlConnection myConn = new SqlConnection(CwiConnectionString);
        //        SqlCommand myCmd = new SqlCommand();
        //        SqlDataAdapter myDA = new SqlDataAdapter();
        //        DataTable myResults = new DataTable();
        //        try
        //        {
        //            myConn.Open();
        //            myCmd = new SqlCommand();
        //            myCmd.Connection = myConn;
        //            myCmd.CommandText = "SELECT * " +
        //                                "FROM dbo.FTPProcessesUpload"; // Where Status = 1
        //            //+ "WHERE Status ='1' ";
        //            myDA.SelectCommand = myCmd;
        //            myDA.Fill(myResults);
        //            return myResults;

        //        }
        //        catch (Exception Ex)
        //        {
        //            throw Ex;
        //        }
        //        finally
        //        {
        //            myConn.Close();
        //        }
         
        //}
       
        public int InsertNewProcess(Process p , bool isDownload)
        {

            try
            { 
                //DataObj = new DALICWService.Admin(CwiConnectionString);
                //return DataObj.InsertNewProcess(iRAM, p.PharmacyName, p.HostIP, p.LocalDir, p.RemoteDir, p.Password, p.Login);

                SqlConnection myConn = new SqlConnection(CwiConnectionString);
                SqlCommand myCmd = new SqlCommand();

                string myQuery = "";
                try
                {
                    if (isDownload)
                        myQuery = "INSERT INTO dbo.FTPProcesses        (RAM, PharmacyName,Port, HostIP, LocalDir,RemoteDir,Password,Login  ,FtpType, Pattern , Status, OwnerScheme ) OUTPUT inserted.Id "; 
                    else
                        myQuery = "INSERT INTO dbo.FTPProcessesUpload  (RAM, PharmacyName,Port, HostIP, LocalDir,RemoteDir,Password,Login ,FtpType, Pattern , Status, OwnerScheme ) OUTPUT inserted.Id ";

                    myQuery += " VALUES (@RAM, @PharmacyName, @Port, @HostIP, @LocalDir,@RemoteDir,@Password,@Login ,@FtpType, @Pattern, @Status, @OwnerScheme)";


                    using (myCmd)
                    {
                        myCmd.Parameters.AddWithValue("RAM", p.RAM);
                        myCmd.Parameters.AddWithValue("PharmacyName", p.PharmacyName);
                        myCmd.Parameters.AddWithValue("Port", p.Port);
                        myCmd.Parameters.AddWithValue("HostIP", p.HostIP);
                        myCmd.Parameters.AddWithValue("LocalDir", p.LocalDir);
                        myCmd.Parameters.AddWithValue("RemoteDir", p.RemoteDir);
                        myCmd.Parameters.AddWithValue("Password", p.Password);
                        myCmd.Parameters.AddWithValue("Login", p.Login);
                        myCmd.Parameters.AddWithValue("FtpType", p.FtpType);
                        myCmd.Parameters.AddWithValue("Pattern", p.Pattern);
                        myCmd.Parameters.AddWithValue("Status", p.Status);
                        myCmd.Parameters.AddWithValue("OwnerScheme", p.Status);

                        myCmd.CommandText = myQuery;
                        myCmd.Connection = myConn;
                        myConn.Open(); 
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
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
        public void UpdateProcess(Process p, bool isDownload)
        {
            SqlConnection myConn = new SqlConnection(CwiConnectionString);
            SqlCommand SqlCmd = new SqlCommand();
            string myQuery = "";
            try
            {

                if (isDownload)
                    myQuery = "UPDATE [dbo].[FTPProcesses] SET ";
                else
                    myQuery = "UPDATE [dbo].[FTPProcessesUpload] SET ";

                myQuery += "PharmacyName ='" + p.PharmacyName + "'"
                    + ",HostIP ='" + p.HostIP + "'"
                    + " ,Port = '" + p.Port + "'"
                    + " ,LocalDir = '" + p.LocalDir + "'"
                    + " ,RemoteDir = '" + p.RemoteDir + "'"
                    + " ,Password = '" + p.Password + "'"
                    + " ,Login = '" + p.Login + "'"
                    + " ,FtpType = '" + p.FtpType + "'"
                    + " ,Pattern = '" + p.Pattern + "'"
                    + " ,Status = '" + p.Status + "'"
                    + " ,OwnerScheme = '" + p.OwnerScheme + "'"
                    + " WHERE [ID] =" + p.ID;

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

    }
}
