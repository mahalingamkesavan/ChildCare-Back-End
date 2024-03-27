using businessServicess.models.RequestModels.ChildCare;
using ChildCareBAL.Iservicess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChildCareAPI.Controllers
{
	[Authorize]
    public class ParentController : HomeController
	{
		private readonly IParentBAL _managementBAL;
		public ParentController(IParentBAL managementBAL) { _managementBAL = managementBAL; }

		///<summary>parent registration
		/// HttpPost method, which gets parents details as ParentRegistrationDTO from the user and insert it in the database
		///  On successful insertion it returns the parent id which is generated.*/
		/// <param name="model"></param>
		/// <returns></returns>
		
		[HttpPost]
		[Route("RegistrationParent")]
		public async Task<IActionResult> RegistrationParent([FromBody] Parent model)
		{
			return Ok(await _managementBAL.Add(model));
		}

		/// <summary>
		/// get parent profile by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// Summary:
		///HttpGet method, which gets parents Id from the user and fetch the details of the parent from the database
		///On successful fetching it returns the parent details.*/
		///
		
		[HttpGet]
        [Route("GetParendById")]
        public async Task<IActionResult> GetParendById(int id)
		{
			return Ok(await _managementBAL.GetParent(id));
		}

		/// <summary>
		/// get All parents
		/// </summary>
		/// <returns></returns>
		/// Summary:
		///*HttpGet method, which fetch the details of the  all parents from the database
		///On successful fetching it returns the parent details.*/
		
		[HttpGet]
		[Authorize(Roles = "Admin,Customer,User")]
		[Route("GetParentList")]
		public async Task<IActionResult> GetParendList(string request)
		{
			return Ok(await _managementBAL.GetParentList(request));
		}
		
		/// <summary>
		/// update parent profile
		/// </summary>
		/// <param name="parent"></param>
		/// <returns></returns>
		/// Summary:
		///*HttpPut method, which update the details of the parents from the database
		///On successful fetching it returns  the Message Response.*/
		
		[HttpPut]
		[Route("UpdateParentById")]
		public async Task<IActionResult> UpdateParentById(Parent parent)
		{
			return Ok(await _managementBAL.Update(parent));
		}
		
		/// <summary>
		/// Delete  Parent profile
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// Summary:
		///HttpPut method, which Delete the details of the parents from the database
		///On successful returns the Message Response.*/
		
		[HttpDelete]
		[Authorize(Roles = "Admin")]
		[Route("DeleteParentById")]
		public async Task<IActionResult> DeleteParentById(int id)
		{
			return Ok(await _managementBAL.DeleteParent(id));
		}
		
		[HttpGet]
		[Route("ParentProfile")]
		public async Task<IActionResult> GetParentProfile(string LoginUserName)
		{
			var data = await _managementBAL.GetParentProfile(LoginUserName);
			return Ok(data);
		}

	}
}
