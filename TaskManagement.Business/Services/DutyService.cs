using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Business.Interfaces;
using TaskManagement.DataAccess.UnitOfWork;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.Business.Services
{
    public class DutyService : IDutyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DutyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Duty> CreateAsync(Duty duty)
        {
            await _unitOfWork.GetRepository<Duty>().Create(duty);
            await _unitOfWork.CommitAsync();
            return duty;
        }

        public async Task<IEnumerable<Duty>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Duty>().GetAllAsync();
        }

        public async Task<IEnumerable<Duty>> GetAllByUsernameAsync(string userName)
        {
            return await _unitOfWork.GetRepository<Duty>().GetAllAsync(x => x.AppUser.UserName == userName);
        }

        public async Task<IEnumerable<Duty>> GetAllCompletedByUsernameAsync(string userName)
        {
            return await _unitOfWork.GetRepository<Duty>().GetAllAsync(x => x.AppUser.UserName == userName && x.IsCompleted);
        }

        public async Task<Duty> GetByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Duty>().GetByFilterAsync(x=>x.Id == id);
        }

        public async Task CompleteDuty(int id)
        {
            var unchanged = await _unitOfWork.GetRepository<Duty>().FindAsync(id);
            unchanged.IsCompleted = true;
            unchanged.StatusId = 3; // tamamlandı
            _unitOfWork.GetRepository<Duty>().Update(unchanged);
            await _unitOfWork.CommitAsync();
        }
    }
}
