using System.ComponentModel.DataAnnotations;

namespace MrgUserRegistration.DataAccess.EntityFramework.Entities
{
    public class Address : BaseEntity
    {
        [Required]
        public string InlineAddress { get; set; }
    }
}
