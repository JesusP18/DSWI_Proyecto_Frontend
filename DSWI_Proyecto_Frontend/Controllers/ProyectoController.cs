using DSWI_Proyecto_Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ClosedXML.Excel;

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
                client.BaseAddress = new Uri("https://localhost:7281/api/Proyecto");

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
    }
}
