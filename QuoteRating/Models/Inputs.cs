using System.ComponentModel.DataAnnotations;

namespace QuoteRating.Models
{
    public class Inputs
    {
        [Required]
        public double Revenue { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Business { get; set; }
    }
}