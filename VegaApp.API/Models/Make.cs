using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VegaApp.API.Models
{
    public class Make
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}