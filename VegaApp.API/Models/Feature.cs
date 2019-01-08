using System.ComponentModel.DataAnnotations;

namespace VegaApp.API.Models
{
    public class Feature
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}