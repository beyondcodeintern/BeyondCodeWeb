using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaliphWeb.Models.API.Resource.Request
{
    public class EditResourceRequest
    {
        public int ResourceId { get; set; }


        public string Name { get; set; }


        public string Url { get; set; }

        public int? UserId { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}