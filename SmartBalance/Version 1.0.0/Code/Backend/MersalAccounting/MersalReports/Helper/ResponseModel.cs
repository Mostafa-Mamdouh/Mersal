using MersalReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MersalReports.Helpers
{
    public class ResponseModel
    {
        public string Message { set; get; }
        public string Status { set; get; }
        public List<BanksDTO> Result { set; get; }
    }
}
