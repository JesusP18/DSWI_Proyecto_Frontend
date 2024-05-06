namespace DSWI_Proyecto_Frontend.Models
{
    public class Complejidad
    {
        private int idComplejidad;
        private string descripcion;

        public Complejidad()
        {
            this.idComplejidad = 0;
            this.descripcion = "";
        }

        public Complejidad(int idComplejidad, string descripcion)
        {
            this.idComplejidad = idComplejidad;
            this.descripcion = descripcion;
        }

        public int IdComplejidad { get => idComplejidad; set => idComplejidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
