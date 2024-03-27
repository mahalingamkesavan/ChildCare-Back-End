using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.DBcontext;
using ChildCareDAL.Repositories.IRepositories;

#nullable disable
namespace ChildCareDAL.Repositories.Implementation
{
    public class ChildDAL : GenericRepository<Child>, IChildDAL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ChildDAL(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
