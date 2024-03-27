using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Commands.FileCommands;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerFile
{
    public class SaveEnrollFileHandler : IRequestHandler<SaveEnrollmentFileCommands, (bool, FileDetails)>
    {
        private readonly IFileDAL fileDAL;
        public SaveEnrollFileHandler(IFileDAL fileDAL)
        {
            this.fileDAL = fileDAL;
        }

        public Task<(bool, FileDetails)> Handle(SaveEnrollmentFileCommands request, CancellationToken cancellationToken)
        {
            return fileDAL.Add(request.fileDetails);
        }
    }
}
