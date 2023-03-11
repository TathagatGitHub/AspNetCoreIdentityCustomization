using System;
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
using Newtonsoft.Json;
using System.Diagnostics;
using EFCore.BulkExtensions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreIdentityCustomization.Controllers
{
    public class PostLogController : Controller
    {
        // GET: /<controller>/
        private PostLogRepository _postlogrepository;
        private readonly ILogger<PostLogController> _logger;
        private readonly IConfiguration _config;
        private readonly ApplicationModelDbContext _dbContext;
        public PostLogController(IConfiguration configuration, ILogger<PostLogController> logger,
          PostLogRepository postLogRepository, ApplicationModelDbContext dbContext
       )
        {
            _config = configuration;
            _logger = logger;
            _postlogrepository = postLogRepository;
            _dbContext = dbContext;
          
        }

        
        public IActionResult Index()
        {
            //return View("PostLogList");
            //var data = _postlogrepository.GetPostLogList();
            //return Json(data);
            // IEnumerable <PostLog>  postlog= _postlogrepository.GetPostLogList();

            return View( );
        }
        public IActionResult IndexModel()
        {            
            var data = _postlogrepository.GetPostLogList();
          
            return View("IndexModel", data);
        }
        public IActionResult LoadPostlogList()
        {
            var data = _postlogrepository.GetPostLogList();

            //var res = _mtlService.GetMtlByWeekOf(weekOf).Result;
            // return new JsonResult(JsonConvert.SerializeObject(data.to));
            //return Json(data);
            //   return _postlogrepository.GetPostLogList();

            //return View("PostLogList", postlog);
            return Json(new { data = data.ToList(), success = true });
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

            
        }
        [HttpPost]
       // public IActionResult modelDatatableListPost([FromBody] List<PostLog> postlogs)
            public IActionResult modelDatatableListPost([FromBody] List<PostLog> postlogs)
        {

            //List <PostLog> postlogList = new List <PostLog>();
            Stopwatch BulkUpdateStopWatch = Stopwatch.StartNew();

          //  var listofIds = postlogs.Select(x => x.PostLogId).ToList();

        //    postlogList= _dbContext.PostLog.ToList();

            
            if (postlogs != null)
            {
                Console.WriteLine("Starting the Bulk Update Method");
                try
                {
                    _dbContext.BulkUpdate(postlogs);
                    //_dbContext.SaveChanges();
                    BulkUpdateStopWatch.Stop();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                    
              
                Console.WriteLine("Completing the Bulk Update Method elapsed time:"+ BulkUpdateStopWatch.ElapsedMilliseconds);
            }


            return new JsonResult(new { Status = "Success" });

        }
        //public IActionResult modelDatatableListPost(string postlogs)
        //{
        //    PostLog pl = new PostLog();
        //   // var obj = JsonConvert.DeserializeObject<List<PostLog>>(postlogObjList);
        //    foreach (var item in postlogs)
        //    {
        //        pl.ScheduleName = item.ScheduleName;
        //    }

        //     return new JsonResult(new { Status="Success" });
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
