using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Querys.QueryEnrollment;
using ChildCareDAL.Repositories.IRepositories;
using ChildCareUtility;
using MediatR;

namespace ChildCareDAL.Handler.HandlerEnrollment
{
    public class GetEnrollmentListHandler : IRequestHandler<GetEnrollmentListQuery, List<ChildEnrollment>>
    {
        private readonly IEntrollmentDAL _entrollmentDAL;
        public GetEnrollmentListHandler(IEntrollmentDAL entrollmentDAL) { this._entrollmentDAL = entrollmentDAL; }

        public async Task<List<ChildEnrollment>> Handle(GetEnrollmentListQuery request, CancellationToken cancellationToken)
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            if (request.request == null || request.request == ConstantVariables.nullabletype) return await _entrollmentDAL.GetList(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            else if (request.request == ConstantVariables.Approved || request.request == ConstantVariables.Rejected)

                return await _entrollmentDAL.GetList(x => x.AdmissionStatus == request.request);

            if (request.request == ConstantVariables.AdmissionApprovalpending)

                return await _entrollmentDAL.GetList(x => x.AdmissionStatus == null);

            return await (int.TryParse(request.request, out int value) ? _entrollmentDAL.GetList(x => x.Id == value) : _entrollmentDAL.GetList(x => x.Classname.StartsWith(request.request)));
        }
    }
}
