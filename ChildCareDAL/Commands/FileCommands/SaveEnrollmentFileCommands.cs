using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Commands.FileCommands
{
    public class SaveEnrollmentFileCommands : IRequest<(bool, FileDetails)>
    {
        public FileDetails fileDetails { get; set; }
        public SaveEnrollmentFileCommands(FileDetails fileDetails)
        {
            this.fileDetails = fileDetails;
        }
    }
}
