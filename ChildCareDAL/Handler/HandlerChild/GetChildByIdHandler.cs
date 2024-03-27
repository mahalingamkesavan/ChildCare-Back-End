using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Querys.QueryChild;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerChild
{
    public class GetChildByIdHandler : IRequestHandler<GetChildByIdQuery, Child>
    {
        private readonly IChildDAL childDAL;
        public GetChildByIdHandler(IChildDAL childDAL)
        {
            this.childDAL = childDAL;
        }

        public Task<Child> Handle(GetChildByIdQuery request, CancellationToken cancellationToken)
        {

            return childDAL.Get(x => x.Id == request.Id);
        }
    }
}
