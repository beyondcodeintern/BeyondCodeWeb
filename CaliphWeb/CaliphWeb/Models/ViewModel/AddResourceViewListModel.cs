using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeyondCode.Models.API.Resource;
using BeyondCode.Models.API.Agent;
using BeyondCode.Models.API.Event.Response;
using BeyondCode.Models.API.Report;
using BeyondCode.Models.Data;
using BeyondCode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BeyondCode.Models.ViewModel
{
    public class AddResourceViewListModel
    {
        public AddResourceViewListModel()
        {
           
            Users = new List<AgentUser>();
        }
      
        public List<AgentUser> Users { get; set; }

        public string ResourceName { get; set; }

        public string Url { get; set; }

        public int UserId { get; set; }


    }
}