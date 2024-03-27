using businessServicess.models.RequestModels.auth;
using businessServicess.models.RequestModels.ChildCare;
using ChildCareBAL.Iservicess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChildCareAPI.Controllers
{
    [Authorize]
    public class FilesController : HomeController
    {
        private readonly IFileBAL _fileBAL;
        public FilesController(IFileBAL fileBAL) { _fileBAL = fileBAL; }
        /// <summary>
        /// Single File Upload
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("PostFile")]
        public async Task<ActionResult> PostSingleFile([FromForm] FileUploadModel fileDetails)
        {
            if (fileDetails.FileDetails == null && fileDetails.EnrollmentId == 0)
            {
                return BadRequest(new Response { Status = "Fail", message = "Upload the File!" });
            }

            var Isvalaid = await _fileBAL.PostFileAsync(fileDetails);

            return Ok(new Response { Status = "Success", message = "File Upload successfully!" });
        }
        /// <summary>
        /// Download File
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(int id)
        {
            if (id < 1)
            return BadRequest(new Response { Status = "Fail", message = "Enter Currect Entroll Id!" }); 

            var data = await _fileBAL.DownloadFileById(id);

            if (data.Item1 == null && data.Item2 == null) return NotFound(new Response { Status = "Fail", message = "Enrollment Id Not Found !!" });

            else return File(data.Item1,"jpg/plain", data.Item2);
         
        }

       
    }
}
