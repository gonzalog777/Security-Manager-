using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityManager.Models.AppModels
{
    public class ReporteAccidente
    {
        [Key]
        public int ReporteAccidenteId { get; set; }
        public string Accidente { get; set; }//IdAccidente
        public string Comentarios { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
    }
}
