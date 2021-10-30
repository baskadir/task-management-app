using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.Business.Interfaces
{
    public interface IDutyService
    {
        Task<IEnumerable<Duty>> GetAllAsync();
        Task<IEnumerable<Duty>> GetAllByUsernameAsync(string userName);
        Task<IEnumerable<Duty>> GetAllCompletedByUsernameAsync(string userName);
        Task<Duty> CreateAsync(Duty duty);
        Task<Duty> GetByIdAsync(int id);
        Task CompleteDuty(int id);
    }
}
