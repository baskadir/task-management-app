using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Business.Interfaces;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.UI.Controllers
{
    [Authorize(Roles ="Personel")]
    public class PersonelController : Controller
    {
        private readonly IDutyService _dutyService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        public PersonelController(IDutyService dutyService, UserManager<AppUser> userManager, IEmailService emailService)
        {
            _dutyService = dutyService;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            string userName = User.Identity.Name;
            var duties = await _dutyService.GetAllByUsernameAsync(userName);
            return View(duties);
        }

        public async Task<IActionResult> GetCompletedDuties()
        {
            string userName = User.Identity.Name;
            return View(await _dutyService.GetAllCompletedByUsernameAsync(userName));
        }

        public async Task<IActionResult> CompleteDuty(int id)
        {
            await _dutyService.CompleteDuty(id);
            var manager = (await _userManager.GetUsersInRoleAsync("Manager")).SingleOrDefault(x => x.Id == 1);
            var completedDuty = await _dutyService.GetByIdAsync(id);
            var message = $"{completedDuty.Title} adlı görev {User.Identity.Name} tarafından tamamlandı";
            _emailService.SendEmail(manager.Email, "Manager", message);
            return Json("ok");
        }
    }
}
