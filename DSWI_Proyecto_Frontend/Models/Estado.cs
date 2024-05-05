namespace DSWI_Proyecto_Frontend.Models
{
    public class Estado
    {
        public int idEstado;
        public string descripcion;

        public Estado()
        {
            this.idEstado = 0;
            this.descripcion = "";
        }

        public Estado(int idEstado, string descripcion)
        {
            this.idEstado = idEstado;
            this.descripcion = descripcion;
        }

        public int IdEstado { get => idEstado; set => idEstado = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
