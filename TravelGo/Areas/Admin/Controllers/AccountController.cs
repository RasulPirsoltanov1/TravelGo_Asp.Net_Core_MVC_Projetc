using BusinessLayer.Abstract.UnitOfWork;
using DTOLayer.DTOs.Account;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class AccountController : Controller
    {
        IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        public IActionResult Index()
        {
            ViewBag.Success = true;
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountDTO accountAddDTO)
        {
            try
            {
                Account accountSender = _accountService.TGetById(accountAddDTO.SenderId);
                Account accountReceiver = _accountService.TGetById(accountAddDTO.ReceiverId);
                accountSender.Balance = accountSender.Balance - accountAddDTO.Amount;
                accountReceiver.Balance = accountReceiver.Balance + accountAddDTO.Amount;
                _accountService.TMultiUpdate(new List<Account> { accountSender, accountReceiver });
                ViewBag.Success = true;
            }
            catch (Exception)
            {
                ViewBag.Success = false;
                return View();
            }
            return View();
        }
    }
}
