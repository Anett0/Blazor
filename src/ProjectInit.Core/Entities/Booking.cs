using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities
{
    public class Booking : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? TotalAmount { get; set; }
        public string? Status { get; set; }

        public Guid? PetId { get; set; }
        public List<Pet>? Pet { get; set; }

        public virtual ICollection<Service> Services { get; set; } = new HashSet<Service>();
        public virtual ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();

        public Guid? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}
