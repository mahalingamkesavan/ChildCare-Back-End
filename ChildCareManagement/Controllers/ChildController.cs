using businessServicess.models.RequestModels.ChildCare;
using ChildCareBAL.Iservicess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChildCareAPI.Controllers
{

    [Authorize]
    public class ChildController : HomeController
    {
        private readonly IChildBAL _childBAL;
        // DI
        public ChildController(IChildBAL childBAL) { _childBAL = childBAL; }
        ///<summary>Child registration
        /// HttpPost method, which gets Child details as Child from the user and insert it in the database
        ///  On successful insertion it returns the Child id which is generated.*/
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RegistrationChild")]
        public async Task<IActionResult> RegistrationChild([FromBody] ChildRequest model)
        {
            return Ok(await _childBAL.Add(model));
        }
        /// <summary>
        /// get Child profile by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Summary:
        ///HttpGet method, which gets Child Id from the user and fetch the details of the Child from the database
        ///On successful fetching it returns the Child details.*/
        [HttpGet]
        [Route("GetChildById")]
        public async Task<IActionResult> GetChildById(int id)
        {
            return Ok(await _childBAL.GetChild(id));
        }
        /// <summary>
        /// get All Child
        /// </summary>
        /// <returns></returns>
        /// Summary:
        ///HttpGet method, which fetch the details of the  all Child from the database
        ///On successful fetching it returns the Child details.*/
        [HttpGet]
        [Route("GetChildList")]
        [Authorize(Roles = "Admin,Customer,User")]
        public async Task<IActionResult> GetChilList([FromQuery] string requestItem)
        {
            return Ok(await _childBAL.GetChildList(requestItem));
        }
        /// <summary>
        /// update Child profile
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        /// Summary:
        ///*HttpPut method, which update the details of the Child from the database
        /// On successful fetching it returns the Message Response.*/
        [HttpPut]
        [Route("UpdateChildById")]
        public async Task<IActionResult> UpdateChildById(Child child)
        {
            return Ok(await _childBAL.Update(child));
        }
        /// <summary>
        /// Delete  Parent profile
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Summary:
        ///*HttpPut method, which Delete the details of the Child from the database
        ///On successful returns the Message Response.*/

        [HttpDelete]
        [Route("DeleteChildById")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteChildById(int id)
        {
            return Ok(await _childBAL.DeleteChild(id));
        }
    }
}
