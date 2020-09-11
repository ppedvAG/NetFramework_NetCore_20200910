using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoDB.SharedLibrary.Models;
using GeoDBWebAPI.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace GeoWebMVC.Controllers
{
    public class ContinentController : Controller
    {
        
        private string webAPIURL = "http://localhost:61038/api/Continent/";

        
        public ContinentController()
        {
            
        }

        // GET: Continent
        public async Task<IActionResult> Index()
        {
            IList<Continents> continentList = null;

            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(webAPIURL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    continentList = JsonConvert.DeserializeObject<List<Continents>>(apiResponse);
                }
            }

            if (continentList == null)
            {
                return NotFound();
            }

            return View(continentList);
        }

        // GET: Continent/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //WebAPI Call
            Continents continents = null;

            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(webAPIURL + id.ToString()))
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    continents = JsonConvert.DeserializeObject<Continents>(jsonResponse);
                }
            }

            if (continents == null)
            {
                return NotFound();
            }

            return View(continents);
        }

        // GET: Continent/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Continent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Continents continents)
        {
            if (continents != null)
                continents.Id = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                

                string json = JsonConvert.SerializeObject(continents);

                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using var client = new HttpClient();

                var response = await client.PostAsync("http://localhost:61038/api/Continent/", data);

                string result = response.Content.ReadAsStringAsync().Result;

                return RedirectToAction(nameof(Index));
            }
            return View(continents);
        }

        // GET: Continent/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //WebAPI Call
            Continents continents = null;

            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(webAPIURL + id.ToString()))
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    continents = JsonConvert.DeserializeObject<Continents>(jsonResponse);
                }
            }

            if (continents == null)
            {
                return NotFound();
            }
            return View(continents);
        }

        // POST: Continent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Continents continents)
        {
            if (id != continents.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //WebAPI Call
                    var json = JsonConvert.SerializeObject(continents);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    using var client = new HttpClient();

                    var response = await client.PutAsync("http://localhost:61038/api/Continent/" + continents.Id.ToString(), data);
                    string result = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(continents);
        }

        // GET: Continent/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //WebAPI Call
            Continents continents = null;

            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(webAPIURL + id.ToString()))
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    continents = JsonConvert.DeserializeObject<Continents>(jsonResponse);
                }
            }

            if (continents == null)
            {
                return NotFound();
            }

            return View(continents);
        }

        // POST: Continent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            //WebAPI Call
            using var client = new HttpClient();
            var response = await client.DeleteAsync(webAPIURL + id.ToString());

            string result = response.Content.ReadAsStringAsync().Result;

            return RedirectToAction(nameof(Index));
        }

        
    }
}
