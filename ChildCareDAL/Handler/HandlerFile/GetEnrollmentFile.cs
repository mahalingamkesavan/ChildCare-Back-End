using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Querys.GetFileQuery;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerFile
{
    public class GetEnrollmentFile : IRequestHandler<GetEnrollmentFileByIdQuery, FileDetails>
    {
        private readonly IFileDAL fileDAL;
        public GetEnrollmentFile(IFileDAL fileDAL)
        {
            this.fileDAL = fileDAL;
        }

        public Task<FileDetails> Handle(GetEnrollmentFileByIdQuery request, CancellationToken cancellationToken)
        {
            return fileDAL.Get(x => x.ID == request.Id);
        }
    }
}
