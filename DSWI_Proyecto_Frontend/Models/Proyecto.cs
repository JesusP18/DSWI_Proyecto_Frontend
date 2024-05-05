namespace DSWI_Proyecto_Frontend.Models
{
    public class Proyecto
    {
        private int idProyecto;
        private string nombreProyecto;
        private string descripcionProyecto;
        private string descripcionTarea;
        private string descripcionCategoria;
        private string descripcionEstado;
        private string descripcionPrioridad;
        private string descripcionComplejidad;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private string mes;
        private string nombreUsuario;
        private string descripcionArea;
        private string descripcionTipo;
        private decimal presupuesto;
        private string asignado;
        private string porcentaje;
        private string comentarios;


        public Proyecto()
        {
            idProyecto = 0;
            nombreProyecto = "";
            descripcionProyecto = "";
            descripcionTarea = "";
            descripcionCategoria = "";
            descripcionEstado = "";
            descripcionPrioridad = "";
            descripcionComplejidad = "";
            fechaInicio = DateTime.Now;
            fechaFin = DateTime.Now;
            mes = "";
            nombreUsuario = "";
            descripcionArea = "";
            descripcionTipo = "";
            presupuesto = 0;
            asignado = "";
            porcentaje = "";
            comentarios = "";
        }


        public Proyecto(int idProyecto, string nombreProyecto, string descripcionProyecto, int idTarea, int idCategoria, int idEstado, int idPrioridad, int idComplejidad, DateTime fechaInicio, DateTime fechaFin, string mes, int idUsuario, int idArea, int idTipo, decimal presupuesto, string asignado, string porcentaje, string comentarios, string nombreUsuario, string descripcionTarea, string descripcionCategoria, string descripcionEstado, string descripcionPrioridad, string descripcionComplejidad, string descripcionArea, string descripcionTipo)
        {
            this.idProyecto = idProyecto;
            this.nombreProyecto = nombreProyecto;
            this.descripcionProyecto = descripcionProyecto;
            this.descripcionTarea = descripcionTarea;
            this.descripcionCategoria = descripcionCategoria;
            this.descripcionEstado = descripcionEstado;
            this.descripcionPrioridad = descripcionPrioridad;
            this.descripcionComplejidad = descripcionComplejidad;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.mes = mes;
            this.nombreUsuario = nombreUsuario;
            this.descripcionArea = descripcionArea;
            this.descripcionTipo = descripcionTipo;
            this.presupuesto = presupuesto;
            this.asignado = asignado;
            this.porcentaje = porcentaje;
            this.comentarios = comentarios;



        }

        public int IdProyecto { get => idProyecto; set => idProyecto = value; }
        public string NombreProyecto { get => nombreProyecto; set => nombreProyecto = value; }
        public string DescripcionProyecto { get => descripcionProyecto; set => descripcionProyecto = value; }
        public string DescripcionTarea { get => descripcionTarea; set => descripcionTarea = value; }
        public string DescripcionCategoria { get => descripcionCategoria; set => descripcionCategoria = value; }
        public string DescripcionEstado { get => descripcionEstado; set => descripcionEstado = value; }
        public string DescripcionPrioridad { get => descripcionPrioridad; set => descripcionPrioridad = value; }
        public string DescripcionComplejidad { get => descripcionComplejidad; set => descripcionComplejidad = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public string Mes { get => mes; set => mes = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string DescripcionArea { get => descripcionArea; set => descripcionArea = value; }
        public string DescripcionTipo { get => descripcionTipo; set => descripcionTipo = value; }
        public decimal Presupuesto { get => presupuesto; set => presupuesto = value; }
        public string Asignado { get => asignado; set => asignado = value; }
        public string Porcentaje { get => porcentaje; set => porcentaje = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
    }
}
