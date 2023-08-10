using DTOLayer.DTOs.RoleDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelGo.ViewComponents.Default;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]")]
    public class RoleController : Controller
    {
        private RoleManager<AppRole> _roleManager;
        private UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateRoleDTO createRoleDTO)
        {
            AppRole appRole = new AppRole()
            {
                Name = createRoleDTO.Name,
            };
            await _roleManager.CreateAsync(appRole);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role != null)
                await _roleManager.DeleteAsync(role);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role != null)
                return View(new UpdateRoleDTO
                {
                    Name = role.Name,
                });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateRoleDTO updateRoleDTO)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == updateRoleDTO.Id);
            if (role != null)
            {
                role.Name = updateRoleDTO.Name;
                await _roleManager.UpdateAsync(role);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UserAssignRoleList()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> RoleAssign(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            TempData["id"] = user.Id;
            if (user != null)
            {
                var roles = _roleManager.Roles.ToList();
                var userRoles = await _userManager.GetRolesAsync(user);
                List<RoleAssignDTO> roleAssignDTO = new List<RoleAssignDTO>();
                foreach (var item in roles)
                {
                    RoleAssignDTO newRoleAssignDTO = new RoleAssignDTO();
                    newRoleAssignDTO.RoleId = item.Id;
                    newRoleAssignDTO.RoleName = item.Name;
                    newRoleAssignDTO.RoleExists = userRoles.Contains(item.Name);
                    roleAssignDTO.Add(newRoleAssignDTO);
                }

                return View(roleAssignDTO);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RoleAssign(List<RoleAssignDTO> roleAssignDTOs)
        {
            var userId = (int)TempData["id"];
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == 12);
            if (user != null)
            {
                foreach (var item in roleAssignDTOs)
                {
                    if (item.RoleExists)
                    {
                        await _userManager.AddToRoleAsync(user, item.RoleName);
                    }
                    else
                    {
                        await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }

}
