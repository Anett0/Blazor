using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities
{
    public class Review : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double? Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime? Created { get; set; }
        public string? UserName { get; set; }

        public Guid? HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }

        public virtual ICollection<Service> Services { get; set; } = new HashSet<Service>();
    }
}
