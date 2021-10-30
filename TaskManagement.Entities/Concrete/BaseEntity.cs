using System;

namespace TaskManagement.Entities.Concrete
{
    public class BaseEntity 
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
