using System.ComponentModel.DataAnnotations;

namespace BookstoreInventory.Model
{
  public class LocationModel
  {

    public int Id { get; set; }
    public string Address { get; set; }
    public string Manager { get; set; }
    public string PhoneNumber { get; set; }
  }
}