using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityManager.Models.AppModels
{
    public class AreaEpp
    {
        public int AreaId { get; set; }
        public Area Area { get; set; }

        public int EppId { get; set; }
        public Epp Epp { get; set; }
    }
}
