﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaliphWeb.Core;
using CaliphWeb.Helper;
using CaliphWeb.Models.API.AgentRecruit;
using CaliphWeb.Models.API.Event.Response;
using CaliphWeb.Models.API.Report;
using CaliphWeb.Models.ViewModel;
using CaliphWeb.Services;
using CaliphWeb.Services.Helper;
using CaliphWeb.ViewModel;
using CaliphWeb.ViewModel.Data;
using ClosedXML.Excel;
using OfficeOpenXml;
using Rotativa;
using Rotativa.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CaliphWeb.Controllers
{
    [Authorize]

    public class ResourceController : Controller
    {
        private readonly ICaliphAPIHelper _caliphAPIHelper;
        private readonly IMasterDataService _masterDataService;
        private readonly IUserService _userService;

        public ResourceController(ICaliphAPIHelper caliphAPIHelper, IMasterDataService masterDataService, IUserService userService)
        {
            this._caliphAPIHelper = caliphAPIHelper;
            this._masterDataService = masterDataService;
            this._userService = userService;
        }
        // GET: Resource
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Project100()
        {

            var view = new Project100ViewModel();
            view.Agents = await _userService.GetAgentUserAsync();

            return View(view);
        }
        public async Task<ActionResult> Project100Recruit()
        {

            var view = new Project100RecruitmentViewModel();
            view.Agents = await _userService.GetAgentUserAsync();

            return View(view);
        }

        public ActionResult ExportProject100()
        {
            return View();
        }


        public async Task<ActionResult> Add()
        {
            var vm = new AddResourceViewListModel();
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

          
            vm.Users = await _userService.GetAgentUserAsync();
            return View(vm);
        }

        public async Task<ActionResult> List()
        {
            var vm = new ResourceListViewModel();

            vm.Status = await _masterDataService.GetResourceStatusAsync();
            vm.Users = await _userService.GetAgentUserAsync();
            return View(vm);
        }


    }
}