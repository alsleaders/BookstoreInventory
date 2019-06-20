using System.Collections.Generic;
using System.Linq;
using BookModel.Model;
using Microsoft.AspNetCore.Mvc;

namespace bookstoreinventory.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StockController : ControllerBase
  {
    // Get out of stock
    [HttpGet]
    public ActionResult<List<Model>> Get()
    {
      var db = new DatabaseContext();
      var OOSBooks = db.Books.Where(w => w.NuminStock == 0);
      return OOSBooks.ToList();
    }
  }
}