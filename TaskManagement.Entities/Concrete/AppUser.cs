using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TaskManagement.Entities.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Duty> Duties { get; set; }
    }
}
