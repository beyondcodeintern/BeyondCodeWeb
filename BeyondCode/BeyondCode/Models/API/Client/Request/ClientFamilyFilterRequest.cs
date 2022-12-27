﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondCode.Models.API.Client.Request
{
    public class ClientFamilyFilterRequest
    {
        public int ClientId { get; set; }
        public int? StatusId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}