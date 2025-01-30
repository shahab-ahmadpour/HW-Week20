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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var operators = await _operatorAppService.GetAllOperatorsAsync();
            var operatorEntity = operators.FirstOrDefault(op =>
                op.Username == model.Username && op.Password == model.Password);

            if (operatorEntity != null)
            {
                return RedirectToAction("Dashboard");
            }

            model.ErrorMessage = "نام کاربری یا رمز عبور اشتباه است.";
            return View(model);
        }

        public async Task<IActionResult> Dashboard()
        {
            var requests = await _requestAppService.GetAllRequestsAsync();
            var sortedRequests = requests.OrderBy(x => x.Date).ToList();

            return View(sortedRequests);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            var request = await _requestAppService.GetRequestDetailsAsync(id);
            if (request == null)
                return NotFound();

            request.Status = RequestStatus.Approved;
            await _requestAppService.UpdateRequestAsync(request);

            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> Reject(int id)
        {
            var request = await _requestAppService.GetRequestDetailsAsync(id);
            if (request == null)
                return NotFound();

            request.Status = RequestStatus.Rejected;
            await _requestAppService.UpdateRequestAsync(request);

            return RedirectToAction("Dashboard");
        }
    }
}