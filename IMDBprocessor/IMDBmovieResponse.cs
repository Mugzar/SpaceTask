using BaseProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBprocessor
{
    public class IMDBmovieResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Directors { get; set; }
        public string Genres { get; set; }
        public double? ImDbRating { get; set; }
        public string Image { get; set; }
        public string Plot { get; set; }
    }
}
