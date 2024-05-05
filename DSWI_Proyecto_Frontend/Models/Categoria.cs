namespace DSWI_Proyecto_Frontend.Models
{
    public class Categoria
    {
        private int idCategoria;
        private string descripcion;

        public Categoria()
        {
            this.idCategoria = 0;
            this.descripcion = "";
        }

        public Categoria(int idCategoria, string descripcion)
        {
            this.idCategoria = idCategoria;
            this.descripcion = descripcion;
        }

        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
