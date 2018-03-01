using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Core.Models
{
    class PaymentResponse
    {
        public string Message { get; set; }
        public bool flag { get; set; }
        public string AcsUrl { get; set; }
        public string _PaReq { get; set; }
        public string _TermUrl { get; set; }
        public string payment_id { get; set; }
    }
}
