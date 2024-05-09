using DSWI_Proyecto_Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using DocumentFormat.OpenXml.Drawing;

namespace DSWI_Proyecto_Frontend.Controllers
{
    public class ProyectoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> ListarProyectos()
        {
            List<Proyecto> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Proyecto/");

                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Proyecto>>(apiResponse);
                }
                else
                {
                    lista = new List<Proyecto>();
                }

                return View(await Task.Run(() => lista));
            }
        }

        // REGISTRAR
        [HttpGet]
        public async Task<IActionResult> CrearProyecto()
        {
            ViewBag.listaUsuarios = new SelectList(await ListarUsuario(), "IdUsuario", "Nombre");
            ViewBag.listaTareas = new SelectList(await ListarTareas(), "IdTarea", "NombreProyecto");
            ViewBag.listaPrioridades = new SelectList(await ListarPrioridad(), "IdPrioridad", "Descripcion");
            ViewBag.listaEstados = new SelectList(await ListarEstado(), "IdEstado", "Descripcion");
            ViewBag.listaComplejidades = new SelectList(await ListarComplejidad(), "IdComplejidad", "Descripcion");
            ViewBag.listaCategorias = new SelectList(await ListarCategorias(), "IdCategoria", "Descripcion");
            ViewBag.listaTipos = new SelectList(await ListarTipo(), "IdTipo", "Descripcion");
            ViewBag.listaAreas = new SelectList(await ListarArea(), "IdArea", "Descripcion");
            return View(await Task.Run(() => new ProyectoOriginal()));
        }

        [HttpPost]
        public async Task<IActionResult> CrearProyecto(ProyectoOriginal reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Proyecto/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }

            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarProyectos");

        }

        //ACTUALIZAR
        [HttpGet]
        public async Task<IActionResult> EditarProyecto(string id)
        {
            ProyectoOriginal reg = new ProyectoOriginal();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Proyecto/");
                HttpResponseMessage response = await client.GetAsync(id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                reg =  JsonConvert.DeserializeObject<ProyectoOriginal>(apiResponse);
            }

            ViewBag.listaUsuarios = new SelectList(await ListarUsuario(), "IdUsuario", "Nombre", reg.IdUsuario);
            ViewBag.listaTareas = new SelectList(await ListarTareas(), "IdTarea", "NombreProyecto", reg.IdTarea);
            ViewBag.listaPrioridades = new SelectList(await ListarPrioridad(), "IdPrioridad", "Descripcion", reg.IdPrioridad);
            ViewBag.listaEstados = new SelectList(await ListarEstado(), "IdEstado", "Descripcion", reg.IdEstado);
            ViewBag.listaComplejidades = new SelectList(await ListarComplejidad(), "IdComplejidad", "Descripcion", reg.IdComplejidad);
            ViewBag.listaCategorias = new SelectList(await ListarCategorias(), "IdCategoria", "Descripcion", reg.IdCategoria);
            ViewBag.listaTipos = new SelectList(await ListarTipo(), "IdTipo", "Descripcion", reg.IdTipo);
            ViewBag.listaAreas = new SelectList(await ListarArea(), "IdArea", "Descripcion", reg.IdArea);
            return View(await Task.Run(() => reg));
        }

        [HttpPost]
        public async Task<IActionResult> EditarProyecto(ProyectoOriginal reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Proyecto/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync("", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }

            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarProyectos");
        }

        //ELIMINAR
        public async Task<IActionResult> EliminarProyecto(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Proyecto/");

                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7281/api/Proyecto/{id}");
            }
            return RedirectToAction("ListarProyectos");
        }


        //COMBOS
        public async Task<List<Usuario>> ListarUsuario()
        {
            List<Usuario> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Usuario/");

                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    lista = JsonConvert.DeserializeObject<List<Usuario>>(apiResponse);
                }
                else
                {
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }


        public async Task<List<Tipo>> ListarTipo()
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
            return lista;
        }

        public async Task<List<Tarea>> ListarTareas()
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

                return lista;
            }
        }


        public async Task<List<Prioridad>> ListarPrioridad()
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
            return lista;
        }

        public async Task<List<Complejidad>> ListarComplejidad()
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
            return lista;
        }

        public async Task<List<Categoria>> ListarCategorias()
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
            return lista;
        }

        public async Task<List<Area>> ListarArea()
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
            return lista;
        }

        public async Task<List<Estado>> ListarEstado()
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
            return lista;
        }

        //FIN COMBOS

        //EXPORTAR A EXCEL
        [HttpGet]
        public async Task<IActionResult> ExportarExcel(string fechaInicio, string fechaFin)
        {
            List<Proyecto> proyectos;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Proyecto/");

                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    proyectos = JsonConvert.DeserializeObject<List<Proyecto>>(apiResponse);

                    // Filtrar proyectos basados en fechaInicio y fechaFin (si aplica)
                    if (!string.IsNullOrEmpty(fechaInicio) && !string.IsNullOrEmpty(fechaFin))
                    {
                        proyectos = proyectos.Where(p => p.FechaInicio >= DateTime.Parse(fechaInicio) && p.FechaFin <= DateTime.Parse(fechaFin)).ToList();
                    }
                }
                else
                {
                    proyectos = new List<Proyecto>();
                }
            }

            if (proyectos.Count == 0)
            {
                // Manejar el caso en el que no se recuperen proyectos
                return View("NoProyectosDisponibles"); // Redireccionar a una vista que indique que no se encontraron proyectos
            }

            // Crear un nuevo paquete de Excel usando ClosedXML
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Proyectos");

                // Configurar encabezados para la hoja de trabajo
                worksheet.Cell(1, 1).Value = "NombreProyecto";
                worksheet.Cell(1, 2).Value = "DescripcionProyecto";
                worksheet.Cell(1, 3).Value = "DescripcionTarea";
                worksheet.Cell(1, 4).Value = "DescripcionCategoria";
                worksheet.Cell(1, 5).Value = "DescripcionEstado";
                worksheet.Cell(1, 6).Value = "DescripcionPrioridad";
                worksheet.Cell(1, 7).Value = "DescripcionComplejidad";
                worksheet.Cell(1, 8).Value = "FechaInicio";
                worksheet.Cell(1, 9).Value = "FechaFin";
                worksheet.Cell(1, 10).Value = "Mes";
                worksheet.Cell(1, 11).Value = "NombreUsuario";
                worksheet.Cell(1, 12).Value = "DescripcionArea";
                worksheet.Cell(1, 13).Value = "DescripcionTipo";
                worksheet.Cell(1, 14).Value = "Presupuesto";
                worksheet.Cell(1, 15).Value = "Asignado";
                worksheet.Cell(1, 16).Value = "Porcentaje";
                worksheet.Cell(1, 17).Value = "Comentarios";

                // Escribir datos de proyectos en la hoja de trabajo a partir de la segunda fila (fila 2)
                int row = 2;
                foreach (var proyecto in proyectos)
                {
                    worksheet.Cell(row, 1).Value = proyecto.NombreProyecto;
                    worksheet.Cell(row, 2).Value = proyecto.DescripcionProyecto;
                    worksheet.Cell(row, 3).Value = proyecto.DescripcionTarea;
                    worksheet.Cell(row, 4).Value = proyecto.DescripcionCategoria;
                    worksheet.Cell(row, 5).Value = proyecto.DescripcionEstado;
                    worksheet.Cell(row, 6).Value = proyecto.DescripcionPrioridad;
                    worksheet.Cell(row, 7).Value = proyecto.DescripcionComplejidad;
                    worksheet.Cell(row, 8).Value = proyecto.FechaInicio;
                    worksheet.Cell(row, 9).Value = proyecto.FechaFin;
                    worksheet.Cell(row, 10).Value = proyecto.Mes;
                    worksheet.Cell(row, 11).Value = proyecto.NombreUsuario;
                    worksheet.Cell(row, 12).Value = proyecto.DescripcionArea;
                    worksheet.Cell(row, 13).Value = proyecto.DescripcionTipo;
                    worksheet.Cell(row, 14).Value = proyecto.Presupuesto;
                    worksheet.Cell(row, 15).Value = proyecto.Asignado;
                    worksheet.Cell(row, 16).Value = proyecto.Porcentaje;
                    worksheet.Cell(row, 17).Value = proyecto.Comentarios;

                    row++;
                }

                // Ajustar automáticamente el ancho de las columnas para una mejor legibilidad
                worksheet.Columns().AdjustToContents();

                // Crear un flujo de memoria de Excel
                using (var memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    // Devolver el archivo Excel como un archivo descargable
                    return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Proyectos.xlsx");
                }
            }
        }


        public async Task<IActionResult> resumenEstado()
        {
            List<Proyecto> lista = await ListaProyecto();

            List<Estado> resu = new List<Estado>();
            int contNI = 0;
            int contEP = 0;
            int contC = 0;
            int contA = 0;
            int contD = 0;
            int contF = 0;

            foreach (var item in lista)
            {
                switch (item.DescripcionEstado)
                {
                    case "No Iniciado":
                        contNI++;
                        break;
                    case "En Progreso":
                        contEP++;
                        break;
                    case "Completado":
                        contC++;
                        break;
                    case "Atrasado":
                        contA++;
                        break;
                    case "Desestimado":
                        contD++;
                        break;
                    default:
                        contF++;
                        break;
                }
            }

            Estado e1 = new Estado(contNI, "No Iniciado");
            resu.Add(e1);

            Estado e2 = new Estado(contEP, "En Progreso");
            resu.Add(e2);

            Estado e3 = new Estado(contC, "Completado");
            resu.Add(e3);

            Estado e4 = new Estado(contA, "Atrasado");
            resu.Add(e4);

            Estado e5 = new Estado(contD, "Desestimado");
            resu.Add(e5);

            Estado e6 = new Estado(contF, "Finalizado");
            resu.Add(e6);

            return StatusCode(StatusCodes.Status200OK, resu);

        }

        public async Task<List<Proyecto>> ListaProyecto()
        {
            List<Proyecto> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/api/Proyecto/");

                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    lista = JsonConvert.DeserializeObject<List<Proyecto>>(apiResponse);
                }
                else
                {
                    lista = new List<Proyecto>();
                }
            }
            return lista;
        }

        public async Task<IActionResult> resumenMes()
        {
            List<Proyecto> lista = await ListaProyecto();

            List<Estado> resu = new List<Estado>();

            Estado enero = new Estado(0, "Enero");
            Estado febrero = new Estado(0, "Febrero");
            Estado marzo = new Estado(0, "Marzo");
            Estado abril = new Estado(0, "Abril");
            Estado mayo = new Estado(0, "Mayo");
            Estado junio = new Estado(0, "Junio");
            Estado julio = new Estado(0, "Julio");
            Estado agosto = new Estado(0, "Agosto");
            Estado setiembre = new Estado(0, "Septiembre");
            Estado octubre = new Estado(0, "Octubre");
            Estado noviembre = new Estado(0, "Noviembre");
            Estado diciembre = new Estado(0, "Diciembre");

            foreach (var item in lista)
            {
                switch (item.Mes)
                {
                    case "Enero":
                        enero.idEstado++;
                        break;
                    case "Febrero":
                        febrero.idEstado++;
                        break;
                    case "Marzo":
                        marzo.idEstado++;
                        break;
                    case "Abril":
                        abril.idEstado++;
                        break;
                    case "Mayo":
                        mayo.idEstado++;
                        break;
                    case "Junio":
                        junio.idEstado++;
                        break;
                    case "Julio":
                        julio.idEstado++;
                        break;
                    case "Agosto":
                        agosto.idEstado++;
                        break;
                    case "Septiembre":
                        setiembre.idEstado++;
                        break;
                    case "Octubre":
                        octubre.idEstado++;
                        break;
                    case "Noviembre":
                        noviembre.idEstado++;
                        break;
                    default:
                        diciembre.IdEstado++;
                        break;
                }
            }

            resu.Add(enero);
            resu.Add(febrero);
            resu.Add(marzo); resu.Add(abril); resu.Add(mayo);
            resu.Add(junio); resu.Add(julio); resu.Add(agosto);
            resu.Add(setiembre); resu.Add(octubre);
            resu.Add(noviembre); resu.Add(diciembre);


            return StatusCode(StatusCodes.Status200OK, resu);

        }
    }

}

