namespace DSWI_Proyecto_Frontend.Models
{
    public class Prioridad
    {
        private int idPrioridad;
        private string descripcion;

        public Prioridad()
        {
            this.idPrioridad = 0;
            this.descripcion = "";
        }

        public Prioridad(int idPrioridad, string descripcion)
        {
            this.idPrioridad = idPrioridad;
            this.descripcion = descripcion;
        }

        public int IdPrioridad { get => idPrioridad; set => idPrioridad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
