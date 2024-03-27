
using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Querys.GetFileQuery
{
    public class GetEnrollmentFileByIdQuery : IRequest<FileDetails>
    {
        public int Id { get; set; }
    }
}
