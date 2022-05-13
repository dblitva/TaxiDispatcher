using Newtonsoft.Json;
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
        public IDictionary<string, string[]> errors { get; set; }

        public string ErrorsToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var error in errors)
            {
                stringBuilder.AppendLine($"{error.Key}: {string.Join("", error.Value)}");
            }

            return stringBuilder.ToString();
        }
    }
}
