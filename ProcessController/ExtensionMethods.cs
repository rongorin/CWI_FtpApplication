using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controllers
{
    //static class ExtensionMethods
    //{
    //    public static IEnumerable<SftpFile> ListDirectoryEM(this SftpClient client, string pattern)
    //    {
    //        string directoryName = (pattern[0] == '/' ? "" : "/") + pattern.Substring(0, pattern.LastIndexOf('/'));
    //        string regexPattern = pattern.Substring(pattern.LastIndexOf('/') + 1)
    //                .Replace(".", "\\.")
    //                .Replace("*", ".*")
    //                .Replace("?", ".");
    //        Regex reg = new Regex('^' + regexPattern + '$');

    //        var results = client.ListDirectory(String.IsNullOrEmpty(directoryName) ? "/" : directoryName)
    //            .Where(e => reg.IsMatch(e.Name));
    //        return results;
    //    }


    //}
}
