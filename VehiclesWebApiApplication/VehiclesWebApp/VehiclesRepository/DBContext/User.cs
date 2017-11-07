using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VehiclesRepository.DBContext
{
    /// <summary>
    /// User Entity
    /// </summary>
    [Table("Users")]
    public class User
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public string UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
