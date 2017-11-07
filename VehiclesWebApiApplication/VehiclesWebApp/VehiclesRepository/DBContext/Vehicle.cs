using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesRepository.DBContext
{
    /// <summary>
    /// Vehicle Entity 
    /// </summary>
    [Table("Vehicles")]
    public class Vehicle
    {
        public Vehicle()
        { }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Range(1950,2050)]
        public int Year { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string VModel { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
