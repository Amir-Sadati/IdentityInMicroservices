using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain
{
    public class RevokeToken
    {
        public static Dictionary<string, List<string>> RevokeTokenList;

        static RevokeToken()
        {
            RevokeTokenList = new();
        }
    }
}
