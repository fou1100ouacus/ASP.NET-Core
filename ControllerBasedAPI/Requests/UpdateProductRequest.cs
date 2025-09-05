using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerBasedAPI.Requests
{
    public class UpdateProductRequest
    {
         public string? Name { get; set; }
    public decimal? Price { get; set; }
    }
}