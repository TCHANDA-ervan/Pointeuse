using Microsoft.AspNetCore.Mvc;
using System.Data;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApplications.Models;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace WebApplications.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        string baseURL = "http://localhost:5084/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //appel de l'api 
            DataTable dt = new DataTable();
            using(var client = new HttpClient())
             {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("eleve");

                if(getData != null)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    dt= JsonConvert.DeserializeObject<DataTable>(results);

                }else
                {
                    Console.WriteLine("erreur calling web API");
                }
            }

            return View(); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}