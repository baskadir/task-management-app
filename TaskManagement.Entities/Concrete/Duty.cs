using System;
using System.Collections.Generic;

namespace TaskManagement.Entities.Concrete
{
    public class Duty : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsImportant { get; set; }
        public bool IsCompleted { get; set; }
        public int? StatusId { get; set; }
        public Status Status { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public IEnumerable<Document> Documents { get; set; }
    }
}
