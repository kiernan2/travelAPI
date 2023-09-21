using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
  public class Location
  {
    [Required]
    public int LocationId { get; set; }
    [Required]
    public string LocationName { get; set; }
    public string Country { get; set; }
  }
}