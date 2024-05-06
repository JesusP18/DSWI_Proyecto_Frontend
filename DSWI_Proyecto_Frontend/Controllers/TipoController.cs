using DSWI_Proyecto_Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DSWI_Proyecto_Frontend.Controllers
{
    public class TipoController : Controller
    {
        public async Task<IActionResult> ListarTipo()
        {
            List<Tipo> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Tipo/");

                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    lista = JsonConvert.DeserializeObject<List<Tipo>>(apiResponse);
                }
                else
                {
                    lista = new List<Tipo>();
                }
            }
            return View(await Task.Run(() => lista));
        }

        //CREAR
        public async Task<IActionResult> CrearTipo()
        {

            return View(await Task.Run(() => new Tipo()));
        }

        [HttpPost]
        public async Task<IActionResult> CrearTipo(Tipo reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Tipo/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarTipo");
        }

        //EDITAR
        public async Task<IActionResult> EditarTipo(string id)
        {

            Tipo reg = new Tipo();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Tipo/");
                HttpResponseMessage response = await client.GetAsync(id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                reg = JsonConvert.DeserializeObject<Tipo>(apiResponse);
            }
            return View(await Task.Run(() => reg));
        }

        [HttpPost]
        public async Task<IActionResult> EditarTipo(Tipo reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Tipo/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync("", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarTipo");
        }

        //ELIMINAR
        public async Task<IActionResult> EliminarTipo(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Tipo/");

                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7281/api/Tipo/{id}");
            }
            return RedirectToAction("ListarTipo");
        }
    }
}
