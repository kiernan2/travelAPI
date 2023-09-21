using TravelApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace TravelApi.Controllers
{
  public class HomeController : Controller
  {
    private readonly TravelApiContext _db;

    public HomeController(TravelApiContext db)
    {
      _db = db;
    }

    // [Route("/")]
    // public ActionResult Index()
    // {
      
    // }
  }
}