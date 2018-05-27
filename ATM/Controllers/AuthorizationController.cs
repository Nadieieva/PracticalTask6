using System.Web.Mvc;
using System.Web.Security;
using ATM.Models;
using BankDb.DbServices;

namespace ATM.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly CardService _cardService = new CardService();
        
        // GET
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                if (_cardService.IsExists(signInModel.CardID, signInModel.PinCode))
                {
                    FormsAuthentication.SetAuthCookie(signInModel.CardID, false); 
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Incorrect input. Please try again");
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }
    }
}