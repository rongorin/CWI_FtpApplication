using Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Services
{
    public   class FtpFactory
    {
        public virtual IFtpType CreateFtpFactory(string iTypeOfFtp, string iUpOrDown, string iRam, string iPattern)
        { 
            IFtpType ftp = null; 
            switch (iTypeOfFtp)
            {
                case "SFTP":
                    if (iUpOrDown == "upload")
                         ftp = new UploadBulkSecureSFtpType();

                    if (iUpOrDown  == "download")
                    {
                        if (iRam == iPattern)
                            ftp = new DownloadSFtpSinglefileType();
                        else
                            ftp = new DownloadSFtpType();
                    } 
                    break;

                case "FTP":
                    ftp = new UploadFtpType();
                    break;
                default:
                    //res = "Unknown FTP type for " + " for HostIp " + p.HostIP + " pharmacy " + p.PharmacyName + "\r\n";
                    break;
            }
            return ftp;
        }
    }
}
