
using businessServicess.models.RequestModels.ChildCare.pagination;
using businessServicess.models.ResponseModel;
using MediatR;

namespace ChildCareDAL.Querys.QueryEnrollment
{
    public class GetCHildProfileQuery : IRequest<List<ChildProfileDTO>>
    {
        public Paginationparameter paginationparameter;

        public GetCHildProfileQuery(Paginationparameter paginationparameter)
        {
            this.paginationparameter = paginationparameter;
        }
    }
}
