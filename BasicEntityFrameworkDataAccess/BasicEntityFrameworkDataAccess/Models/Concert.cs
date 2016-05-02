using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEntityFrameworkDataAccess.Models
{
    public class Concert
    {
        public string Date { get; set; }
        public string Headliner { get; set; }
        public string Opener { get; set; }
        public string Venue { get; set; }
        public int Cost { get; set; }
    }
}
