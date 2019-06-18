using System;
using System.Collections.Generic;
using System.Linq;
using BookModel.Model;
using Microsoft.AspNetCore.Mvc;

namespace bookstoreinventory.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemsController : ControllerBase
  {
    // GET api/values
    [HttpGet]
    public ActionResult<List<Model>> Get()
    {
      var db = new DatabaseContext();
      var AllBooks = db.Books;
      return AllBooks.ToList();
    }

    [HttpPost]

    public ActionResult<Model> Post([FromBody]Model somethingToRead)
    {
      var db = new DatabaseContext();
      db.Books.Add(somethingToRead);
      db.SaveChanges();
      return somethingToRead;
    }
  }
}