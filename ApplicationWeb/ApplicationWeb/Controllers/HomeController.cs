using ApplicationWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using Pointeuse.Models;
using Pointeuse.Controllers;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace ApplicationWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        string baseURL = "http://localhost:5084/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task <IActionResult> Index()
        {
            //appel de l'api 
            List<Presence> Presences = new List<Presence>();
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("api/Presences");
                
                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                   Presences = JsonConvert.DeserializeObject<List<Presence>>(results);

                }
                else
                {
                    Console.WriteLine("erreur calling web API");
                }

                ViewData["Presences"] = Presences;


            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> FiliereAsync()
        {
            //appel de l'api 
            List<Eleve> Eleves = new List<Eleve>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("api/Eleves");

                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    Eleves = JsonConvert.DeserializeObject<List<Eleve>>(results);

                }
                else
                {
                    Console.WriteLine("erreur calling web API");
                }

                ViewData["Eleves"] = Eleves;

            }

            return View();
        }


       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}