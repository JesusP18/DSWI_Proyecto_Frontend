using DSWI_Proyecto_Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace DSWI_Proyecto_Frontend.Controllers
{
    public class TareaController : Controller
    {
        //AUTOR JESUS PALOMINO
        //LISTAR TAREAS
        public async Task<IActionResult> ListarTareas()
        {
            List<Tarea> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Tarea/");

                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Tarea>>(apiResponse);
                }
                else
                {
                    lista = new List<Tarea>();
                }

                return View(await Task.Run(() => lista));
            }
        }

        //REGISTRAR TAREA
        [HttpGet]
        public async Task<IActionResult> CrearTarea()
        {

            return View(await Task.Run(() => new Tarea()));
        }

        [HttpPost]
        public async Task<IActionResult> CrearTarea(Tarea tarea)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Tarea/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(tarea), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }

            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarTareas");

        }

        //ACTUALIZAR TAREA
        public async Task<IActionResult> EditarTarea(string id)
        {
            Tarea tarea = new Tarea();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Tarea/");
                HttpResponseMessage response = await client.GetAsync(id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                tarea = JsonConvert.DeserializeObject<Tarea>(apiResponse);
            }

            return View(await Task.Run(() => tarea));
        }

        [HttpPost]
        public async Task<IActionResult> EditarTarea(Tarea tarea)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Tarea/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(tarea), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync("", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }

            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarTareas");
        }

        public async Task<IActionResult> EliminarTarea(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Tarea/");

                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7281/api/Tarea/{id}");
            }

            return RedirectToAction("ListarTareas");
        }



    }
}
