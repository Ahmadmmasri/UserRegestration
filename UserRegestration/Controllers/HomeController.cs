using UserRegestration.Context;
using UserRegestration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserRegestration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UserRegestration.Reposotries;

namespace UserRegestration.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _dbContext;
        private readonly IRegRepo _RegRepo;

        public HomeController(MyDbContext dbcontext, IRegRepo RegRepo)
        {
            this._dbContext = dbcontext;
            this._RegRepo = RegRepo;
        }

        [HttpGet]
        public ActionResult Index()
        {

            modeslLIst vm = new modeslLIst();
            vm.offer = _RegRepo.GetAllOffer();
            vm.service = _RegRepo.GetAllService();
            ViewBag.sucessmessage = "";

            return View(vm);
        }

        [HttpPost]
        public void Temprory(int id,string value)
        {
            if(value.ToLower().StartsWith("o"))
            {
                TempData["offerValue"]= id;
            }
            else if(value.ToLower().StartsWith("s"))
            {
                TempData["ServiceValue"] = id;
            }
        }

        [HttpPost]
        public ActionResult Add(Regerstation colleation)
        {

            colleation.OfferId = Convert.ToInt32(TempData["offerValue"].ToString());
            colleation.ServiceId = Convert.ToInt32(TempData["ServiceValue"].ToString());
            colleation.RegestrationDate = DateTime.Now;

            _RegRepo.Create(colleation);
            _RegRepo.SendEmail(colleation.userEmail,colleation.userNumber, colleation.userName, colleation.OfferId.ToString(), colleation.ServiceId.ToString());
            return RedirectToAction("Index");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
