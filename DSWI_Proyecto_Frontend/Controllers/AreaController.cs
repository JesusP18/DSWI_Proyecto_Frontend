using DSWI_Proyecto_Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DSWI_Proyecto_Frontend.Controllers
{
    public class AreaController : Controller
    {
        public async Task<IActionResult> ListarArea()
        {
            List<Area> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Area/");

                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    lista = JsonConvert.DeserializeObject<List<Area>>(apiResponse);
                }
                else
                {
                    lista = new List<Area>();
                }
            }
            return View(await Task.Run(() => lista));
        }

        //crear

        public async Task<IActionResult> CrearArea()
        {

            return View(await Task.Run(() => new Area()));
        }

        [HttpPost]
        public async Task<IActionResult> CrearArea(Area reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Area/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarArea");
        }

        //actualizar

        public async Task<IActionResult> EditarArea(string id)
        {

            Area reg = new Area();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Area/");
                HttpResponseMessage response = await client.GetAsync(id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                reg = JsonConvert.DeserializeObject<Area>(apiResponse);
            }
            return View(await Task.Run(() => reg));
        }

        [HttpPost]
        public async Task<IActionResult> EditarArea(Area reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Area/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync("", content);
                String apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarArea");
        }

        //detalle
        public async Task<IActionResult> DetalleArea(string id)
        {
            Area reg = new Area();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Area/");
                HttpResponseMessage response = await client.GetAsync(id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reg = JsonConvert.DeserializeObject<Area>(apiResponse);
                }
            }
            return View(reg);
        }

        //eliminar

        public async Task<IActionResult> EliminarArea(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Area/");

                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7281/api/Area/{id}");
            }
            return RedirectToAction("ListarArea");
        }

    }
}
