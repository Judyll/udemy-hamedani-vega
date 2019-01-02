namespace VegaApp.API.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // We need to add these properties so that EF will know that we want
        // a cascade delete rather than a restricted delete which means if the
        // user will be deleted, then photos associated with the user will also be deleted
        public Make Make { get; set; }
        public int MakeId { get; set; }
    }
}