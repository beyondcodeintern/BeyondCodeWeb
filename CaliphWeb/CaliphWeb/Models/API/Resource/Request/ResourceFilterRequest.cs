using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaliphWeb.Models.API.Resource
{
    public class ResourceFilterRequest
    {
       


        public string Name { get; set; }


      


     
        public DateTime? CreatedDateFrom { get; set; }
        public DateTime? CreatedDateTo { get; set; }
        
    }
}