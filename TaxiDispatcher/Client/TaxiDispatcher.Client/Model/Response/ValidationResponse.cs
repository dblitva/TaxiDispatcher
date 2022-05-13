using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDispatcher.Client.Model.Response
{
    public class ValidationResponse
    {
        public string type { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string traceId { get; set; }
        public Errors errors { get; set; }
    }

    public class Errors
    {
        public List<string> LocationFrom { get; set; }
    }
}
