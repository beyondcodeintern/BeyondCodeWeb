using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaliphWeb.Models.API.Resource
{
    public class AddResourceRequest
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public int UserId { get; set; }

        public string CreatedBy { get; set; }

    }
}