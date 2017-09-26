using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerPickupDTO
{
    public static class ApexTokenDTO
    {
        //public int Expires_in { get; set; }
        //public string Token_type { get; set; }
        //public string Access_Token { get; set; }

        public static string Client_id { get; set; }
        public static string Client_secret { get; set; }
        public static long Expires_in { get; set; }
        public static string access_token { get; set; }
        public static DateTime ExpiryDateTime { get; set; }

    }
}
