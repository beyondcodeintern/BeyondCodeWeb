using BeyondCode.Models.API;
using BeyondCode.Models.API.Agent;
using BeyondCode.Models.API.Deal;
using BeyondCode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondCode.Models.ViewModel
{
    public class AddActivityViewModel
    {


        public AddActivityViewModel()
        {
            Deals = new List<Deal>();
            Clients = new List<Client>();
            Activities = new List<ActivityPoint>();
            AgentUsers = new List<AgentUser>();
        }
        public List<Client> Clients { get; set; }
        public List<Deal> Deals { get; set; }
        public List<ActivityPoint> Activities { get; set; }

        public List<AgentUser>  AgentUsers { get; set; }
        public List<ActivityReview> ActivityReviews { get; set; }

    }
}


