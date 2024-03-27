using businessServicess.models.RequestModels.ChildCare;
using ChildCareBAL.Iservicess;
using ChildCareDAL.Commands.FileCommands;
using ChildCareDAL.Querys.GetFileQuery;
using ChildCareDAL.Repositories.IRepositories;

using MediatR;


#nullable disable
namespace ChildCareBAL.Implimentation
{
    public class FileBAL : IFileBAL
    {
        private readonly IMediator _mediator; 

        public FileBAL(IMediator mediator, IFileDAL fileDAL, IEntrollmentDAL entrollmentDAL)
        {
            _mediator = mediator;
        }
        public async Task<bool> PostFileAsync(FileUploadModel fileData)
        {
            /*var enrollmentdata = await _mediator.Send(new GetEnrollmentListQuery());

            var GetEnrollmentID = enrollmentdata.OrderByDescending(x => x.Id).FirstOrDefault().Id;*/

            var fileDetails = new FileDetails()
            {
                FileName = fileData.FileDetails.FileName,
                EnrollmentId = fileData.EnrollmentId
            };
            using (var stream = new MemoryStream())
            {
                fileData.FileDetails.CopyTo(stream);
                fileDetails.FileData = stream.ToArray();
            }
            var data = await _mediator.Send(new SaveEnrollmentFileCommands(fileDetails));

            return true;
        }
        public async Task<(Stream, string)> DownloadFileById(int Id)
        {
            var file = await _mediator.Send(new GetEnrollmentFileByIdQuery { Id = Id });

            if (file == null) return (null, null);

            var content = new System.IO.MemoryStream(file.FileData);


            return (content, file.FileName);
        }


        




    }
}
