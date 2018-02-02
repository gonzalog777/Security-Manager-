using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityManager.Models.AppModels
{
    public class ReporteEpp
    {
        [Key]
        public int ReporteEppId { get; set; }
        public string Epp { get; set; }//IdEpp
        public string Comentarios { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
    }
}
