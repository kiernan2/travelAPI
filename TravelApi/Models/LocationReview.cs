using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
  public class LocationReview
  {
    public int LocationReviewId { get; set; }
    public int ReviewId { get; set; }
    public int LocationId { get; set; }

    public virtual Review Review { get; set; }
    public virtual Location Location { get; set; }
  }
}