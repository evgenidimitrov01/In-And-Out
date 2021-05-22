using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut_2.Controllers
{
    public class ReturnTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OkResult()
        {
            return Ok();
        }

        public IActionResult CreatedResult()
        {
            return Created("http://example.org/myitem", new { name = "newitem" });
        }

        public IActionResult NoContent()
        {
            return NoContent();
        }

        public IActionResult BadRequestResult()
        {
            return BadRequest();
        }

        public IActionResult Unathorized()
        {
            return Unathorized();
        }

        public IActionResult NotFound()
        {
            return NotFound();
        }

        public IActionResult UnsupportedMediaTypeRes()
        {
            return new UnsupportedMediaTypeResult();
        }


        ///////////////////
        ///

        public IActionResult OkObjectResult()
        {
            var result = new OkObjectResult(new { message = "200 OK", currentDate = DateTime.Now });
            return result;
        }

        public IActionResult CreatedObjectResult()
        {
            var result = new CreatedAtActionResult("createdobjectresult",
                "statuscodeobjects", "",
                new { message = "201 Created", currentDate = DateTime.Now });
            return result;
        }

        public IActionResult BadRequestObjectResult()
        {
            var result = new BadRequestObjectResult(new {
                message = "400 Bad Request", currentDate = DateTime.Now
            });
            return result;
        }

        public IActionResult NotFoundObjectResult()
        {
            var result = new NotFoundObjectResult(new
            {
                message = "404 Not Found",
                currentDate = DateTime.Now
            });
            return result;
        }

        /////////////////////////////
        ///

        public IActionResult RedirectResult()
        {
            return Redirect("https://www.google.com");
        }

        public IActionResult LocalRedirectResult()
        {
            return LocalRedirect("/redirects/target");
        }

        public IActionResult RedirectToActionResult()
        {
            return RedirectToAction("target", "appointment");
        }

        public IActionResult FileResult()
        {
            return File("~/downloads/pdf-sample.pdf", "application/pdf");
        }

        public IActionResult FileContentResult()
        {
            var pdfBytes = System.IO.File.ReadAllBytes("wwwrootdownloads/pdf-sample.pdf");

            return new FileContentResult(pdfBytes, "application/pdf");
        }

        public IActionResult VirtualFileResult()
        {
            return new VirtualFileResult("/downloads/pdf-sample.pdf", "application/pdf");
        }
        public IActionResult PhysicalFileResult()
        {
            // _IhostingEnviroment.ContentRootPath
            return new PhysicalFileResult("wwwroot/downloads/pdf-sample.pdf", "application/pdf");
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult PartialViewResult()
        {
            return PartialView();
        }

        public IActionResult JsonResult()
        {
            return Json(new { message = "This is a JSON result", date = DateTime.Now });
        }

        public IActionResult ContentResult()
        {
            return Content("Some Content");
        }

    }
}
