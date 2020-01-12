using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Crud_User_MVC.Models;
using Crud_User_MVC.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using RestSharp;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace Crud_User_MVC.Controllers
{
    public class HomeController : Controller
    {
        UserAPI _api = new UserAPI();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
          
            _logger = logger;
        }

        public async Task<IActionResult>  Index()
        {
            List<User> users = new List<User>();

            HttpClient client = _api.Initial();

            HttpResponseMessage responce = await client.GetAsync("api/User");
            if (responce.IsSuccessStatusCode)
            {
                var results = responce.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<User>>(results);
            }
            return View(users);
        }
        public async Task<IActionResult> Details(int id)
        {
            User user = new User();
            HttpClient client = _api.Initial();

            HttpResponseMessage responce = await client.GetAsync($"api/User/{id}");

            if (responce.IsSuccessStatusCode)
            {
                var result = responce.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(result);
            }
            return View(user);
        }

        public IActionResult Create(User user)
        {
            HttpClient client = new HttpClient();
            
            var dataAsString = JsonConvert.SerializeObject(user);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            client.PostAsync("http://localhost:61531/api/User", content);
            //  var postUser = client.PostAsJsonAsync<User>("api/User", user);bu variant islemir--this method does not supported
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            RestClient client = new RestClient($"http://localhost:61531/api/User/{id}");
            RestRequest request = new RestRequest(Method.DELETE);
             await client.ExecuteAsync(request, CancellationToken.None);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id, User user)
        {
            HttpClient client = _api.Initial();
            HttpContent content =
            HttpResponseMessage responce = client.PutAsync($"api/User/{id}",);
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
