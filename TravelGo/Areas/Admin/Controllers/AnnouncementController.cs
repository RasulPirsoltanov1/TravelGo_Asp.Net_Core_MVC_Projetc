using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]")]
    public class AnnouncementController : Controller
    {
        IAnnouncementService _announcementService { get; set; }
        IMapper _mapper { get; set; }

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var announcements = _announcementService.TGetList();
            List<AnnouncementListDTO> announcementAddDTOs = _mapper.Map<List<AnnouncementListDTO>>(announcements);
            return View(announcementAddDTOs);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AnnouncementAddDTO announcementAddDTO)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TAdd(_mapper.Map<Announcement>(announcementAddDTO));
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            _announcementService.TDelete(_announcementService.TGetById(id));
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            return View(_mapper.Map<AnnouncementAddDTO>(_announcementService.TGetById(id)));
        }
        [HttpPost]
        public IActionResult Update(AnnouncementAddDTO announcementAddDTO)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(_mapper.Map<Announcement>(announcementAddDTO));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
