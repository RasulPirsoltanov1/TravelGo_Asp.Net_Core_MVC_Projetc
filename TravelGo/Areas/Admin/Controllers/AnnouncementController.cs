using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
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
            List<AnnouncementAddDTO> announcementAddDTOs = _mapper.Map<List<AnnouncementAddDTO>>(announcements);
            return View(announcementAddDTOs);
        }
    }
}
