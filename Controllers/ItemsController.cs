using System;
using System.Collections.Generic;
using System.Linq;
using BookModel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
      var AllBooks = db.Books.Include(i => i.Location);
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
    [HttpGet("{Name}")]
    public ActionResult<Model> GetOne(string Name)
    {
      var db = new DatabaseContext();
      var where = db.Books.Include(i => i.Location).FirstOrDefault(w => w.Name == Name);
      return where;

    }

    // Put api/individual
    // update name and/or price and/or sku and/or NuminStock and/or DateOrdered
    [HttpPut("{Name}")]

    public ActionResult<Model> UpdateOne(string Name, [FromBody]Model rhino)
    {
      var db = new DatabaseContext();
      var hippo = db.Books.FirstOrDefault(f => f.Name == Name);
      hippo.Name = rhino.Name;
      hippo.Price = rhino.Price;
      hippo.SKU = rhino.SKU;
      hippo.Description = rhino.Description;
      hippo.NuminStock = rhino.NuminStock;
      hippo.DateOrdered = rhino.DateOrdered;
      hippo.Author = rhino.Author;
      hippo.Completed = rhino.Completed;
      db.SaveChanges();
      return hippo;
    }

    // Delete api/individual
    [HttpDelete("{id}")]

    public ActionResult DeleteBook(int Id)
    {
      var db = new DatabaseContext();
      var deletedBook = db.Books.FirstOrDefault(f => f.Id == Id);
      if (deletedBook == null)
      {
        return NotFound();
      }
      else
      {
        db.Books.Remove(deletedBook);
        db.SaveChanges();
        return Ok();
      }
    }
  }
}