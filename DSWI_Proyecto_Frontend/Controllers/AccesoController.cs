using DSWI_Proyecto_Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace DSWI_Proyecto_Frontend.Controllers
{
    public class AccesoController : Controller
    {
        static string cadena = "server=DESKTOP-E2F8HTJ\\SA;database=DB_Planeamiento;user id=sa; pwd=sql; TrustServerCertificate=true;";


        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Usuario usuario)
        {
            bool registrado;
            string mensaje;

            if (usuario.Clave == usuario.ConfirmarClave) 
            {
                usuario.Clave = ConvertirSha256(usuario.Clave);
            } else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("usp_registrarUsuario", cn);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();

            }

            ViewData["Mensaje"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Login", "Acceso");
            } else
            {
                return View();
            }

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            usuario.Clave = ConvertirSha256(usuario.Clave);

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("usp_validarUsuario", cn);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                usuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                if (usuario.IdUsuario != 0)
                {
                    
                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));
                    return RedirectToAction("Index", "Home");
                } else
                {
                    ViewData["Mensaje"] = "usuario no encontrado";
                    
                }

            }
            return RedirectToAction("Index", "Home");
        }


        public static string ConvertirSha256(string texto) 
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
