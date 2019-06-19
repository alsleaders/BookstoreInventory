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
    // GET api/all
    [HttpGet]
    public ActionResult<List<Model>> Get()
    {
      var db = new DatabaseContext();
      var AllBooks = db.Books;
      return AllBooks.ToList();
    }

    // POST api/all
    [HttpPost]

    public ActionResult<Model> Post([FromBody]Model somethingToRead)
    {
      var db = new DatabaseContext();
      db.Books.Add(somethingToRead);
      db.SaveChanges();
      return somethingToRead;
    }

    // Get api/individual
    // [HttpGet("{Name}")]
    // public async ActionResult<Model> Get(string Name)
    // {
    //   var db = new DatabaseContext();
    //   return db.Books.Where(w => w.Name == Name).Select(s => new
    //   {
    //     s.Name,
    //     s.NuminStock,
    //     s.Price,
    //     s.Description
    //   }).ToList();

    // }
  }
}