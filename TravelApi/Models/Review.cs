using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TravelApi.Models
{
  public class Review
  {
    [Required]
    public int ReviewId { get; set; }
    [Required]
    public string Author { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; }
    public int Country { get; set; }
    public int City { get; set; }
    //public virtual ICollection<LocationReview> JoinEntities { get; }
  }
}