using BodyBinding.Request;
using Microsoft.AspNetCore.Mvc;

namespace M05.Body.Controllers;

[ApiController]
public class ProductController: ControllerBase
{
  
  [HttpPost("product-controller")]
  public IActionResult Post(Product request)
  {
    return Ok(request);
  }
}

