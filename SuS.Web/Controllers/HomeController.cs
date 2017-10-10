using SuS.Data.Models;
using SuS.Service.MemberServices;
using SuS.Web.ViewModels;
using System;
using System.Web.Mvc;

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

            Home newHome = AddNewHomeViewModel.ConvertToHomeModel(model.BuyerNames, model.Address, model.LotNumber, model.Notes, model.PurchasePrice);

            return View("_ApproveHomeModel", newHome);
        }

        [HttpGet]
        public ActionResult ApproveModel(Home model)
        {
            return View();
        }
    }
}