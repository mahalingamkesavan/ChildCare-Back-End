using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Querys.QueryParent;
using ChildCareDAL.Repositories.IRepositories;
using ChildCareUtility;
using MediatR;

namespace ChildCareDAL.Handler.HandlerParent
{
    public class GetParentListHandler : IRequestHandler<GetParentListQuery, List<Parent>>
    {
        private readonly IParentDAL _parentDAL;
        public GetParentListHandler(IParentDAL parentDAL) { _parentDAL = parentDAL; }

        public async Task<List<Parent>> Handle(GetParentListQuery request, CancellationToken cancellationToken)
        {
            if (request.request == null || request.request == ConstantVariables.nullabletype) return await _parentDAL.GetList(null);

            return await (int.TryParse(request.request, out int value) ? _parentDAL.GetList(x => x.Id == value) : _parentDAL.GetList(x => x.FirstName.StartsWith(request.request)));
        }
    }
}
