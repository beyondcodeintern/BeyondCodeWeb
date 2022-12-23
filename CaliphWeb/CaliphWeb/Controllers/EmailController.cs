using BeyondCode.Core;
using BeyondCode.Helper;
using BeyondCode.Helper.Mapper;
using BeyondCode.Models.API.Event.Request;
using BeyondCode.Models.API.Event.Response;
using BeyondCode.Models.ViewModel;
using BeyondCode.Services;
using BeyondCode.Services.Helper;
using BeyondCode.ViewModel.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeyondCode.Controllers
{
    public class EmailController : Controller
    {
        private readonly ICaliphAPIHelper _caliphAPIHelper;
        private readonly IMasterDataService _masterDataService;
        private readonly IUserService _userService;

        public EmailController(ICaliphAPIHelper caliphAPIHelper, IMasterDataService masterDataService, IUserService userService)
        {
            this._caliphAPIHelper = caliphAPIHelper;
            this._masterDataService = masterDataService;
            this._userService = userService;
        }
        public ActionResult Index()
        {
            SendEmail();
            return View();
        }
        public void SendEmail()
        {
            try {


                var fromAddress = new MailAddress("cams@caliphgroup.com", "Caliph Group");
                var toAddress = new MailAddress("mandyyan0928@gmail.com", "Test");
                const string fromPassword = "caliph@588";
                const string subject = "Subject";
                const string body = "Body";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex) { 
            
            }
        }

    }
}