using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Infrastructure.DTOs
{
    public class PetDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? ImagePath { get; set; } = "/img/hotels/no_photo.jpg";
        public string? Status { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
    public class PetCreateDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; } = "/img/hotels/no_photo.jpg";
        public string Status { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
    public class PetUpdateDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? ImagePath { get; set; } = "/img/hotels/no_photo.jpg";
        public string? Status { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
