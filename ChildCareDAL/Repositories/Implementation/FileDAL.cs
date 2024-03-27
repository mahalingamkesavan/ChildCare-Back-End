using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.DBcontext;
using ChildCareDAL.Repositories.IRepositories;

namespace ChildCareDAL.Repositories.Implementation
{
    public class FileDAL : GenericRepository<FileDetails>, IFileDAL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public FileDAL(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }

}
