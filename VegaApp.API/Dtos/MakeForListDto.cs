using System.Collections.Generic;
using VegaApp.API.Models;

namespace VegaApp.API.Dtos
{
    public class MakeForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ModelForDetailDto> Models { get; set; }
    }
}