using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amaral_Guincho_Software
{
    class SenhaAleatoria
    {
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%&*";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length - 1)]);
            }
            return res.ToString();
        }
    }
}
