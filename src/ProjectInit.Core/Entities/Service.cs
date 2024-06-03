using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities
{
    public class Service : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Amount { get; set; }

        public Guid? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
