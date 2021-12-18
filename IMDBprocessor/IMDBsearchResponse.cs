using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBprocessor
{
    public class IMDBsearchResponse
    {
        public string SearchType { get; set; }
        public string Expression { get; set; }
        public List<ResultItem> Results { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class ResultItem
    {
        public string Id { get; set; }
        public string ResultType { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
