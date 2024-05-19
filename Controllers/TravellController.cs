using Microsoft.AspNetCore.Mvc;
using GetOnTime.Models.Travells;

namespace GetOnTime.Controllers
{
    public class TravellController
    {
        public IActionResult All()
            => View(AllTravellsQueryModel());
    }
}
  