namespace DSWI_Proyecto_Frontend.Models
{
    public class Area
    {
        private int idArea;
        private string descripcion;

        public Area()
        {
            this.idArea = 0;
            this.descripcion = "";
        }

        public Area(int idArea, string descripcion)
        {
           this.idArea = idArea;
            this.descripcion = descripcion;
        }

        public int IdArea { get => idArea; set => idArea = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
