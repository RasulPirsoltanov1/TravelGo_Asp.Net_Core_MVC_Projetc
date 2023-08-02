using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CustomerPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf_reports", "customer.pdf");
            using (var stream = new FileStream(path, FileMode.Create))
            {

                Document document = new iTextSharp.text.Document(PageSize.A4);
                document.Open();
                PdfPTable pdfPTable = new PdfPTable(2);
                pdfPTable.AddCell("name");
                pdfPTable.AddCell("Id");
                pdfPTable.AddCell("Rasul");
                pdfPTable.AddCell("1");
                document.Add(pdfPTable);
                document.Close();
            }
            return File(path, "application/pdf", "test.pdf");
        }
    }
}
