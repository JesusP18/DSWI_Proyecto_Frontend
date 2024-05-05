using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Http;
using DSWI_Proyecto_Frontend.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;


namespace DSWI_Proyecto_Frontend.Controllers
{
    public class PrioridadController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> ListarPrioridad()
        {
            List<Prioridad> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Prioridad/");

                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    lista = JsonConvert.DeserializeObject<List<Prioridad>>(apiResponse);
                }
                else
                {
                    lista = new List<Prioridad>();
                }
            }
            return View(await Task.Run(() => lista));
        }


        [HttpGet]
        public async Task<IActionResult> CrearPrioridad()
        {

            return View(await Task.Run(() => new Prioridad()));
        }

        [HttpPost]
        public async Task<IActionResult> CrearPrioridad(Prioridad reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Prioridad/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarPrioridad");
        }

        [HttpGet]
        public async Task<IActionResult> EditarPrioridad(string id)
        {

            Prioridad reg = new Prioridad();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Prioridad/");
                HttpResponseMessage response = await client.GetAsync(id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                reg = JsonConvert.DeserializeObject<Prioridad>(apiResponse);
            }
            return View(await Task.Run(() => reg));
        }

        [HttpPost]
        public async Task<IActionResult> EditarPrioridad(Prioridad reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Prioridad/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync("", content);
                String apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarPrioridad");
        }

        public async Task<IActionResult> DetallePrioridad(string id)
        {
            Prioridad reg = new Prioridad();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Prioridad/");
                HttpResponseMessage response = await client.GetAsync(id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reg = JsonConvert.DeserializeObject<Prioridad>(apiResponse);
                }
            }
            return View(reg);
        }

        public async Task<IActionResult> EliminarPrioridad(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Prioridad/");

                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7281/api/Prioridad/{id}");
            }
            return RedirectToAction("ListarPrioridad");
        }

        public async Task<IActionResult> ListarPrioridades(int? currentPage = 1, int pageSize = 10) // Assuming 10 items per page
        {
            List<Prioridad> lista;
            int totalItems = 5; // Get total number of priorities (replace with your logic)

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Prioridad/");

                int skip = (int)((currentPage - 1) * pageSize);
                HttpResponseMessage response = await client.GetAsync($"?skip={skip}&take={pageSize}");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Prioridad>>(apiResponse);
                }
                else
                {
                    lista = new List<Prioridad>();
                }
            }

            // Additional logic to calculate total pages, handle edge cases (e.g., invalid page number)
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentPage"] = currentPage;

            return View(lista);
        }

    }
}
