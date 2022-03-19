using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoCRM.Core.Modules.SMS
{
    internal class Models
    {

        public class SendTransaction
        {
            public string op { get; set; }
            public string user { get; set; }
            public string pass { get; set; }
            public string fromNum { get; set; }
            public string toNum { get; set; }
            public string patternCode { get; set; }
            public Inputdata[] inputData { get; set; }
        }

        public class Inputdata
        {
            public string fullname { get; set; }
            public string title { get; set; }
            
            public string amount { get; set; }

            public string date { get; set; }

            public string stage { get; set; }

            public string id { get; set; }

            public string inc { get; set; }

            public string total { get; set; }
        }

    }
}
