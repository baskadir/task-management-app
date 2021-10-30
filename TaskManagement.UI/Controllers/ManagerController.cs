using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagement.Business.Interfaces;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.UI.Controllers
{
    [Authorize(Roles ="Manager")]
    public class ManagerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDutyService _dutyService;
        private readonly IEmailService _emailService;
        public ManagerController(UserManager<AppUser> userManager, IDutyService dutyService, IEmailService emailService)
        {
            _userManager = userManager;
            _dutyService = dutyService;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dutyService.GetAllAsync());
        }

        public async Task<IActionResult> GetAllPersonelsJson()
        {
            var personels = await _userManager.GetUsersInRoleAsync("Personel");
            return Json(personels);
        }

        public IActionResult CreateDuty()
        {
            return View(new Duty());
        }

        [HttpPost]
        public async Task<IActionResult> CreateDuty(Duty duty)
        {
            var data = await _dutyService.CreateAsync(duty);
            var personel = await _userManager.FindByIdAsync(data.AppUserId.ToString());
            string message = $"{personel.FirstName} sana {data.Title} adında yeni bir görev eklendi.";
            _emailService.SendEmail(personel.Email, "Personel", message);
            return RedirectToAction("Index");
        }
    }
}
