﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityManager.Models.AppModels
{
    public class Epp
    {
        [Key]
        public int EppId { get; set; }
        public string Nombre { get; set; }

        public List<AreaEpp> AreaEpp { get; set; }
    }
}
