using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSalle.Ecommerce.Core.Models
{
    public class Product:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
