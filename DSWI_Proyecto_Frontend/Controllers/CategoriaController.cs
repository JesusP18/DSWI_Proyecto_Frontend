using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using DSWI_Proyecto_Frontend.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace DSWI_Proyecto_Frontend.Controllers
{
    public class CategoriaController : Controller
    {
        //AUTOR: MIGUEL LOPEZ
        public async Task<IActionResult> ListarCategorias()
        {
            List<Categoria> lista;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:7281/api/Categoria/");
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Categoria>>(apiResponse);

                }
                else
                {
                    lista = new List<Categoria>();
                }

            }
            return View(await Task.Run(() => lista));
        }


        public async Task<IActionResult> CrearCategoria()
        {
            return View(await Task.Run(() => new Categoria()));
        }

        [HttpPost]
        public async Task<IActionResult> CrearCategoria(Categoria reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:7281/api/Categoria/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }

            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarCategorias");

        }


        public async Task<IActionResult> EditarCategoria(string id)
        {
            Categoria reg = new Categoria();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Categoria/");
                HttpResponseMessage response = await client.GetAsync(id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                reg = JsonConvert.DeserializeObject<Categoria>(apiResponse);
            }

            return View(await Task.Run(() => reg));
        }

        [HttpPost]
        public async Task<IActionResult> EditarCategoria(Categoria reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Categoria/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync("", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarCategorias");
        }

        public async Task<IActionResult> DetalleCategoria(string id)
        {
            Categoria categoria = new Categoria();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Categoria/");
                HttpResponseMessage response = await client.GetAsync(id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                categoria = JsonConvert.DeserializeObject<Categoria>(apiResponse);
            }

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        public async Task<IActionResult> EliminarCategoria(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Categoria/");

                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7281/api/Categoria/{id}");
            }

            return RedirectToAction("ListarCategorias");
        }



    }
}



