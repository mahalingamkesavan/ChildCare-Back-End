using businessServicess.models.RequestModels.ChildCare;
using businessServicess.models.ResponseModel;

namespace ChildCareBAL.Iservicess
{
    public interface IParentBAL
    {
        Task<Response> Add(Parent model);
        Task<ResponseParentDTO> GetParent(int id);
        Task<ResponseParentListDTO> GetParentList(string request);
        Task<Response> Update(Parent entity);
        Task<Response> DeleteParent(int id);
        Task<Responseparent> GetParentProfile(string UserName);
        Task<ParentChildDetailResponseDTO> GetParentChildRelationship(int id);
    }
}
