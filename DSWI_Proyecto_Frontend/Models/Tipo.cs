namespace DSWI_Proyecto_Frontend.Models
{
    public class Tipo
    {
        private int idTipo;
        private string descripcion;

        public Tipo()
        {
            this.idTipo = 0;
            this.descripcion = "";
        }

        public Tipo(int idTipo, string descripcion)
        {
            this.idTipo = idTipo;
            this.descripcion = descripcion;
        }

        public int IdTipo { get => idTipo; set => idTipo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
