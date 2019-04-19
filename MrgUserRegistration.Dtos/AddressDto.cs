using System.ComponentModel.DataAnnotations;

namespace MrgUserRegistration.Dtos
{
    public class AddressDto
    {
        [Required]
        public string InlineAddress { get; set; }
    }
}