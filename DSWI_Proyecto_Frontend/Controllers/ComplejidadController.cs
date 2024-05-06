using DSWI_Proyecto_Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DSWI_Proyecto_Frontend.Controllers
{
    public class ComplejidadController : Controller
    {
        public async Task<IActionResult> ListarComplejidad()
        {
            List<Complejidad> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Complejidad/");

                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    lista = JsonConvert.DeserializeObject<List<Complejidad>>(apiResponse);
                }
                else
                {
                    lista = new List<Complejidad>();
                }
            }
            return View(await Task.Run(() => lista));
        }

        //CREAR
        public async Task<IActionResult> CrearComplejidad()
        {

            return View(await Task.Run(() => new Complejidad()));
        }

        [HttpPost]
        public async Task<IActionResult> CrearComplejidad(Complejidad reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Complejidad/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarComplejidad");
        }

        //EDITAR
        public async Task<IActionResult> EditarComplejidad(string id)
        {

            Complejidad reg = new Complejidad();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Complejidad/");
                HttpResponseMessage response = await client.GetAsync(id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                reg = JsonConvert.DeserializeObject<Complejidad>(apiResponse);
            }
            return View(await Task.Run(() => reg));
        }

        [HttpPost]
        public async Task<IActionResult> EditarComplejidad(Complejidad reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Complejidad/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync("", content);
                String apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarComplejidad");
        }


        //ELIMINAR
        public async Task<IActionResult> EliminarComplejidad(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Complejidad/");

                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7281/api/Complejidad/{id}");
            }
            return RedirectToAction("ListarComplejidad");
        }
    }
}
