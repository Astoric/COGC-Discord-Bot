using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Discord_Bot.Core.UserAccounts
{
    public class UserAccount
    {
        public bool staff { get; set; }

        public ulong ID { get; set; }

        public string name { get; set; }

        public string country { get; set; }

        public string team { get; set; }

        public string rank { get; set; }

        public string steamid { get; set; }

        public string faceit { get; set; }
    
        public string esea { get; set; }

        public string requestcode { get; set; }
        
        public string requestedid { get; set; }
    }
}