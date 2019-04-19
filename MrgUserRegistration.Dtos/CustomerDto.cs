using System;
using System.ComponentModel.DataAnnotations;

namespace MrgUserRegistration.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public AddressDto Address { get; set; }

        [Required]
        public UniqueFieldsDto UniqueFields { get; set; }
    }
}
