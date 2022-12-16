using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaliphWeb.Models.API.Resource;
using CaliphWeb.Models.API.Agent;
using CaliphWeb.Models.API.Event.Response;
using CaliphWeb.Models.API.Report;
using CaliphWeb.Models.Data;
using CaliphWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CaliphWeb.Models.ViewModel
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