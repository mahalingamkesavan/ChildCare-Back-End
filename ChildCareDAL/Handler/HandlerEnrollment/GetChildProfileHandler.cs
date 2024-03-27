using businessServicess.models.ResponseModel;
using ChildCareDAL.Querys.QueryEnrollment;
using ChildCareDAL.Repositories.IRepositories;
using ChildCareUtility;
using MediatR;
using businessServicess.models.RequestModels.ChildCare.pagination;

#nullable disable

namespace ChildCareDAL.Handler.HandlerEnrollment
{
    public class GetChildProfileHandler : IRequestHandler<GetCHildProfileQuery, List<ChildProfileDTO>>
    {
        private readonly IEntrollmentDAL _entrollmentDAL;
        public GetChildProfileHandler(IEntrollmentDAL entrollmentDAL) { this._entrollmentDAL = entrollmentDAL; }

        public async Task<List<ChildProfileDTO>> Handle(GetCHildProfileQuery request, CancellationToken cancellationToken)
        {
            if (request.paginationparameter.request == null || request.paginationparameter.request == ConstantVariables.nullabletype)
            {
                var Getchildran = await _entrollmentDAL.ChildProfiles(null);

                var paginationmetadata = new paginationmetadata(Getchildran.Count(), request.paginationparameter.page, request.paginationparameter.ItemsPerPage);

                var data = Getchildran
                      .Skip((request.paginationparameter.page - 1) * request.paginationparameter.ItemsPerPage)
                      .Take(request.paginationparameter.ItemsPerPage)
                      .ToList();

                return data;
            }


            return await (int.TryParse(request.paginationparameter.request, out int value) ? _entrollmentDAL.ChildProfiles(x => x.ChildId == value) : _entrollmentDAL.ChildProfiles(x => x.ChildFirstName.StartsWith(request.paginationparameter.request)));
        }
    }
}
