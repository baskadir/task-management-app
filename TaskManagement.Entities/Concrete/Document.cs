using System;
using System.Collections.Generic;

namespace TaskManagement.Entities.Concrete
{
    public class Document : BaseEntity
    {
        public string Definition { get; set; }
        public string DocumentPath { get; set; }
        public int DutyId { get; set; }
        public Duty Duty { get; set; }
    }
}
