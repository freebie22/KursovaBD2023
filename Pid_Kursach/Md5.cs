using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pid_Kursach
{
    public class Md5
    {
        public static string Get_hash(string pasw)
        {
            {
                MD5 mD5 = MD5.Create();
                byte[] b = Encoding.ASCII.GetBytes(pasw);
                byte[] hash = mD5.ComputeHash(b);
                StringBuilder sb = new StringBuilder();
                foreach (var a in hash)
                    sb.Append(a.ToString("x2"));
                return Convert.ToString(sb);
            }
        }
    }
}
