using Caliph.Library.Helper;
using BeyondCode.Core;
using BeyondCode.Helper;
using BeyondCode.Models.API;
using BeyondCode.Models.ViewModel;
using BeyondCode.Services;
using BeyondCode.Services.Helper;
using BeyondCode.ViewModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeyondCode.Controllers
{
    public class UserController : Controller
    {
        private readonly IMasterDataService _masterService;
        private readonly ICaliphAPIHelper _caliphAPIHelper;

        public UserController(IMasterDataService masterService, ICaliphAPIHelper caliphAPIHelper)
        {
            this._masterService = masterService;
            this._caliphAPIHelper = caliphAPIHelper;
        }

        public async Task<ActionResult> List()
        {
            var userListViewModel = new UserListViewModel
            {
            };

            var userFilterViewModel = new UserFilterViewModel
            {
                PageNumber = 1,
                PageSize = 10
            };

            var responseData = await _caliphAPIHelper.PostAsync<UserFilterViewModel, ResponseData<List<UserListResponse>>>(userFilterViewModel, "/api/v1/system-user/get-by-filter");
            userListViewModel.UserList.UserList = responseData.Data;
            userListViewModel.UserList.Paging.ItemCount = responseData.ItemCount;
            userListViewModel.UserList.Paging.PageSize = userFilterViewModel.PageSize;
            userListViewModel.UserList.Paging.CurrentPage = userFilterViewModel.PageNumber;

            return View(userListViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> List(UserFilterViewModel userFilterViewModel)
        {
            var responseData = await _caliphAPIHelper.PostAsync<UserFilterViewModel, ResponseData<List<UserListResponse>>>(userFilterViewModel, "/api/v1/system-user/get-by-filter");
            var userListDataViewModel = new UserListDataViewModel();
            userListDataViewModel.UserList = responseData.Data;
            userListDataViewModel.Paging.ItemCount = responseData.ItemCount;
            userListDataViewModel.Paging.PageSize = userFilterViewModel.PageSize;
            userListDataViewModel.Paging.CurrentPage = userFilterViewModel.PageNumber;
            return PartialView("_UserListTable", userListDataViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateStatus(string username, int status)
        {
            UserRequest userRequest = new UserRequest()
            {
                Username = username,
                StatusId = status,
                UpdatedBy = UserHelper.GetLoginUser()
            };

            var response = await _caliphAPIHelper.PostAsync<UserRequest, ResponseData<string>>(userRequest, "/api/v1/system-user/update-status");
            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> ConvertAgent(string username,string agentId)
        {
            ConvertAgentRequest userRequest = new ConvertAgentRequest()
            {
                Username = username,
                RoleId = (int)MasterDataEnum.RoleId.Agent,
                NewUsername = agentId
            };

            var response = await _caliphAPIHelper.PostAsync<ConvertAgentRequest, ResponseData<string>>(userRequest, "/api/v1/system-user/convert-one2one-agent");
            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdatePassword(string username, string password)
        {
            var key = "H6&a##5";

            UserRequest userRequest = new UserRequest()
            {
                Username = username,
                PW = HashHelper.GetHashMd5(key + password),
                UpdatedBy = UserHelper.GetLoginUser()
            };

            var response = await _caliphAPIHelper.PostAsync<UserRequest, ResponseData<string>>(userRequest, "/api/v1/system-user/update-pw");
            return Json(response);
        }
    }
}