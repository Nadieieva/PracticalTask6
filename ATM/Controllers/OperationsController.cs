using System;
using System.Web.Mvc;
using ATM.Models;
using BankDb.DbServices;
using WebGrease.Css.Ast.Selectors;

namespace ATM.Controllers
{
    [Authorize]
    public class OperationsController : Controller
    {
        private readonly CardService _cardService = new CardService();
        private readonly OperationService _operationService = new OperationService();
        
        // GET
        public ActionResult Index()
        {
            var operations = _operationService.AllOperations(User.Identity.Name);
            var operationIndexModel = new OperationIndexModel
            {
                operations = operations
            };
            return View(operationIndexModel);
        }

        public ActionResult WithdrawFunds()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WithdrawFunds(WithdrawFundsModel withdrawFundsModel)
        {
            if (ModelState.IsValid)
            {
                var cardId = User.Identity.Name;
                var cardBalance = _cardService.GetBalance(cardId);
                var amount = Convert.ToDecimal(withdrawFundsModel.Amount.Replace(".", ","));
                if (amount <= cardBalance)
                {
                    _operationService.WithdrawFunds(cardId, amount);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", String.Format("Sorry, you don't have enough money. Balance: {0}", cardBalance));
            }

            return View();
        }
    }
}