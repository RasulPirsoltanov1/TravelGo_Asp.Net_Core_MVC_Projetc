using BusinessLayer.Abstract;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TravelGo.Models;

namespace TravelGo.Controllers
{
    public class ExcelController : Controller
    {
        IDestinationService destinationService;

        public ExcelController(IDestinationService destinationService)
        {
            this.destinationService = destinationService;
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
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Tour List");
                workSheet.Cell(1, 1).Value = "City";
                workSheet.Cell(1, 2).Value = "Day & Night";
                workSheet.Cell(1, 3).Value = "Price";
                workSheet.Cell(1, 4).Value = "Capacity";
                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","New_List.xlsx");
                }
            }
        }
    }
}
