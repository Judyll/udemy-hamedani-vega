using System.ComponentModel.DataAnnotations;

namespace VegaApp.API.Models
{
    public class Model
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // We need to add these inverse properties so that EF will know that we want
        // a cascade delete rather than a restricted delete which means if the
        // make will be deleted, then models associated with the user will also be deleted
        public Make Make { get; set; }
        public int MakeId { get; set; }
    }
}