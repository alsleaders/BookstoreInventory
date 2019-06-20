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

    public ActionResult<Model> GetSKU(string SKU)
    {
      var db = new DatabaseContext();
      var bookNumber = db.Books.FirstOrDefault(w => w.SKU == SKU);
      return bookNumber;
    }
  }
}