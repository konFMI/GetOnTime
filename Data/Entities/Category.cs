using System.ComponentModel.DataAnnotations;
using static GetOnTime.Data.DataConstants.Category;


namespace GetOnTime.Data.Entities
{
    public class Category
    {
        public int Id { get; init; }    

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public IEnumerable<Transport> Transports { get; init; } = new List<Transport>();
    }
}
