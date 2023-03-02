using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_requests
{
    internal class ResponseTask4
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int PageCount { get; set; }
        public List<Resource> Data { get; set; }
    }
}
