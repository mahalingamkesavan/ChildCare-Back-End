using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Querys.QueryClass;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Commands.ClassCommands
{
    public class GetClassListHandler : IRequestHandler<GetClassListQuery, List<ClassList>>
    {
        public IClassDAL classDAL;
        public GetClassListHandler(IClassDAL classDAL) { this.classDAL = classDAL; }

        public async Task<List<ClassList>> Handle(GetClassListQuery request, CancellationToken cancellationToken)
        {
            return await classDAL.GetList();
        }
    }
}
