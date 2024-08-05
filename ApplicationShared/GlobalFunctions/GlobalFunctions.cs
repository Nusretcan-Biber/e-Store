using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationShared.GlobalFunctions
{
    public class GlobalFunctions : IGlobalFunctions
    {
        public string CalculateMD5(string inputString)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = md5.ComputeHash(inputBytes);
            return Convert.ToBase64String(hash);
        }
    }
}
