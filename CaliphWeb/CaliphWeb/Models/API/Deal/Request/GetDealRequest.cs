using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondCode.Models.API.Deal.Request
{
    public class GetDealRequest
    {
        public int ClientDealId { get; set; }
        public string CreatedBy { get; set; }
    }
}