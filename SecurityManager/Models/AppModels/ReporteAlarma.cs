using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityManager.Models.AppModels
{
    public class ReporteAlarma
    {
        [Key]
        public int ReporteAlarmaId { get; set; }
        public string Alarma { get; set; }//IdAlarma
        public bool Funciona { get; set; }
        public string Comentarios { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}
