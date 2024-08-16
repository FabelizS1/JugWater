using System.ComponentModel.DataAnnotations;

namespace Jug_Water_API.Models
{
    public class Jug
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only Positive Number")]
        public int x_capacity { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only Positive Number")]
        public int y_capacity { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only Positive Number")]
        public int z_capacity { get; set; }

    }
}
