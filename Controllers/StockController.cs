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


    // Get everything out of stock for a location

    [HttpGet("{LocationId}")]

    public ActionResult<List<Model>> Get([FromRoute]int? LocationId)
    {
      var db = new DatabaseContext();
      if (LocationId == null)
      {
        return Unauthorized();
      }
      var place = db.Location.FirstOrDefault(f => f.Id == LocationId);
      var OOSLocation = db.Books.Where(w => w.LocationId == place.Id);
      return OOSLocation.ToList();
    }
  }
}