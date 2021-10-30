using System.Collections.Generic;

namespace TaskManagement.Entities.Concrete
{
    public class Status : BaseEntity
    {
        public string Definition { get; set; }
        public ICollection<Duty> Duties { get; set; }
    }
}
