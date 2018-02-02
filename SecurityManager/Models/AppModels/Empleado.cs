using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityManager.Models.AppModels
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }
    }
}
