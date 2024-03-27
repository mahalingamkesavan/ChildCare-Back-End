using ChildCareBAL.Iservicess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChildCareAPI.Controllers
{
    [Authorize]
    public class ParentChilldController : HomeController
    {
        private IParentBAL _managementBAL;
        public ParentChilldController(IParentBAL managementBAL) { _managementBAL = managementBAL; }

        // Summary:
        //     Creates a new HttpGet method In this method will be get the parent detail
        //     and the number of child and there details
        // Parameters:
        //   In this method will get the parent Id 
        //return:
        //   It return the parent and there child details

        [HttpGet("GetParentChildRelationship")]
        public async Task<IActionResult> GetParentChildRelationship(int id)
        {
            return Ok(await _managementBAL.GetParentChildRelationship(id));
        }
    }
}

