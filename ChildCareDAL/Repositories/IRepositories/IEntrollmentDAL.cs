using businessServicess.models.RequestModels.ChildCare;
using businessServicess.models.ResponseModel;
using System.Linq.Expressions;

namespace ChildCareDAL.Repositories.IRepositories
{
    public interface IEntrollmentDAL : IGenericRepository<ChildEnrollment>
    {
        public Task<List<ChildProfileDTO>> ChildProfiles(Expression<Func<ChildProfileDTO, bool>> filter = null);
    }
}
