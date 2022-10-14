using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowDetails.API.Entities
{
    public class Details
    {
        public int ShowID { get; set; }
        public string ShowName { get; set; }
        public string StartTime { get; set; }
        public string ShowDates { get; set; }
        public int TheaterId { get; set; }
    }
}
