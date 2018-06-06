using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspCoreWeb.Models;
using System.Net.Http;

namespace AspCoreWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<List<HistoricEvent>> GetEvent(string url)
        {

            HttpClient client = new HttpClient();
            var jsonContent = await client.GetStringAsync(url);
            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonContent);
            List<HistoricEvent> listHsEvents = new List<HistoricEvent>();
            foreach (var item in json)
            {

                listHsEvents.Add(new HistoricEvent() { date = item.date, description = item.description });

            }
            return listHsEvents;
        }

        public async Task<IActionResult> Event(string id)
        {
            ViewData["Title"] = id;

            //Read the values from envrioment variable.
            var backEndSvcUrl = Environment.GetEnvironmentVariable("BackEndSvc");
            Console.WriteLine("Backend Svc Name: "+backEndSvcUrl);
            var backendSvcPort = 8080;
            var url = string.Format("http://{0}:{1}",backEndSvcUrl,backendSvcPort);
            Console.WriteLine("Backend Svc full url: "+url);
           
            return View(await GetEvent(string.Format("{0}/{1}",url ,id)));
        }


    }
}
