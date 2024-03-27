using businessServicess.models.RequestModels.ChildCare;
using ChildCareBAL.Iservicess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChildCareAPI.Controllers
{
    [Authorize]
    public class ClassController : HomeController
    {
        private IClassBAL classBAL;
        public ClassController( IClassBAL classBAL) 
        {
           this.classBAL = classBAL;    
        }
        [HttpGet]
        [Route("GetClassList")]
        public async Task<IActionResult> GetClassName()
        {
            return Ok( await classBAL.GetClassList());
        }
        [HttpPost]
        [Route("Create-Class")]
        public async Task<IActionResult> CreateClass([FromBody] ClassList createclass)
        {
            return Ok( await classBAL.CreateClass(createclass) );
        }
    }
}
