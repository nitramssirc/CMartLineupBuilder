using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddsAPIClient.Models
{
    public class OddsRequest
    {
        public string sport { get; set; }

        public string apiKey { get; set; }

        public string regions { get; set; }

        public string markets { get; set; }
    }
}
