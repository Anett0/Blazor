using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities
{
    public class Hotel : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Addres { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; } = "/img/hotels/no_photo.jpg";
        public string? Latitude {  get; set; }
        public string? Longitude {  get; set; }

        public virtual ICollection<Service> Services { get; set; } = new HashSet<Service>();
        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
