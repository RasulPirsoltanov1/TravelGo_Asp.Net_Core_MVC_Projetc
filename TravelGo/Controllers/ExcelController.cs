using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Utilities;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TravelGo.Models;

namespace TravelGo.Controllers
{
    public class ExcelController : Controller
    {
        IDestinationService destinationService;
        IExcelService _excelService;
        public ExcelController(IDestinationService destinationService, IExcelService excelService)
        {
            this.destinationService = destinationService;
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public List<DestinationModel> DestinationList()
        {
            return destinationService.TGetList().Select(d => new DestinationModel
            {
                Capacity = d.Capacity,
                City = d.City,
                DayNight = d.DayNight,
                Price = d.Price
            }).ToList();
        }
        public IActionResult DestinationExcelReport()
        {
            var content = _excelService.DestinationExcelLis(DestinationList());

            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "New_List.xlsx");
        }
    }
}
