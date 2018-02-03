using SecurityManager.Models.AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityManager.Models.AppViewModels
{
    public class AreaViewModel:Area
    {
        public List<EppViewModel> Epps { get; set; }
    }
}
