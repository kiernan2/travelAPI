using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
  public class Review
  {
    [Required]
    public int ReviewId { get; set; }
    [Required]
    [StringLength(20)]
    public string Author { get; set; }
    [Required]
    public int Rating { get; set; }
    public string ReviewText { get; set; }
    [Required]
    public int LocationId { get; set; }
  }
}