﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentityCustomization.Core;
using AspNetCoreIdentityCustomization.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Security.Cryptography;
using System.Threading;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreIdentityCustomization.Controllers
{
    public class PostLogController : Controller
    {
        // GET: /<controller>/
        private PostLogRepository _postlogrepository;
        private readonly ILogger<PostLogController> _logger;
        private readonly IConfiguration _config;

        public PostLogController(IConfiguration configuration, ILogger<PostLogController> logger,
          PostLogRepository postLogRepository
       )
        {
            _config = configuration;
            _logger = logger;
            _postlogrepository = postLogRepository;
          
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {

            List<SelectListItem> SchedId = new List<SelectListItem>()
            {
                new SelectListItem() { Value="1",Text="Alabama"},
                new SelectListItem() {Value = "2",Text ="West Virginia"}

            };




            ViewBag.SchedId = SchedId;
            return View();

            //return View();

            
        }
        [HttpPost]
        //public ActionResult Create(PostLog postLogModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _postlogrepository.InsertPostLog(postLogModel);
               
        //    }

            

        //    return View();
        //}
        // POST: PostLog2/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            Thread.Sleep(3000);
            try
            {
                var postLog = new PostLog();
                System.Random random = new System.Random();
                postLog.PostLogId = random.Next();
                postLog.SchedId = Int32.Parse(collection["SchedId"]);

                postLog.ScheduleName = collection["ScheduleName"];
                postLog.WeekNbr = Int32.Parse(collection["WeekNbr"]);
                //DateTime.TryParseExact(validDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                postLog.WeekDate = DateTime.ParseExact(collection["WeekDate"], "yyyy-mm-dd", CultureInfo.InvariantCulture); 
                postLog.CreateDt = DateTime.ParseExact(collection["CreateDt"], "yyyy-mm-dd", CultureInfo.InvariantCulture); 
                postLog.UpdateDt = DateTime.ParseExact(collection["UpdateDt"], "yyyy-mm-dd", CultureInfo.InvariantCulture); 

                _postlogrepository.InsertPostLog(postLog);

                // return RedirectToAction(nameof(Index));
                //return JSONObject.quote("Hello World");
                //   return View(new JsonResult("Hello World"));
                ViewBag.IsSuccess =true;
                return Json(new
                {
                    success = true,
                    recordsTotal = 1,
                    recordsFiltered = 1,
                    data = postLog,
                    responseText = "Sucess",
                    responseCode = 0
                });
            }
            catch (Exception exc)
            {
                return Json(new
                {
                    success = false,
                    responseText = "Failure",
                    responseCode = -1
                });
            }
        }
    }
}