using businessServicess.models.RequestModels.ChildCare;
using businessServicess.models.RequestModels.ChildCare.pagination;
using businessServicess.models.ResponseModel;

namespace ChildCareBAL.Iservicess
{
    public interface IEnrollmentBAL
    {
        Task<Response> Add(EnrollmentRequest entrollment);
        Task<GetChildEnrollment> Get(int id);
        Task<GetEnrollmentList> GetList(string request);
        Task<Response> Update(EnrollmentRequest entity);
        Task<Response> Delete(int id);
        Task<Response> AddmissionApproval(EnrollmentApprovedRequest childEnrollment);
        Task<List<ChildEnrollment>> AdmissionApprovalpending();
        Task<List<ChildEnrollment>> AdmissionApprovallList();
        Task<List<ChildEnrollment>> AdmissionRejectedlList();
        Task<List<ChildEnrollment>> GetActiveChild(string request);
        Task<ChildProfileResponceDTO> GetChildren(Paginationparameter paginationparameter);
        Task<int> GetActiveChildCount();

    }
}
