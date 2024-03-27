using businessServicess.models.RequestModels.auth;
using businessServicess.models.RequestModels.ChildCare;

namespace ChildCareBAL.Iservicess
{
    public interface IClassBAL
    {
        public Task<List<ClassList>> GetClassList();
        public Task<Response> CreateClass(ClassList classList);
    }
}
