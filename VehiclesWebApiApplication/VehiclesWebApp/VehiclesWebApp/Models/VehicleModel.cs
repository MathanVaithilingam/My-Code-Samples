using System.ComponentModel.DataAnnotations;

namespace VehiclesWebApp.Models
{
    /// <summary>
    /// Vehicle View Model
    /// </summary>
    public class VehicleModel
    {
        public VehicleModel()
        { }
        
        [Key]
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