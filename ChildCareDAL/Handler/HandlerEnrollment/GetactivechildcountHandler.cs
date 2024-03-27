using ChildCareDAL.Querys.QueryEnrollment;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerEnrollment
{
    public class GetactivechildcountHandler : IRequestHandler<Getactivechildcountquery, int>
    {
        private readonly IEntrollmentDAL _entrollmentDAL;
        public GetactivechildcountHandler(IEntrollmentDAL entrollmentDAL) { this._entrollmentDAL = entrollmentDAL; }
        public async Task<int> Handle(Getactivechildcountquery request, CancellationToken cancellationToken)
        {
            var data = await _entrollmentDAL.ChildProfiles();

            return data.Count();
        }
    }
}
