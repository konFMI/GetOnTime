using System.ComponentModel.DataAnnotations;
using static GetOnTime.Data.DataConstants.TravelRoute;

namespace GetOnTime.Data.Entities
{
    public class TravellRoute
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(LocationNameMaxLength)]
        public string StartLocation { get; set; }
        
        [Required]
        [MaxLength(LocationNameMaxLength)]
        public string EndLocation { get; set; }

        [Required]
        public Decimal Price { get; set; }

        public int TransportId { get; set; }

        public Transport Transport { get; set; }


    }
}