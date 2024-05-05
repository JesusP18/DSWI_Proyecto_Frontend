namespace DSWI_Proyecto_Frontend.Models
{
    public class Tarea
    {
            private int idTarea;
            private string nombreProyecto;
            private string descripcionTarea;

            public Tarea()
            {
                this.idTarea = 0;
                this.nombreProyecto = "";
                this.descripcionTarea = "";
            }

            public Tarea(int idTarea, string nombreProyecto, string descripcionTarea)
            {
                this.idTarea = idTarea;
                this.nombreProyecto = nombreProyecto;
                this.descripcionTarea = descripcionTarea;
            }

            public int IdTarea { get => idTarea; set => idTarea = value; }
            public string NombreProyecto { get => nombreProyecto; set => nombreProyecto = value; }
            public string DescripcionTarea { get => descripcionTarea; set => descripcionTarea = value; }
        
    }
}
