using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.DBcontext;
using ChildCareDAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace ChildCareDAL.Repositories.Implementation
{
    public class ParentDAL : GenericRepository<Parent>, IParentDAL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ParentDAL(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<ParentChildDetailDTO> GetParentChildRelationship(int id)
        {
            ParentChildDetailDTO parentchild = new ParentChildDetailDTO();

            parentchild.Parent = await _applicationDbContext.parentTable.Select(s => s).Where(x => x.Id == id).FirstOrDefaultAsync();

            if (parentchild.Parent != null)
            {
                parentchild.ChildList = await _applicationDbContext.childTable.Where(ch => ch.parentID == id).ToListAsync();

                return parentchild;
            }
            else { return parentchild; }
        }

    }
}
