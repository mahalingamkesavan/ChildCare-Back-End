
using businessServicess.models.RequestModels.ChildCare;
using businessServicess.models.ResponseModel;

namespace ChildCareBAL.Iservicess
{
    public interface IChildBAL
    {
        Task<Response> Add(ChildRequest model);
        Task<ResponseChildDTO> GetChild(int id);
        Task<ResponceChildListDTO> GetChildList(string requestItem);
        Task<Response> Update(Child entity);
        Task<Response> DeleteChild(int id);
    }
}
