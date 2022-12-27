using System;

namespace BeyondCode.Models.API.one2one
{
    public class AgentPolicyRequest
    {
        public string agent_id { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
    }


}