using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerBasedAPI.Requests
{
    public class CreateProductReviewRequest
    {
            public string? Reviewer { get; set; }
    public int Stars { get; set; }
    }
}