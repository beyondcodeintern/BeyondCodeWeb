using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondCode.Models.Data.Client.Request
{
    public class GetClientRequest
    {
        public int ClientId { get; set; }
        public string CreatedBy { get; set; }
    }
}