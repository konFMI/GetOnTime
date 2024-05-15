using Humanizer;
using System.ComponentModel.DataAnnotations;
using static GetOnTime.Data.DataConstants.Transport;
namespace GetOnTime.Data.Entities
{
    public class Transport
    {

        public int Id { get; init; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        
        [Required]
        public int AgentId { get; set; }

        public Agent Agent { get; set; }

        public IEnumerable<TravellRoute> Routes { get; set; } = new List<TravellRoute>();
    }
}