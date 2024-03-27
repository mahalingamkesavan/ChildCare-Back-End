using businessServicess.models.RequestModels.ChildCare;

namespace ChildCareDAL.Repositories.IRepositories
{
    public interface IParentDAL : IGenericRepository<Parent>
    {
        Task<ParentChildDetailDTO> GetParentChildRelationship(int id);
    }
}
