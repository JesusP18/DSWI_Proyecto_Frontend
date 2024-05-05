using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Http;
using DSWI_Proyecto_Frontend.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;


namespace DSWI_Proyecto_Frontend.Controllers
{
    public class EstadoController : Controller
    {


        public async Task<IActionResult> ListarEstado()
        {
            List<Estado> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Estado/");

                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    lista = JsonConvert.DeserializeObject<List<Estado>>(apiResponse);
                }
                else
                {
                    lista = new List<Estado>();
                }
            }
            return View(await Task.Run(() => lista));
        }


        public async Task<IActionResult> CrearEstado()
        {

            return View(await Task.Run(() => new Estado()));
        }

        [HttpPost]
        public async Task<IActionResult> CrearEstado(Estado reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Estado/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarEstado");
        }

        public async Task<IActionResult> EditarEstado(string id)
        {

            Estado reg = new Estado();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Estado/");
                HttpResponseMessage response = await client.GetAsync(id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                reg = JsonConvert.DeserializeObject<Estado>(apiResponse);
            }
            return View(await Task.Run(() => reg));
        }

        [HttpPost]
        public async Task<IActionResult> EditarEstado(Estado reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Estado/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync("", content);
                String apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarEstado");
        }

        public async Task<IActionResult> DetalleEstado(string id)
        {
            Estado reg = new Estado();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Estado/");
                HttpResponseMessage response = await client.GetAsync(id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reg = JsonConvert.DeserializeObject<Estado>(apiResponse);
                }
            }
            return View(reg);
        }

        public async Task<IActionResult> EliminarEstado(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Estado/");

                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7281/api/Estado/{id}");
            }
            return RedirectToAction("ListarEstado");
        }


    }
}
