

namespace WebAPI.Models
{
    using System.Collections.Generic;
    public class QueryWSSiesa
    {
        public string ConectionName { get; set; }
        public string NameQuery { get; set; }
        public string Provider { get; set; }
        public string Cia { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public List<string> Filters { get; set; }

    }
}
