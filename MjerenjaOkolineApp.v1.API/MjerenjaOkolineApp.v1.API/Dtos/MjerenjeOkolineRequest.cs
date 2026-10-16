using System.ComponentModel.DataAnnotations;

namespace MjerenjaOkolineApp.v1.API.Dtos
{
    public class MjerenjeOkolineRequest
    {
        [Required]
        [StringLength(50)]
        public string DeviceId { get; set; } = "";

        [Range(0, 50)]
        public decimal TemperaturaC { get; set; }

        [Range(0, 100)]
        public decimal VlaznostZraka { get; set; }
    }
}
