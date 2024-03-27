
using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Querys.QueryEnrollment;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerEnrollment
{
    public class GetEnrollmentByIdHandler : IRequestHandler<GetEnrollmentByIdQuery, ChildEnrollment>
    {
        private readonly IEntrollmentDAL entrollmentDAL;
        public GetEnrollmentByIdHandler(IEntrollmentDAL entrollmentDAL)
        {
            this.entrollmentDAL = entrollmentDAL;
        }

        public async Task<ChildEnrollment> Handle(GetEnrollmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await entrollmentDAL.Get(x => x.Id == request.Id);
        }
    }
}
