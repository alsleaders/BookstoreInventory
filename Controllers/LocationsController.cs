using System.Collections.Generic;
using System.Linq;
using bookstoreinventory;
using BookstoreInventory.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreInventory.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class LocationsController : ControllerBase
  {

    // Get all locations
    [HttpGet]
    public ActionResult<List<LocationModel>> Get()
    {
      var db = new DatabaseContext();
      var AllLocations = db.Location;
      return AllLocations.ToList();
    }

    // Post new location
    [HttpPost]

    public ActionResult<LocationModel> Post([FromBody]LocationModel placesForBooks)
    {
      var db = new DatabaseContext();
      db.Location.Add(placesForBooks);
      db.SaveChanges();
      return placesForBooks;
    }
  }

}

