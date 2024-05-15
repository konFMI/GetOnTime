using Humanizer;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static GetOnTime.Data.DataConstants.Agent;
namespace GetOnTime.Data.Entities
{
    public class Agent
    {
        public int Id { get; init; }

        [Required]
        [MinLength(PhoneNumberMinLength)]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public IdentityUser User { get; set; }
    }
}