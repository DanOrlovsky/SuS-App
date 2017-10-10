using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuS.Service.FileServices;
using SuS.Service.MemberServices;
using SuS.Web.ViewModels;
using SuS.Data.Models;

namespace SuS.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(!RoleActions.RoleExists(RoleActions.SuperUserRole))
            {
                return RedirectToAction("Install", "Install");
            }
            return View();
        }


        public ActionResult AddNewHome()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewHome([Bind(Include = "BuyerNames,Address,LotNumber,Notes,PurchasePrice")]AddNewHomeViewModel model)
        {
            if(!ModelState.IsValid)
            {
                throw new Exception("Model not complete");
            }
            Home newHome = new Home();
            newHome.Address = model.Address;
            newHome.BuyerNames = model.BuyerNames;
            newHome.LotNumber = model.LotNumber;
            newHome.Notes = model.Notes;
            newHome.PurchasePrice = model.PurchasePrice;

            return View("_ApproveHomeModel", newHome);
        }
    }
}