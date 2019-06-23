using System.Collections.Generic;
using System.Linq;
using BookModel.Model;
using Microsoft.AspNetCore.Mvc;

namespace bookstoreinventory.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SKUController : ControllerBase
  {
    // Get by SKU
    [HttpGet("{SKU}")]

    public ActionResult<List<Model>> GetSKU(string SKU)
    {
      var db = new DatabaseContext();
      if (SKU != null)
      {
        var bookNumber = db.Books.Where(w => w.SKU == SKU);
        return bookNumber.ToList();
      }
      else
      {
        return NotFound();
      }
    }
  }
}