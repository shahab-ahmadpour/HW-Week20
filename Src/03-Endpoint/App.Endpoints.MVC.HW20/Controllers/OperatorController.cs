using App.Domain.Core.Operators.AppService;
using App.Domain.Core.Request.AppService;
using App.Domain.Core.Request.Enums;
using App.Endpoints.MVC.HW20.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.HW20.Controllers
{
    public class OperatorController : Controller
    {
        private readonly IOperatorAppService _operatorAppService;
        private readonly IInspectionRequestAppService _requestAppService;

        public OperatorController(IOperatorAppService operatorAppService, IInspectionRequestAppService requestAppService)
        {
            _operatorAppService = operatorAppService;
            _requestAppService = requestAppService;
        }

        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var operators = _operatorAppService.GetAllOperators();
            var operatorEntity = operators.FirstOrDefault(op =>
                op.Username == model.Username && op.Password == model.Password);

            if (operatorEntity != null)
            {
                return RedirectToAction("Dashboard");
            }

            model.ErrorMessage = "نام کاربری یا رمز عبور اشتباه است.";
            return View(model);
        }


        public IActionResult Dashboard()
        {
            var requests = _requestAppService.GetAllRequests()
                .OrderBy(x => x.Date)
                .ToList();

            return View(requests);
        }

        [HttpPost]
        public IActionResult Approve(int id)
        {
            var request = _requestAppService.GetRequestDetails(id);
            if (request == null)
                return NotFound();

            request.Status = RequestStatus.Approved;
            _requestAppService.UpdateRequest(request);

            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            var request = _requestAppService.GetRequestDetails(id);
            if (request == null)
                return NotFound();

            request.Status = RequestStatus.Rejected;
            _requestAppService.UpdateRequest(request);

            return RedirectToAction("Dashboard");
        }
    }
}
