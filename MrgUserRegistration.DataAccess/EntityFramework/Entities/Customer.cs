using System;
using System.ComponentModel.DataAnnotations;

namespace MrgUserRegistration.DataAccess.EntityFramework.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Guid AddressId { get; set; }

        [Required]
        public Address Address { get; set; }

        public Guid UniqueFieldsId { get; set; }

        [Required]
        public UniqueFields UniqueFields { get; set; }
    }
}
