using System;
using BookstoreInventory.Model;
using Microsoft.CodeAnalysis;

namespace BookModel.Model
{
  public class Model
  {
    public int Id { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int NuminStock { get; set; }
    public float Price { get; set; }
    public DateTime DateOrdered { get; set; } = DateTime.Now;
    public string Author { get; set; }
    public bool Completed { get; set; }


    public int? LocationId { get; set; }
    public LocationModel Location { get; set; }
  }
}