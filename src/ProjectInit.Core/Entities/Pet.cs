using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities
{
    public class Pet : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? ImagePath { get; set; } = "/img/hotels/no_photo.jpg";
        public string? Status { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
