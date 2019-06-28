using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Example.Models
{
    public class Notes
    {
        public int id { set; get; }
        public string subject { set; get; }
        public string description { set; get; }
        public int type { set; get; }
        public int status { set; get; }
        public string date_time { set; get; }
    }
}