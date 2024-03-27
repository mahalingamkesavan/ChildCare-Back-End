using businessServicess.models.RequestModels.ChildCare;
using businessServicess.models.RequestModels.ChildCare.pagination;
using ChildCareBAL.Iservicess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChildCareAPI.Controllers
{
    [Authorize]

    public class EnrollmentController : HomeController
    {
        private readonly IEnrollmentBAL _entrollmentBAL;
        public EnrollmentController(IEnrollmentBAL entrollmentBAL) { _entrollmentBAL = entrollmentBAL; }
        [HttpPost]
        [AllowAnonymous]
        [Route("RegistrationEnrollment")]
        public async Task<IActionResult> RegistrationEnrollment([FromBody] EnrollmentRequest model)
        {
            return Ok(await _entrollmentBAL.Add(model));
        }
        [HttpGet]
        [Route("GetEnrollmentById")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            return Ok(await _entrollmentBAL.Get(id));
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Customer")]
        [Route("GetEnrollmentList")]
        public async Task<IActionResult> GetEnrollmentList(string request)
        {
            return Ok(await _entrollmentBAL.GetList(request));
        }
        [HttpPut]
        [Route("UpdateEnrollmentById")]
        public async Task<IActionResult> UpdateEnrollmentById([FromBody] EnrollmentRequest childEntrollment)
        {
            return Ok(await _entrollmentBAL.Update(childEntrollment));
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("DeleteEnrollmentById")]
        public async Task<IActionResult> DeleteEnrollemtById(int id)
        {
            return Ok(await _entrollmentBAL.Delete(id));
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("EnrollmentApproval_Admin")]
        public async Task<IActionResult> AddmissionApproval([FromBody] EnrollmentApprovedRequest childEntrollment)
        {
            return Ok(await _entrollmentBAL.AddmissionApproval(childEntrollment));
        }
        [HttpGet]
        [Route("AdmissionApprovalPending")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdmissionApprovalpending()
        {
            return Ok(await _entrollmentBAL.AdmissionApprovalpending());
        }
        [HttpGet]
        [Route("AdmissionApprovallList")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdmissionApprovallList()
        {
            return Ok(await _entrollmentBAL.AdmissionApprovallList());
        }
        [HttpGet]
        [Route("AdmissionRejectedList")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdmissionRejectedlList()
        {
            return Ok(await _entrollmentBAL.AdmissionRejectedlList());
        }
        [HttpGet]
        [Route("GetActiveChild")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetActiveChild()
        {
            return Ok(await _entrollmentBAL.GetActiveChild("null"));
        }
        [HttpGet]
        [Route("GetActiveChildCount")]
        [AllowAnonymous]
        public async Task<IActionResult> GetActiveChildCount()
        {
            return Ok(await _entrollmentBAL.GetActiveChildCount());
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("GetChildProfileandParent")]
        public async Task<IActionResult> GetChildProfileandAddmissionDetails([FromQuery] Paginationparameter paginationparameter)
        {
            return Ok(await _entrollmentBAL.GetChildren(paginationparameter));
        }
    }
}
