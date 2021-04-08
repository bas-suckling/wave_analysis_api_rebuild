using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wave_analysis_rebuild.Models
{
    public class MetaData
    {
        public int id { get; set; }
        public string metaData { get; set; }

        public string sessionData { get; set; }
        public int userId { get; set; }
    }
}
