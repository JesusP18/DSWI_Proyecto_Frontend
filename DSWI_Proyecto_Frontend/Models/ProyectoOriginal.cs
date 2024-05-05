namespace DSWI_Proyecto_Frontend.Models
{
    public class ProyectoOriginal
    {
        private int idProyecto;
        private string nombreProyecto;
        private string descripcionProyecto;
        private int idTarea;
        private int idCategoria;
        private int idEstado;
        private int idPrioridad;
        private int idComplejidad;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private string mes;
        private int idUsuario;
        private int idArea;
        private int idTipo;
        private decimal presupuesto;
        private string asignado;
        private string porcentaje;
        private string comentarios;

        public ProyectoOriginal()
        {
            idProyecto = 0;
            nombreProyecto = "";
            descripcionProyecto = "";
            idTarea = 0;
            idCategoria = 0;
            idEstado = 0;
            idPrioridad = 0;
            idComplejidad = 0;
            fechaInicio = DateTime.Now;
            fechaFin = DateTime.Now;
            mes = "";
            idUsuario = 0;
            idArea = 0;
            idTipo = 0;
            presupuesto = 0;
            asignado = "";
            porcentaje = "";
            comentarios = "";
        }


        public ProyectoOriginal(int idProyecto, string nombreProyecto, string descripcionProyecto, int idTarea, int idCategoria, int idEstado, int idPrioridad, int idComplejidad, DateTime fechaInicio, DateTime fechaFin, string mes, int idUsuario, int idArea, int idTipo, decimal presupuesto, string asignado, string porcentaje, string comentarios)
        {
            this.idProyecto = idProyecto;
            this.nombreProyecto = nombreProyecto;
            this.descripcionProyecto = descripcionProyecto;
            this.idTarea = idTarea;
            this.idCategoria = idCategoria;
            this.idEstado = idEstado;
            this.idPrioridad = idPrioridad;
            this.idComplejidad = idComplejidad;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.mes = mes;
            this.idUsuario = idUsuario;
            this.idArea = idArea;
            this.idTipo = idTipo;
            this.presupuesto = presupuesto;
            this.asignado = asignado;
            this.porcentaje = porcentaje;
            this.comentarios = comentarios;

        }

        public int IdProyecto { get => idProyecto; set => idProyecto = value; }
        public string NombreProyecto { get => nombreProyecto; set => nombreProyecto = value; }
        public string DescripcionProyecto { get => descripcionProyecto; set => descripcionProyecto = value; }
        public int IdTarea { get => idTarea; set => idTarea = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public int IdEstado { get => idEstado; set => idEstado = value; }
        public int IdPrioridad { get => idPrioridad; set => idPrioridad = value; }
        public int IdComplejidad { get => idComplejidad; set => idComplejidad = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public string Mes { get => mes; set => mes = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdArea { get => idArea; set => idArea = value; }
        public int IdTipo { get => idTipo; set => idTipo = value; }
        public decimal Presupuesto { get => presupuesto; set => presupuesto = value; }
        public string Asignado { get => asignado; set => asignado = value; }
        public string Porcentaje { get => porcentaje; set => porcentaje = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
    }
}
