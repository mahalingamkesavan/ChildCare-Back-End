using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Querys.QueryChild;
using ChildCareDAL.Repositories.IRepositories;
using ChildCareUtility;
using MediatR;

namespace ChildCareDAL.Handler.HandlerChild
{
    public class GetChildListHandler : IRequestHandler<GetChildListQuery, List<Child>>
    {
        private readonly IChildDAL _childDAL;
        public GetChildListHandler(IChildDAL childDAL) { this._childDAL = childDAL; }

        public async Task<List<Child>> Handle(GetChildListQuery request, CancellationToken cancellationToken)
        {
            if (request.request == null || request.request == ConstantVariables.nullabletype) return await _childDAL.GetList(null);

            return await (int.TryParse(request.request, out int value) ? _childDAL.GetList(x => x.parentID == value) : _childDAL.GetList(x => x.FirstName.StartsWith(request.request)));
        }
    }
}
