using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using CaliphWeb.Models;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Calendar.v3;
using Google.Apis;
using Google.Apis.Calendar.v3.Data;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace CaliphWeb.Helper
{
    public class GoogleCalendarHelper
    {
        protected GoogleCalendarHelper()
        {

        }

        public static async Task<Event> CreateGoogleCalendar(GoogleCalender request)
        {
            string[] Scopes = { "https://www.googleapis.com/auth/calendar" };
            string ApplicationName = "testing api";
            UserCredential credential;
            string Path = HostingEnvironment.MapPath("~/Cre/Cre.json");
            using (var stream = new FileStream(Path, FileMode.Open, FileAccess.Read))
            {
                string credPath = HostingEnvironment.MapPath("~/Cre/token.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            //define services
            var services = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            //define request
            Event eventCalendar = new Event()
            {
                Summary = request.Summary,
                Location = request.Location,
                Start = new EventDateTime
                {
                    DateTime = request.Start
                },
                End = new EventDateTime
                {
                    DateTime = request.End
                },
                Description = request.Description
            };
            var eventRequest = services.Events.Insert(eventCalendar, "primary");
            var requestCreate = await eventRequest.ExecuteAsync();
            return requestCreate;
        }

        public static async Task<string> DeleteGoogleCalendar(string eventId)
        {
            string[] Scopes = { "https://www.googleapis.com/auth/calendar" };
            string ApplicationName = "testing api";
            UserCredential credential;
            string Path = HostingEnvironment.MapPath("~/Cre/Cre.json");
            using (var stream = new FileStream(Path, FileMode.Open, FileAccess.Read))
            {
                string credPath = HostingEnvironment.MapPath("~/Cre/token.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            //define services
            var services = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            //define request
            var eventRequest = services.Events.Delete("primary", eventId);
            var requestCreate = await eventRequest.ExecuteAsync();
            return requestCreate;
        }


    }
}