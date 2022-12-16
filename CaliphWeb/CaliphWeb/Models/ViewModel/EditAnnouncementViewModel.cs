using CaliphWeb.Models.API.Agent;
using CaliphWeb.Models.API.Announcement.Response;
using CaliphWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaliphWeb.Models.ViewModel
{
    public class EditAnnouncementViewModel
    {
        public EditAnnouncementViewModel()
        {
            Announcement = new Announcement();
            AnnouncementTypeList = new List<MasterData>();
            AgentUsers = new List<AgentUser>();
        }
        public Announcement Announcement { get; set; }
        public List<MasterData> AnnouncementTypeList { get; set; }
        public List<AgentUser> AgentUsers { get; set; }
    }
}